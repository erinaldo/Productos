package mx.elephantworks.iselling

import grails.converters.JSON
import org.imgscalr.Scalr

import javax.imageio.ImageIO
import java.awt.image.BufferedImage

import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class CategoriaController {

        static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE",uploadImage: "POST",uploadImageEdit: "POST"]
    def springSecurityService, payuService


    def index(Integer max) {
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def respuesta = payuService.validarPagosTransaccion(empresaInstance.idTransaccionPAYU)
        if(!respuesta.toString().equals("APPROVED"))
        {
            flash.error = "Su cuenta esta inactiva hasta que realice el pago en efectivo."
            redirect controller: 'Empresa', action: 'edit', id: empresaInstance.id
        }

        respond Categoria.filtroEmpresa(params.usuario).list(params)
    }

    def show(Categoria categoriaInstance) {
        respond categoriaInstance
    }

    def create() {
        respond new Categoria(params)
    }

    @Transactional
    def save(Categoria categoriaInstance) {
        if (categoriaInstance == null) {
            notFound()
            return
        }

        if (categoriaInstance.hasErrors()) {
            respond categoriaInstance.errors, view:'create'
            return
        }

        categoriaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'categoria.label', default: 'Categoria'), categoriaInstance.nombre])
                redirect action: 'index'
            }
            '*' { respond categoriaInstance, [status: CREATED] }
        }
    }

    def edit(Categoria categoriaInstance) {
        respond categoriaInstance
    }

    @Transactional
    def update(Categoria categoriaInstance) {
        if (categoriaInstance == null) {
            notFound()
            return
        }

        if (categoriaInstance.hasErrors()) {
            respond categoriaInstance.errors, view:'edit'
            return
        }

        categoriaInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Categoria.label', default: 'Categoria'), categoriaInstance.nombre])
                redirect action: 'index'
            }
            '*'{ respond categoriaInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Categoria categoriaInstance) {

        if (categoriaInstance == null) {
            notFound()
            return
        }

        categoriaInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Categoria.label', default: 'Categoria'), categoriaInstance.nombre])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'categoria.label', default: 'Categoria'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }

    def obtenerIdentificadorID(String identificador){
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def idEmpresa = empresaInstance.id

        def responseData = [
                'idEmpresa': idEmpresa,
                'identificador': identificador
        ]

        render responseData as JSON
    }

    def uploadImage(Categoria categoriaInstance){
        def imagen = request.getFile('fileInput')
        String nombreImagen = imagen.originalFilename
        String identificador = params.txtIdentificador

        if(nombreImagen){
            obtenerImagen(request.getFile('fileInput'),identificador);
        }

        redirect action: 'create'
    }

    def uploadImageEdit(Categoria categoriaInstance){
        def imagen = request.getFile('fileInput')
        String nombreImagen = imagen.originalFilename
        String identificador = params.txtIdentificador

        if(nombreImagen){
            obtenerImagen(request.getFile('fileInput'),identificador);
        }
        //Setear el campo de empresa actualizaImgProductos a uno
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        empresaInstance.actualizaImgCategorias = 1
        empresaInstance.save(flush: true)

        redirect action: 'edit', id: categoriaInstance.id
    }

    def obtenerImagen(def archivo,String identificador){
        archivo = request.getFile('fileInput')

        def webRootDir = servletContext.getRealPath("/")
        def userDir = new File(webRootDir, "/imgCategorias")
        userDir.mkdirs()

        archivo.transferTo( new File( userDir, identificador))

        String dir = userDir.getAbsolutePath().concat("/").concat(identificador);

        //Redimensionar la imagen
        def imageFile = new File(userDir, identificador)
        def imageIn = ImageIO.read(imageFile);
        def newFile = new File(userDir,  identificador)
        def widthImage = imageIn.getWidth()
        if(widthImage > 65) {
            BufferedImage scaledImage = Scalr.resize(imageIn, 65);
            ImageIO.write(scaledImage, "png", newFile);
        }

        return dir;
    }

}
