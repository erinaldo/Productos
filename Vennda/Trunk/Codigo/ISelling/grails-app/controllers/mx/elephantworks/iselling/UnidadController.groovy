package mx.elephantworks.iselling

import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class UnidadController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]
    def springSecurityService


    def index(Integer max) {

        respond Unidad.list(params)
    }

    def show(Unidad unidadInstance) {
        respond unidadInstance
    }

    def create() {
        respond new Unidad(params)
    }

    @Transactional
    def save(Unidad unidadInstance) {
        if (unidadInstance == null) {
            notFound()
            return
        }

        if (unidadInstance.hasErrors()) {
            respond unidadInstance.errors, view:'create'
            return
        }

        unidadInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'unidad.label', default: 'Unidad'), unidadInstance.abreviatura])
                redirect action: 'index'
            }
            '*' { respond unidadInstance, [status: CREATED] }
        }
    }

    def edit(Unidad unidadInstance) {
        respond unidadInstance
    }

    @Transactional
    def update(Unidad unidadInstance) {
        if (unidadInstance == null) {
            notFound()
            return
        }

        if (unidadInstance.hasErrors()) {
            respond unidadInstance.errors, view:'edit'
            return
        }

        unidadInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Unidad.label', default: 'Unidad'), unidadInstance.abreviatura])
                redirect action: 'index'
            }
            '*'{ respond unidadInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Unidad unidadInstance) {

        if (unidadInstance == null) {
            notFound()
            return
        }

        unidadInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Unidad.label', default: 'Unidad'), unidadInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'unidad.label', default: 'Unidad'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
