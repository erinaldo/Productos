package mx.elephantworks.iselling

import grails.converters.JSON
import grails.plugin.springsecurity.SpringSecurityUtils

import javax.imageio.ImageIO
import java.awt.image.BufferedImage
import org.imgscalr.Scalr

import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class EmpresaController {

    def springSecurityService
    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE", uploadImage: "POST"]

    def list(Integer max) {
        params.max = Math.min(max ?: 10, 100)
        respond Empresa.list(params), model:[empresaInstanceCount: Empresa.count()]
    }

    def index() {
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        redirect action: 'edit', id: empresaInstance.id

    }

    def edit(Empresa empresaInstance) {
        def entidades = null, ciudades = null
        if(empresaInstance.pais != null) {
            entidades = Entidad.findAllByPais(Pais.get(empresaInstance.pais.id))
            ciudades = Ciudad.findAllByEntidad(Entidad.get(empresaInstance.entidad.id))
        }



        respond empresaInstance, model: [entidades: entidades, ciudades: ciudades]
    }

    @Transactional
    def update(Empresa empresaInstance) {
        if (empresaInstance == null) {
            notFound()
            return
        }

        if (empresaInstance.hasErrors()) {
            respond empresaInstance.errors, view:'edit'
            return
        }



        empresaInstance.pais = Pais.get(params.pais)
        empresaInstance.entidad = Entidad.get(params.entidad)
        empresaInstance.ciudad = Ciudad.get(params.ciudad)

        empresaInstance.save flush:true





        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Empresa.label', default: 'Empresa'), empresaInstance.id])
                redirect controller: 'Login', action: 'auth'
            }
            '*'{ respond empresaInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Empresa empresaInstance) {

        if (empresaInstance == null) {
            notFound()
            return
        }

        empresaInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Empresa.label', default: 'Empresa'), empresaInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    def cambiarContrsena(ResetPasswordCommand command){

        if (!request.post) {
            return [command: new ResetPasswordCommand()]
        }

        Empresa empresaInstance = springSecurityService.getCurrentUser()
        String username = springSecurityService.getCurrentUser().username
        command.validate()

        def errores = ""

        if(command.password != command.password2){
            errores = " - Las contresañas no coinciden, Verifique sus datos.\n"
        }

        if(command.password.size() < 6){
            errores += "La contraseña debe tener minimo 6 caracteres.\n"
        }

        if(!checkPasswordRegex(command.password, command)){
            errores += "La contraseña debe tener al menos una letra, numero y un caracter especial: !@#\$%^&"
        }


        if (errores != "") {
            flash.error = errores
            redirect action: 'edit', id: empresaInstance.id
            return
        }

        Usuario.withTransaction { status ->
            def user = Usuario.findWhere(username: username)
            user.password = command.password
            user.save(flush: true)
        }

        springSecurityService.reauthenticate username

        flash.message = message(code: 'spring.security.ui.resetPassword.success')

        redirect action: 'edit', id: empresaInstance.id
    }

    def modificarPIN(){

        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def pin1 = params.pin
        def pin2 = params.confirmarPin

        if(pin1 != pin2){
            flash.error = "Los PINS no coinciden, Verifique sus datos."
            redirect action: 'edit', id: empresaInstance.id
            return
        }

        empresaInstance.pin = pin1
        empresaInstance.save(flush: true)

        flash.message = "El pin fue modificado exitosamente."

        redirect action: 'edit', id: empresaInstance.id
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'empresa.label', default: 'Empresa'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }

    static boolean checkPasswordRegex(String password, command) {
        def conf = SpringSecurityUtils.securityConfig

        String passValidationRegex = conf.ui.password.validationRegex ?:
                '^.*(?=.*\\d)(?=.*[a-zA-Z])(?=.*[!@#$%^&]).*$'

        password && password.matches(passValidationRegex)
    }

    def obtenerCodigoBarrasID(Empresa empresaInstance){

        def idEmpresa = empresaInstance.id

        def responseData = [
                'idEmpresa': idEmpresa
        ]

        render responseData as JSON
    }

    def uploadImage(Empresa empresaInstance){
        def imagen = request.getFile('fileInput')
        String nombreImagen = imagen.originalFilename
        def idRcv = empresaInstance.id

        if(nombreImagen){
            obtenerImagen(request.getFile('fileInput'),idRcv);
        }

        redirect action: 'edit', id: empresaInstance.id
    }

    def obtenerImagen(def archivo,def idRcv){
        archivo = request.getFile('fileInput')

        def webRootDir = servletContext.getRealPath("/")
        def userDir = new File(webRootDir, "/imgLogo")
        userDir.mkdirs()

        def idEmpresaRcv = idRcv +".png"

        archivo.transferTo( new File( userDir, idEmpresaRcv))

        String dir = userDir.getAbsolutePath().concat("/").concat(idEmpresaRcv);

        //Redimensionar la imagen
        def imageFile = new File(userDir, idEmpresaRcv)
        def imageIn = ImageIO.read(imageFile);
        def newFile = new File(userDir, idEmpresaRcv)
        def widthImage = imageIn.getWidth()
        if(widthImage > 65) {
            BufferedImage scaledImage = Scalr.resize(imageIn, 65);
            ImageIO.write(scaledImage, "png", newFile);
        }

        return dir;
    }



}




