package mx.elephantworks.iselling



import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class DescuentoController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]
    def plan = null

    def index(Integer max) {
        params.max = Math.min(max ?: 10, 100)
        respond Descuento.list(params), model:[descuentoInstanceCount: Descuento.count()]
    }

    def show(Descuento descuentoInstance) {
        respond descuentoInstance
    }

    def create() {
        plan = params.plan
        respond new Descuento(params)
    }

    @Transactional
    def save(Descuento descuentoInstance) {
        if (descuentoInstance == null) {
            notFound()
            return
        }

        if (descuentoInstance.hasErrors()) {
            respond descuentoInstance.errors, view:'create'
            return
        }

        descuentoInstance.save flush:true

        if(plan){
            Plan planInstance = Plan.get(plan as Long)

            if (planInstance){
                planInstance.codigo.add(descuentoInstance)
                planInstance.save(flush: true)

                redirect controller: 'plan', action: 'edit', id: planInstance.id
            }
        }else{
            request.withFormat {
                form multipartForm {
                    flash.message = message(code: 'default.created.message', args: [message(code: 'descuento.label', default: 'Descuento'), descuentoInstance.id])
                    redirect descuentoInstance
                }
                '*' { respond descuentoInstance, [status: CREATED] }
            }

        }

    }

    def edit(Descuento descuentoInstance) {
        plan = params.plan
        respond descuentoInstance
    }

    @Transactional
    def update(Descuento descuentoInstance) {
        if (descuentoInstance == null) {
            notFound()
            return
        }

        if (descuentoInstance.hasErrors()) {
            respond descuentoInstance.errors, view:'edit'
            return
        }


            descuentoInstance.save flush:true


        if(plan){
            Plan planInstance = Plan.get(plan as Long)
            redirect controller: 'plan', action: 'edit', id: planInstance.id
        }else
        {

            request.withFormat {
                form multipartForm {
                    flash.message = message(code: 'default.updated.message', args: [message(code: 'Descuento.label', default: 'Descuento'), descuentoInstance.id])
                    redirect descuentoInstance
                }
                '*' { respond descuentoInstance, [status: OK] }
           }
        }
    }

    @Transactional
    def delete(Descuento descuentoInstance) {

        if (descuentoInstance == null) {
            notFound()
            return
        }

        descuentoInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Descuento.label', default: 'Descuento'), descuentoInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'descuento.label', default: 'Descuento'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
