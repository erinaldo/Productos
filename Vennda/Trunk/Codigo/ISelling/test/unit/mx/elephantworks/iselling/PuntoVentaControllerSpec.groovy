package mx.elephantworks.iselling



import grails.test.mixin.*
import spock.lang.*

@TestFor(PuntoVentaController)
@Mock(PuntoVenta)
class PuntoVentaControllerSpec extends Specification {

    def populateValidParams(params) {
        assert params != null
        // TODO: Populate valid properties like...
        //params["name"] = 'someValidName'
    }

    void "Test the index action returns the correct model"() {

        when:"The index action is executed"
            controller.index()

        then:"The model is correct"
            !model.puntoVentaInstanceList
            model.puntoVentaInstanceCount == 0
    }

    void "Test the create action returns the correct model"() {
        when:"The create action is executed"
            controller.create()

        then:"The model is correctly created"
            model.puntoVentaInstance!= null
    }

    void "Test the save action correctly persists an instance"() {

        when:"The save action is executed with an invalid instance"
            request.contentType = FORM_CONTENT_TYPE
            request.method = 'POST'
            def puntoVenta = new PuntoVenta()
            puntoVenta.validate()
            controller.save(puntoVenta)

        then:"The create view is rendered again with the correct model"
            model.puntoVentaInstance!= null
            view == 'create'

        when:"The save action is executed with a valid instance"
            response.reset()
            populateValidParams(params)
            puntoVenta = new PuntoVenta(params)

            controller.save(puntoVenta)

        then:"A redirect is issued to the show action"
            response.redirectedUrl == '/puntoVenta/show/1'
            controller.flash.message != null
            PuntoVenta.count() == 1
    }

    void "Test that the show action returns the correct model"() {
        when:"The show action is executed with a null domain"
            controller.show(null)

        then:"A 404 error is returned"
            response.status == 404

        when:"A domain instance is passed to the show action"
            populateValidParams(params)
            def puntoVenta = new PuntoVenta(params)
            controller.show(puntoVenta)

        then:"A model is populated containing the domain instance"
            model.puntoVentaInstance == puntoVenta
    }

    void "Test that the edit action returns the correct model"() {
        when:"The edit action is executed with a null domain"
            controller.edit(null)

        then:"A 404 error is returned"
            response.status == 404

        when:"A domain instance is passed to the edit action"
            populateValidParams(params)
            def puntoVenta = new PuntoVenta(params)
            controller.edit(puntoVenta)

        then:"A model is populated containing the domain instance"
            model.puntoVentaInstance == puntoVenta
    }

    void "Test the update action performs an update on a valid domain instance"() {
        when:"Update is called for a domain instance that doesn't exist"
            request.contentType = FORM_CONTENT_TYPE
            request.method = 'PUT'
            controller.update(null)

        then:"A 404 error is returned"
            response.redirectedUrl == '/puntoVenta/index'
            flash.message != null


        when:"An invalid domain instance is passed to the update action"
            response.reset()
            def puntoVenta = new PuntoVenta()
            puntoVenta.validate()
            controller.update(puntoVenta)

        then:"The edit view is rendered again with the invalid instance"
            view == 'edit'
            model.puntoVentaInstance == puntoVenta

        when:"A valid domain instance is passed to the update action"
            response.reset()
            populateValidParams(params)
            puntoVenta = new PuntoVenta(params).save(flush: true)
            controller.update(puntoVenta)

        then:"A redirect is issues to the show action"
            response.redirectedUrl == "/puntoVenta/show/$puntoVenta.id"
            flash.message != null
    }

    void "Test that the delete action deletes an instance if it exists"() {
        when:"The delete action is called for a null instance"
            request.contentType = FORM_CONTENT_TYPE
            request.method = 'DELETE'
            controller.delete(null)

        then:"A 404 is returned"
            response.redirectedUrl == '/puntoVenta/index'
            flash.message != null

        when:"A domain instance is created"
            response.reset()
            populateValidParams(params)
            def puntoVenta = new PuntoVenta(params).save(flush: true)

        then:"It exists"
            PuntoVenta.count() == 1

        when:"The domain instance is passed to the delete action"
            controller.delete(puntoVenta)

        then:"The instance is deleted"
            PuntoVenta.count() == 0
            response.redirectedUrl == '/puntoVenta/index'
            flash.message != null
    }
}
