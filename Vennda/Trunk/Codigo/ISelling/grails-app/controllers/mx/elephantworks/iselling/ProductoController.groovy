package mx.elephantworks.iselling

import grails.converters.JSON
import org.apache.poi.xssf.usermodel.XSSFSheet
import org.apache.poi.xssf.usermodel.XSSFWorkbook
import org.imgscalr.Scalr

import javax.imageio.ImageIO
import java.awt.image.BufferedImage

import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class ProductoController {

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

        respond Producto.filtroEmpresa(params.usuario).list()
    }

    def show(Producto productoInstance) {
        respond productoInstance
    }

    def create() {
        respond new Producto(params)
    }

    @Transactional
    def save(Producto productoInstance) {
        if (productoInstance == null) {
            notFound()
            return
        }

        if (productoInstance.hasErrors()) {
            respond productoInstance.errors, view:'create'
            return
        }

        if(params.contadorImpuesto){
            def contador = params.contadorImpuesto
            int y = (contador as Integer) - 1

            for (int x=1; x <= y; x++) {
                def impuestos= params.list("impuestos[" + x + "]")
                impuestos.each {
                    def idImpuesto = it.valor.value.toString();

                    Impuesto impuestoInstance = Impuesto.get(idImpuesto as Long)
                    productoInstance.addToImpuesto(impuestoInstance)
                }
            }
        }


        productoInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.created.message', args: [message(code: 'producto.label', default: 'Producto'), productoInstance.nombre])
                redirect action: 'index'
            }
            '*' { respond productoInstance, [status: CREATED] }
        }
    }

    def edit(Producto productoInstance) {
        respond productoInstance
    }

    @Transactional
    def update(Producto productoInstance) {
        if (productoInstance == null) {
            notFound()
            return
        }

        if (productoInstance.hasErrors()) {
            respond productoInstance.errors, view:'edit'
            return
        }

        if(productoInstance.impuesto){

            productoInstance.impuesto.clear()
        }

        if(params.contadorImpuesto) {
            def contador = params.contadorImpuesto
            int y = (contador as Integer) - 1

            for (int x = 1; x <= y; x++) {
                def impuestos = params.list("impuestos[" + x + "]")
                impuestos.each {
                    def idImpuesto = it.valor.value.toString();

                    Impuesto impuestoInstance = Impuesto.get(idImpuesto as Long)
                    productoInstance.addToImpuesto(impuestoInstance)
                }
            }
        }

        productoInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Producto.label', default: 'Producto'), productoInstance.nombre])
                redirect action: 'index'
            }
            '*'{ respond productoInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Producto productoInstance) {

        if (productoInstance == null) {
            notFound()
            return
        }

        productoInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Producto.label', default: 'Producto'), productoInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }


    def cargarProductosExcel() {

        XSSFWorkbook wb
        if (params.secure == null){
            redirect action: "index", method: "GET"
            return
        }

        def archivo = request.getFile('listaProductos'), exito
        String archivoVacio = archivo.originalFilename

        if (archivoVacio.isEmpty()){
            flash.error = "Es necesario subir un archivo Excel para poder importar productos."
            redirect action: "index", method: "GET"
            return
        }

        String dir =  obtenerRuta(request.getFile('listaProductos'));
        File file1 = new File(dir);
        FileInputStream fis = new FileInputStream(file1);


        try {
            wb = new XSSFWorkbook(fis);
        }catch (Exception e){
            flash.message = "Solo se permiten archivos de excel."
            redirect action: "importarUsuariosView", method: "GET"
            return
        }

        //Se obtiene la primera hoja del libro de excel
        XSSFSheet sh = wb.getSheetAt(0);
        //Se obtienen el numero de filas que tiene el documento
        def filasTotal = sh.getLastRowNum();
        Empresa empresaInstance = springSecurityService.getCurrentUser()

        int productosInsertados = 0
        int productosErrores = 0

        for (def fila = 1; fila < filasTotal + 1; fila++) {
            Producto producto = new Producto()
            boolean existeProducto = true

            for (def columna = 0; columna < 7; columna++) {
                if(sh.getRow(fila).getCell(columna)){
                    def dato
                    try {
                        //Obtiene los datos de cadena
                        dato = sh.getRow(fila).getCell(columna).getStringCellValue();
                    }catch(Exception e){
                        //Obtiene los datos numericos
                        dato = sh.getRow(fila).getCell(columna).getNumericCellValue();
                    }

                    if(columna ==0){
                        //CodigoBarras
                        if(!Producto.findByCodigoBarras(dato.toString())){
                            existeProducto = false
                            producto.codigoBarras = dato.toString()
                        }
                    }

                    if(!existeProducto){
                        switch (columna){
                            case 1: producto.clave = dato.toString(); break;
                            case 2: producto.nombre = dato.toString(); break;
                            case 3: producto.descripcion = dato.toString(); break;
                            case 4:
                                if(dato){
                                    producto.precio = dato as BigDecimal;
                                }
                                break;
                            case 5:
                                if(dato){
                                    producto.precio2 = dato as BigDecimal;
                                }
                                break;
                            case 6:
                                if(dato){
                                    producto.precio3 = dato as BigDecimal;
                                }
                                break;
                            case 7:
                                if(dato){
                                    producto.precio4 = dato as BigDecimal;
                                }
                                break;
                            case 8:
                                if(dato){
                                    producto.precio5 = dato as BigDecimal;
                                }
                                break;
                        }
                    }
                }
            }

            if(!existeProducto)
            {
                if (producto.validate()) {
                    productosErrores ++
                }else {
                    producto.empresa = empresaInstance
                    producto.save(flush: true)
                    productosInsertados ++
                }

            }
        }

        flash.message = "Se importaron "+productosInsertados+" de "+filasTotal+" Productos." + (productosErrores > 0 ? " Hubo "+productosErrores+" producto(s) que no se pudieron insertar por campos vacios o caracteres invalidos." : "")
        redirect action: "index", method: "GET"
        return

    }

    def obtenerCodigoBarrasID(String codigoBarras){
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def idEmpresa = empresaInstance.id

             def responseData = [
                    'idProducto': idEmpresa,
                    'codigoBarras': codigoBarras
            ]

        render responseData as JSON
    }

    def uploadImage(Producto productoInstance){
        def imagen = request.getFile('fileInput')
        String nombreImagen = imagen.originalFilename
        String codigoBarras = params.txtCodigoBarras

        if(nombreImagen){
            obtenerImagen(request.getFile('fileInput'),codigoBarras);
        }

        redirect action: 'create'
    }

    def uploadImageEdit(Producto productoInstance){
        def imagen = request.getFile('fileInput')
        String nombreImagen = imagen.originalFilename
        String codigoBarras = params.txtCodigoBarras

        if(nombreImagen){
            obtenerImagen(request.getFile('fileInput'),codigoBarras);
        }

        //Setear el campo de empresa actualizaImgProductos a uno
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        empresaInstance.actualizaImgProductos = 1
        empresaInstance.save(flush: true)

        redirect action: 'edit', id: productoInstance.id
    }

    def obtenerImagen(def archivo,String codigoBarras){
        archivo = request.getFile('fileInput')

        def webRootDir = servletContext.getRealPath("/")
        def userDir = new File(webRootDir, "/imgProductos")
        userDir.mkdirs()

        archivo.transferTo( new File( userDir, codigoBarras))

        String dir = userDir.getAbsolutePath().concat("/").concat(codigoBarras);

        //Redimensionar la imagen
        def imageFile = new File(userDir, codigoBarras)
        def imageIn = ImageIO.read(imageFile);
        def newFile = new File(userDir,  codigoBarras)
        def widthImage = imageIn.getWidth()
        if(widthImage > 65) {
            BufferedImage scaledImage = Scalr.resize(imageIn, 65);
            ImageIO.write(scaledImage, "png", newFile);
        }

        return dir;
    }

    def productoMasterAjax(String codigoBarras){

        def producto = ProductoMaster.findByCodigoBarras(codigoBarras)

        render producto as JSON

    }

    def obtenerRuta(def archivo){
        archivo= request.getFile('listaProductos')

        def webRootDir = servletContext.getRealPath("/")
        def userDir = new File(webRootDir, "/cargaProductos")
        userDir.mkdirs()

        archivo.transferTo( new File( userDir, archivo.originalFilename))

        String dir = userDir.getAbsolutePath().concat("/").concat(archivo.originalFilename);
        return dir;
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'producto.label', default: 'Producto'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }
}
