package mx.elephantworks.iselling



import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional
import mx.elephantworks.iselling.Descuento

@Transactional(readOnly = true)
class PlanController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]

    def index(Integer max) {

        respond Plan.list(params)
    }

    def show(Plan planInstance) {
        respond planInstance
    }

    def create() {
        respond new Plan(params)
    }

    @Transactional
    def save(Plan planInstance) {
        if (planInstance == null) {
            notFound()
            return
        }

        if (planInstance.hasErrors()) {
            respond planInstance.errors, view:'create'
            return
        }

        planInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'plan.label', default: 'Plan'), planInstance.identificador])
                redirect action:"index"
            }
            '*' { respond planInstance, [status: CREATED] }
        }
    }

    def edit(Plan planInstance) {
        respond planInstance
    }

    @Transactional
    def update(Plan planInstance) {
        if (planInstance == null) {
            notFound()
            return
        }

        if (planInstance.hasErrors()) {
            respond planInstance.errors, view:'edit'
            return
        }

        planInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Plan.label', default: 'Plan'), planInstance.id])
                rredirect action:"index"
            }
            '*'{ respond planInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Plan planInstance) {

        if (planInstance == null) {
            notFound()
            return
        }

        planInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Plan.label', default: 'Plan'), planInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    def crearDescuentos(Plan planInstance){
        if (planInstance == null) {
            notFound()
            return
        }

        redirect controller: 'descuento', action: 'create', params: [plan: planInstance.id]

    }
    def editarDescuentos(Plan planInstance){
        if (planInstance == null) {
            notFound()
            return
        }

        redirect controller: 'descuento', action: 'edit', id: params.id, params: [plan: planInstance.id]

    }
    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'plan.label', default: 'Plan'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
