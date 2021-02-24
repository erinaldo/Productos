package mx.elephantworks.iselling



import grails.test.mixin.*
import spock.lang.*

@TestFor(UnidadController)
@Mock(Unidad)
class UnidadControllerSpec extends Specification {

    def populateValidParams(params) {
        assert params != null
        // TODO: Populate valid properties like...
        //params["name"] = 'someValidName'
    }

    void "Test the index action returns the correct model"() {

        when:"The index action is executed"
            controller.index()

        then:"The model is correct"
            !model.unidadInstanceList
            model.unidadInstanceCount == 0
    }

    void "Test the create action returns the correct model"() {
        when:"The create action is executed"
            controller.create()

        then:"The model is correctly created"
            model.unidadInstance!= null
    }

    void "Test the save action correctly persists an instance"() {

        when:"The save action is executed with an invalid instance"
            request.contentType = FORM_CONTENT_TYPE
            request.method = 'POST'
            def unidad = new Unidad()
            unidad.validate()
            controller.save(unidad)

        then:"The create view is rendered again with the correct model"
            model.unidadInstance!= null
            view == 'create'

        when:"The save action is executed with a valid instance"
            response.reset()
            populateValidParams(params)
            unidad = new Unidad(params)

            controller.save(unidad)

        then:"A redirect is issued to the show action"
            response.redirectedUrl == '/unidad/show/1'
            controller.flash.message != null
            Unidad.count() == 1
    }

    void "Test that the show action returns the correct model"() {
        when:"The show action is executed with a null domain"
            controller.show(null)

        then:"A 404 error is returned"
            response.status == 404

        when:"A domain instance is passed to the show action"
            populateValidParams(params)
            def unidad = new Unidad(params)
            controller.show(unidad)

        then:"A model is populated containing the domain instance"
            model.unidadInstance == unidad
    }

    void "Test that the edit action returns the correct model"() {
        when:"The edit action is executed with a null domain"
            controller.edit(null)

        then:"A 404 error is returned"
            response.status == 404

        when:"A domain instance is passed to the edit action"
            populateValidParams(params)
            def unidad = new Unidad(params)
            controller.edit(unidad)

        then:"A model is populated containing the domain instance"
            model.unidadInstance == unidad
    }

    void "Test the update action performs an update on a valid domain instance"() {
        when:"Update is called for a domain instance that doesn't exist"
            request.contentType = FORM_CONTENT_TYPE
            request.method = 'PUT'
            controller.update(null)

        then:"A 404 error is returned"
            response.redirectedUrl == '/unidad/index'
            flash.message != null


        when:"An invalid domain instance is passed to the update action"
            response.reset()
            def unidad = new Unidad()
            unidad.validate()
            controller.update(unidad)

        then:"The edit view is rendered again with the invalid instance"
            view == 'edit'
            model.unidadInstance == unidad

        when:"A valid domain instance is passed to the update action"
            response.reset()
            populateValidParams(params)
            unidad = new Unidad(params).save(flush: true)
            controller.update(unidad)

        then:"A redirect is issues to the show action"
            response.redirectedUrl == "/unidad/show/$unidad.id"
            flash.message != null
    }

    void "Test that the delete action deletes an instance if it exists"() {
        when:"The delete action is called for a null instance"
            request.contentType = FORM_CONTENT_TYPE
            request.method = 'DELETE'
            controller.delete(null)

        then:"A 404 is returned"
            response.redirectedUrl == '/unidad/index'
            flash.message != null

        when:"A domain instance is created"
            response.reset()
            populateValidParams(params)
            def unidad = new Unidad(params).save(flush: true)

        then:"It exists"
            Unidad.count() == 1

        when:"The domain instance is passed to the delete action"
            controller.delete(unidad)

        then:"The instance is deleted"
            Unidad.count() == 0
            response.redirectedUrl == '/unidad/index'
            flash.message != null
    }
}
