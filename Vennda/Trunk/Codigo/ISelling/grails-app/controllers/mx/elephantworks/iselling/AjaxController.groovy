package mx.elephantworks.iselling

import grails.converters.JSON
import grails.transaction.Transactional
import org.apache.commons.lang.StringUtils
import org.springframework.http.HttpStatus

import javax.swing.text.html.HTML
import java.text.SimpleDateFormat

import static org.springframework.http.HttpStatus.NOT_FOUND
import static org.springframework.http.HttpStatus.NO_CONTENT

class AjaxController {


    def addValorImpuestoForm(int indice){
        def form = render(template: "/impuesto/formValoresImpuesto", model:[ indice: indice] )
        return form as HTML
    }

    @Transactional
    def removeValorImpuesto(ValoresImpuesto valoresImpuestoInstance){
        if (valoresImpuestoInstance == null) {
            notFound()
            return
        }

        valoresImpuestoInstance.delete flush:true

        render status: NO_CONTENT
    }

    protected void notFound() {
        render status: NOT_FOUND
    }

    /*METODOS AJAX PARA PAIS ESTADO Y CIUDAD*/
    def cargarEntidades = {
        Pais pais = Pais.get(params.id);
        def entidadesLista = []
        if(pais)
        {
            def entidades = Entidad.findAllByPais(pais)

            entidades.each {
                entidadesLista.add(it.id+"."+it.nombreEntidad)
            }
        }
        render entidadesLista
    }

    def cargarCiudades = {
        Entidad entidad = Entidad.get(params.id)
        def ciudadesLista = []
        if(entidad)
        {
            def ciudades = Ciudad.findAllByEntidad(entidad)

            ciudades.each {
                ciudadesLista.add(it.id+"."+it.nombreCiudad)
            }
        }
        render ciudadesLista
    }


    def impuestosProducto = {
        Producto producto = Producto.get(params.id)
        def productoLista = [] // asi es como se genera un arreglo
        if(producto)
        {
            producto.impuesto.each { // es es la busqueda
                productoLista.add(it.id+"."+it.identificador) // aqui es como se agregan al arreg
            }
        }
        render productoLista
    }

    def impuestos = {
        SimpleDateFormat formatoFecha = new SimpleDateFormat("dd-MM-yyyy")

        Impuesto impuesto = Impuesto.get(params.id)
        def impuestoLista = []
        def impuestoOrdenado
        if(impuesto)
        {
            impuestoOrdenado = impuesto.valores.sort{it.fin}
            impuestoOrdenado.each {
                impuestoLista.add(it.tasa+"|"+formatoFecha.format(it.inicio)+"|"+formatoFecha.format(it.fin))
            }

        }
        render impuestoLista
    }

}