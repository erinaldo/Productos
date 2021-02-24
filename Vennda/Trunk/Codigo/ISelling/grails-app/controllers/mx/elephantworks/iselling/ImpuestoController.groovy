package mx.elephantworks.iselling

import java.text.SimpleDateFormat

import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class ImpuestoController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]
    def springSecurityService


    def index(Integer max) {

        respond Impuesto.activos().list(params)
    }

    def show(Impuesto impuestoInstance) {
        respond impuestoInstance
    }

    def create() {
        respond new Impuesto(params)
    }

    @Transactional
    def save(Impuesto impuestoInstance) {
        if (impuestoInstance == null) {
            notFound()
            return
        }

        if (impuestoInstance.hasErrors()) {
            respond impuestoInstance.errors, view:'create'
            return
        }

        if(params.contadorImpuesto){
            def contador = params.contadorImpuesto
            int y = (contador as Integer)
            SimpleDateFormat formatoFecha = new SimpleDateFormat("dd-MM-yyyy")

            for (int x=0; x <= y; x++) {
                def impuestos= params.list("impuestos[" + x + "]")
                impuestos.each {
                    def tasa = it.tasa.value.toString();
                    def fechaInicio = it.fechaInicio.value.toString();
                    def fechaFin = it.fechaFin.value.toString();

                    ValoresImpuesto valoresInstance = new ValoresImpuesto()
                    valoresInstance.tasa = tasa as BigDecimal
                    valoresInstance.inicio = formatoFecha.parse(fechaInicio)
                    valoresInstance.fin = formatoFecha.parse(fechaFin)

                    impuestoInstance.addToValores(valoresInstance)

                    
                }
            }
        }

        impuestoInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'impuesto.label', default: 'Impuesto'), impuestoInstance.identificador])
                redirect action: 'index'
            }
            '*' { respond impuestoInstance, [status: CREATED] }
        }
    }

    def edit(Impuesto impuestoInstance) {
        respond impuestoInstance
    }

    @Transactional
    def update(Impuesto impuestoInstance) {
        if (impuestoInstance == null) {
            notFound()
            return
        }

        if (impuestoInstance.hasErrors()) {
            respond impuestoInstance.errors, view:'edit'
            return
        }

        if(impuestoInstance.valores){

            impuestoInstance.valores.clear()
        }

        if(params.contadorImpuesto){
            def contador = params.contadorImpuesto
            int y = (contador as Integer)
            SimpleDateFormat formatoFecha = new SimpleDateFormat("dd-MM-yyyy")

            for (int x=0; x <= y; x++) {
                def impuestos= params.list("impuestos[" + x + "]")
                impuestos.each {
                    def tasa = it.tasa.value.toString();
                    def fechaInicio = it.fechaInicio.value.toString();
                    def fechaFin = it.fechaFin.value.toString();

                    ValoresImpuesto valoresInstance = new ValoresImpuesto()
                    valoresInstance.tasa = tasa as BigDecimal
                    valoresInstance.inicio = formatoFecha.parse(fechaInicio)
                    valoresInstance.fin = formatoFecha.parse(fechaFin)

                    impuestoInstance.addToValores(valoresInstance)
                }
            }
        }

        impuestoInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Impuesto.label', default: 'Impuesto'), impuestoInstance.identificador])
                redirect action: 'index'
            }
            '*'{ respond impuestoInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Impuesto impuestoInstance) {

        if (impuestoInstance == null) {
            notFound()
            return
        }
        //Validar si existe un producto antes de eliminar el impuesto
        def productoExists = Producto.findAllByImpuesto(impuestoInstance)
        if(!productoExists) {
            impuestoInstance.delete flush: true


            request.withFormat {
                form multipartForm {
                    flash.message = message(code: 'default.deleted.message', args: [message(code: 'Impuesto.label', default: 'Impuesto'), impuestoInstance.identificador])
                    redirect action: "index", method: "GET"
                }
                '*' { render status: NO_CONTENT }
            }

        }else{
            request.withFormat {
                form multipartForm {
                    flash.message = message(code: 'default.validaExistencia.message',  default: 'El impuesto esta siendo utilizado en producto')
                    redirect action: "index", method: "GET"
                }
                '*' { render status: NO_CONTENT }
            }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'impuesto.label', default: 'Impuesto'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
