package mx.elephantworks.iselling

import jxl.Workbook
import jxl.write.Label
import jxl.write.WritableSheet
import jxl.write.WritableWorkbook
import org.apache.poi.xssf.usermodel.XSSFSheet
import org.apache.poi.xssf.usermodel.XSSFWorkbook

import static org.springframework.http.HttpStatus.*
import grails.transaction.Transactional

@Transactional(readOnly = true)
class InventarioController {

    static allowedMethods = [save: "POST", update: "PUT", delete: "DELETE"]
    def payuService, springSecurityService

    def index(Integer max) {
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        def respuesta = payuService.validarPagosTransaccion(empresaInstance.idTransaccionPAYU)
        if(!respuesta.toString().equals("APPROVED"))
        {
            flash.error = "Su cuenta esta inactiva hasta que realice el pago en efectivo."
            redirect controller: 'Empresa', action: 'edit', id: empresaInstance.id
        }

        def idPuntoVenta = params.puntoVentaId
        def productos = Producto.filtroEmpresa(params.usuario).list()

        if(idPuntoVenta){

            PuntoVenta puntoVentaInstance = PuntoVenta.get(idPuntoVenta as Long)
            respond Inventario.filtroPuntoVenta(puntoVentaInstance).list(), model:[productosEmpresa: productos, puntoVenta: puntoVentaInstance]
        }/*else {
            respond Inventario.filtroEmpresa(params.usuario).list(), model: [productosEmpresa: productos.toList()]

        }*/

    }

    def show(Inventario inventarioInstance) {
        respond inventarioInstance
    }

    def create() {
        def id = params.idPuntoVenta

        if(id){
            def productos = Producto.filtroEmpresa(params.usuario).list()
            def puntoVentas = PuntoVenta.filtroEmpresa(params.usuario).list()
            def puntoVenta = PuntoVenta.get(id as Long);

            respond new Inventario(params), model: [productos: productos, puntoVentas: puntoVentas, punto: puntoVenta]
        }else{
            flash.error = "Es necesario seleccionar un punto de venta."
            redirect action: 'index'
        }

    }

    @Transactional
    def save(Inventario inventarioInstance) {
        if (inventarioInstance == null) {
            notFound()
            return
        }

        def id = params.idPuntoVenta

        if (inventarioInstance.hasErrors()) {
            if(id){
                def productos = Producto.filtroEmpresa(params.usuario).list()
                def puntoVentas = PuntoVenta.filtroEmpresa(params.usuario).list()
                def puntoVenta = PuntoVenta.get(id as Long);

                respond inventarioInstance.errors, view:'create', model: [productos: productos, puntoVentas: puntoVentas, punto: puntoVenta]
                return
            }


        }


        Empresa empresa = Empresa.get(params.empresa.id as Long)


        def contador = params.contador
        int y = contador as Integer
        int contadorCreados = 0
        int contadorModificados = 0

        for (int x=1; x <= y; x++){
            def totalesInventario = params.list("valores["+x+"]")
            totalesInventario.each{
                def cant = it.cantidad.value.toString();
                def punt = it.puntoVenta.value.toString();
                def prod = it.producto.value.toString();

                PuntoVenta puntoVenta = PuntoVenta.get(punt as Long)
                Producto producto = Producto.get(prod as Long)
                Inventario inventario = Inventario.findByPuntoVentaAndProducto(puntoVenta, producto)

                if(inventario){
                    int suma = (cant as BigDecimal) + inventario.cantidad
                    inventario.cantidad = suma
                    contadorModificados++
                }else{
                    inventario = new Inventario()
                    inventario.empresa = empresa
                    inventario.puntoVenta = puntoVenta
                    inventario.producto = producto
                    inventario.cantidad = cant as BigDecimal
                    contadorCreados++
                }
                inventario.save(flush: true)
            }
        }

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'inventario.creados.message', args: [contadorCreados, contadorModificados])
                redirect action: 'index', params: [puntoVentaId: id]
            }
            '*' { respond inventarioInstance, [status: CREATED] }
        }
    }

    def edit(Inventario inventarioInstance) {
        respond inventarioInstance
    }

    @Transactional
    def update(Inventario inventarioInstance) {
        if (inventarioInstance == null) {
            notFound()
            return
        }

        if (inventarioInstance.hasErrors()) {
            respond inventarioInstance.errors, view:'edit'
            return
        }

        def cantidadAgregar = params.cantidadAgregar
        inventarioInstance.cantidad = inventarioInstance.cantidad + Integer.parseInt(cantidadAgregar)

        inventarioInstance.save flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.updated.message', args: [message(code: 'Inventario.label', default: 'Inventario'), inventarioInstance.producto.nombre])
                redirect action: 'index', params: [puntoVentaId: inventarioInstance.puntoVenta.id]
            }
            '*'{ respond inventarioInstance, [status: OK] }
        }
    }

    @Transactional
    def delete(Inventario inventarioInstance) {

        if (inventarioInstance == null) {
            notFound()
            return
        }

        inventarioInstance.delete flush:true

        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.deleted.message', args: [message(code: 'Inventario.label', default: 'Inventario'), inventarioInstance.id])
                redirect action:"index", method:"GET"
            }
            '*'{ render status: NO_CONTENT }
        }
    }

    protected void notFound() {
        request.withFormat {
            form multipartForm {
                flash.message = message(code: 'default.not.found.message', args: [message(code: 'inventario.label', default: 'Inventario'), params.id])
                redirect action: "index", method: "GET"
            }
            '*'{ render status: NOT_FOUND }
        }
    }

    def exportarInventario(){

        def productos = params.list("producto")

        def fila = 1

        //exportar excel
        response.setContentType('application/vnd.ms-excel')
        response.setHeader('Content-Disposition', 'Attachment;Filename="plantilla_oficial_vennda.xls"')
        WritableWorkbook workbook = Workbook.createWorkbook(response.getOutputStream())
        WritableSheet sheet1 = workbook.createSheet("Inventarios", 0)

        //cabecera
        sheet1.addCell(new Label(0,0, "Clave Producto"))
        sheet1.addCell(new Label(1,0, "Producto"))
        sheet1.addCell(new Label(2,0, "Cantidad"))

        productos.each {
            it.each { x ->

                def llave = x.key.toString()
                if(!llave.contains('_')){
                    Producto producto = Producto.get(llave as Long)
                    sheet1.addCell(new Label(0,fila, producto.id.toString()))
                    sheet1.addCell(new Label(1,fila, producto.nombre))
                    fila ++
                }
            }
        }

        workbook.write();
        workbook.close();

    }

    def importarInventarioExcel(){

        if(!params.idPuntoVenta){
            flash.error = "Es necesario seleccionar un punto de venta."
            redirect action: "index", method: "GET"
            return
        }

        XSSFWorkbook wb
        if (params.secure == null){
            redirect action: "index", method: "GET"
            return
        }

        def archivo = request.getFile('listaInventario'), exito
        String archivoVacio = archivo.originalFilename

        if (archivoVacio.isEmpty()){
            flash.error = "Es necesario subir un archivo Excel para poder importar inventarios."
            redirect action: "index", method: "GET"
            return
        }

        String dir =  obtenerRuta(request.getFile('listaInventario'));
        File file1 = new File(dir);
        FileInputStream fis = new FileInputStream(file1);


        try {
            wb = new XSSFWorkbook(fis);
        }catch (Exception e){
            flash.message = "Solo se permiten archivos de excel."
            redirect action: "index", method: "GET"
            return
        }

        //Se obtiene la primera hoja del libro de excel
        XSSFSheet sh = wb.getSheetAt(0);
        //Se obtienen el numero de filas que tiene el documento
        def filasTotal = sh.getLastRowNum();
        Empresa empresaInstance = springSecurityService.getCurrentUser()
        PuntoVenta puntoVenta = PuntoVenta.get(params.idPuntoVenta as Long)

        int inventarioInsertados = 0
        int inventarioErrores = 0

        for (def fila = 1; fila < filasTotal + 1; fila++) {
            Inventario inventario
            boolean existeInventario = false

            for (def columna = 0; columna < 3; columna++) {
                if(sh.getRow(fila).getCell(columna)){
                    def dato
                    try {
                        //Obtiene los datos de cadena
                        dato = sh.getRow(fila).getCell(columna).getStringCellValue();
                    }catch(Exception e){
                        //Obtiene los datos numericos
                        dato = sh.getRow(fila).getCell(columna).getNumericCellValue();
                    }

                    if(columna == 0){
                        inventario = Inventario.findByPuntoVentaAndProducto(puntoVenta, Producto.get(dato as Long))
                        if(inventario){
                            existeInventario = true
                        }else {
                            inventario = new Inventario()
                        }
                    }

                    switch (columna){
                        case 0:
                            if(!existeInventario) inventario.producto = Producto.get(dato as Long);
                             break;

                        case 2:
                            BigDecimal cantidad = dato as BigDecimal
                            if(!existeInventario){
                                inventario.cantidad = cantidad;
                            }else{
                                BigDecimal total = inventario.cantidad + cantidad
                                inventario.cantidad = total
                            }
                            break;
                    }
                }
            }

            if(!existeInventario){
                inventario.empresa = empresaInstance
                inventario.puntoVenta = puntoVenta
                if (inventario.hasErrors()){
                    inventarioErrores ++
                }else{
                    inventarioInsertados ++
                    inventario.save(flush: true)
                }
            }else{
                inventarioInsertados ++
                inventario.save(flush: true)
            }





        }

        flash.message = "Se importaron "+inventarioInsertados+" inventarios exitosamente."
        redirect action: "index", method: "GET"
        return
    }

    def obtenerRuta(def archivo){
        archivo= request.getFile('listaInventario')

        def webRootDir = servletContext.getRealPath("/")
        def userDir = new File(webRootDir, "/cargaInventario")
        userDir.mkdirs()

        archivo.transferTo( new File( userDir, archivo.originalFilename))

        String dir = userDir.getAbsolutePath().concat("/").concat(archivo.originalFilename);
        return dir;
    }

}
