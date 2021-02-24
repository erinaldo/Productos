package mx.elephantworks.iselling

import org.springframework.security.authentication.AuthenticationManager
import org.springframework.security.authentication.BadCredentialsException
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken
import org.springframework.security.core.context.SecurityContextHolder

import javax.servlet.http.HttpServletResponse
import java.util.zip.ZipEntry
import java.util.zip.ZipOutputStream

import grails.transaction.Transactional

@Transactional(readOnly = true)
class APIController {

    static allowedMethods = [LoginStaff: "PUT",ConsultaPuntoVenta: "PUT",login:"PUT",ConsultaProductos:"PUT",respondZip:"PUT",CierreDeCaja:"PUT"]

    def LoginStaff()
    {
        /*
        URL:http://localhost:8080/ISelling/api/API/LoginStaff
        Method:PUT
        Headers: Content-type / application-json
        Request:{"email": "luis@gmail.com","pin": "1234"}
        Respond:queryResultsEmpresa + queryResultsStaff + queryResultsPuntoVenta
         */
        def results = request.getJSON()
        def email = results.email
        def pin = results.pin
        def queryResultsStaff = Staff.findAllByEmailAndPin(email,pin)
        def queryResultsEmpresa = queryResultsStaff.empresa[0]
        def queryResultsPuntoVenta = PuntoVenta.findAllByEmpresa(queryResultsEmpresa)

        if(queryResultsStaff){
            if(queryResultsPuntoVenta){
                def queryStaffTodos = Staff.findAllByEmpresa(queryResultsEmpresa)
                render(contentType: 'text/json') {[
                        'ResultsEmpresa': queryResultsEmpresa,
                        'ResultsStaff': queryStaffTodos,
                        'ResultsPuntoVenta': queryResultsPuntoVenta
                ]}
            }else{
                render(contentType: 'text/json') {[
                        'ResultMensaje': [
                                'codigoError': 'indefinido',
                                'mensaje':'No existen puntos de venta',
                                'detalle':'Puntos Venta NULL'
                        ]
                ]}
            }
        }else{
            render(contentType: 'text/json') {[
                    'ResultMensaje': [
                            'codigoError': '401',
                            'mensaje':'Por favor verifique las credenciales',
                            'detalle':'CREDENCIALES INCORRECTAS'
                    ]
            ]}
        }




    }

    def ConsultaPuntoVenta()
    {
        /*
        URL:http://localhost:8080/ISelling/api/API/ConsultaPuntoVenta
        Method:PUT
        Headers: Content-type / application-json
        Request:{"puntoVentaId": "1","empresaId": "2"}
        Respond:información de productos, clientes, categorias e inventario
         */
        def results = request.getJSON()
        def idPuntoVenta = results.puntoVentaId
        def idEmpresa = results.empresaId
        def resultsPuntoVenta = PuntoVenta.findById(idPuntoVenta)
        if(resultsPuntoVenta){
            if(!resultsPuntoVenta.cerrado) {
                def resultsEmpresa = Empresa.findAllById(idEmpresa)
                def resultsProducto = Producto.findAllByEmpresaAndActivo(resultsEmpresa, true)
                def resultsClientes = Cliente.findAllByEmpresa(resultsEmpresa)
                def resultsCategorias = Categoria.findAllByEmpresa(resultsEmpresa)
                def resultsInventario = Inventario.findAllByEmpresaAndPuntoVenta(resultsEmpresa, resultsPuntoVenta)
                def resultsPlan = resultsEmpresa.plan
                def resultsValoresImp = ValoresImpuesto.getAll();
                def resultsImpuesto = Impuesto.getAll()
                def resultsValoresRef = ValoresReferencia.getAll();
                def resultsImpresora
                if(resultsPuntoVenta.impresoraActivo == true){
                    resultsImpresora = resultsPuntoVenta.impresora
                }
                def resultsVentas = Venta.findAllByEmpresaAndPuntoVentaAndSaldoGreaterThan(resultsEmpresa, resultsPuntoVenta, 0);
                def resultsVentasDetalle = [];
                def resultsCobranza = [];
                def resultsAbono = [];
                if(resultsVentas){
                    resultsVentasDetalle = VentaDetalle.executeQuery("select distinct vd from VentaDetalle vd where venta in (:p1)", [p1: resultsVentas]);
                    resultsCobranza = Cobranza.executeQuery("select distinct c from Cobranza c where venta in (:p1)", [p1: resultsVentas]);
                    if(resultsCobranza){
                        resultsAbono = resultsCobranza.abono;
                    }
                }
                if (resultsPlan) {
                    if (resultsClientes) {
                        if (resultsProducto) {
                            if (resultsInventario) {
                                if (resultsCategorias) {

                                //resultsPuntoVenta.cerrado = true
                                //resultsPuntoVenta.save(flush: true)

                                    resultsInventario.each {inventario ->
                                        inventario.activo = true
                                        inventario.save(flush: true)
                                    }

                                //Responde toda la información de productos, clientes, categorias e inventario
                                    if(resultsImpresora){
                                        render(contentType: 'text/json') {
                                            [
                                                    'resultsProducto'  : resultsProducto,
                                                    'resultsClientes'  : resultsClientes,
                                                    'resultsCategorias': resultsCategorias,
                                                    'resultsInventario': resultsInventario,
                                                    'resultValoresImp': resultsValoresImp,
                                                    'resultsImpuesto'  : resultsImpuesto,
                                                    'resultsPlan':resultsPlan,
                                                    'resultsImpresora': resultsImpresora,
                                                    'resultsValoresRef': resultsValoresRef,
                                                    'resultsVentas' : resultsVentas,
                                                    'resultsVentasDetalle' : resultsVentasDetalle,
                                                    'resultsCobranza' : resultsCobranza,
                                                    'resultsAbono' : resultsAbono
                                            ]
                                        }
                                    }else{
                                        render(contentType: 'text/json') {
                                            [
                                                    'resultsProducto'  : resultsProducto,
                                                    'resultsClientes'  : resultsClientes,
                                                    'resultsCategorias': resultsCategorias,
                                                    'resultsInventario': resultsInventario,
                                                    'resultValoresImp': resultsValoresImp,
                                                    'resultsImpuesto'  : resultsImpuesto,
                                                    'resultsPlan':resultsPlan,
                                                    'resultsValoresRef': resultsValoresRef,
                                                    'resultsVentas' : resultsVentas,
                                                    'resultsVentasDetalle' : resultsVentasDetalle,
                                                    'resultsCobranza' : resultsCobranza,
                                                    'resultsAbono' : resultsAbono
                                            ]
                                        }
                                    }

                            } else {
                                render(contentType: 'text/json') {
                                    [
                                            'ResultMensaje': [
                                                    'codigoError': 'indefinido',
                                                    'mensaje'    : 'No existen categorías registradas, es necesario que exista por lo menos una.',
                                                    'detalle'    : 'Categorías NULL'
                                            ]
                                    ]
                                }
                            }
                        } else {
                            render(contentType: 'text/json') {
                                [
                                        'ResultMensaje': [
                                                'codigoError': 'indefinido',
                                                'mensaje'    : 'No existen datos en inventario',
                                                'detalle'    : 'Inventario NULL'
                                        ]
                                ]
                            }
                        }
                    } else {
                        render(contentType: 'text/json') {
                            [
                                    'ResultMensaje': [
                                            'codigoError': 'indefinido',
                                            'mensaje'    : 'No existen productos registrados',
                                            'detalle'    : 'Productos NULL'
                                    ]
                            ]
                        }
                    }
                } else {
                    render(contentType: 'text/json') {
                        [
                                'ResultMensaje': [
                                        'codigoError': 'indefinido',
                                        'mensaje'    : 'No existen clientes registrados',
                                        'detalle'    : 'Clientes NULL'
                                ]
                        ]
                    }
                }
            }else{
                    render(contentType: 'text/json') {
                        [
                                'ResultMensaje': [
                                        'codigoError': 'indefinido',
                                        'mensaje'    : 'No cuenta con un plan registrado',
                                        'detalle'    : 'Plan NULL'
                                ]
                        ]
                    }

                }

            }else{
                render(contentType: 'text/json') {[
                        'ResultMensaje': [
                                'codigoError': 'indefinido',
                                'mensaje':'Por favor intentelo más tarde o eliga otro punto de venta, ya que el punto de venta está siendo utilizado',
                                'detalle':'El punto de venta está siendo utilizado'
                        ]
                ]}
            }
        }else{
            render(contentType: 'text/json') {[
                    'ResultMensaje': [
                            'codigoError': 'indefinido',
                            'mensaje':'Verifique el id del punto de venta',
                            'detalle':'No existe el punto de venta'
                    ]
            ]}
        }

    }
    //Petición de Ejemplo
    def ConsultaProductos()
    {
        /*
        URL:http://localhost:8080/ISelling/api/API/ConsultaPuntoVenta
        Method:PUT
        Headers: Content-type / application-json
        Request:{"empresaId": "2"}
        Respond:información de productos, clientes, categorias e inventario
         */
        def results = request.getJSON()
        def idEmpresa = results.empresaId
        def resultsEmpresa = Empresa.findAllById(idEmpresa)
        def resultsProducto = Producto.findByEmpresaAndActivo(resultsEmpresa,true)

                render(contentType: 'text/json') {[
                        'resultsProducto': resultsProducto
                ]}

    }

    def login = {
        final String authorization = request.getHeader("Authorization");
        if (authorization != null && authorization.startsWith("Basic")) {
            boolean authResult = authenticateUser(authorization)
            if (authResult) {
                render response.status
            } else {
                render(contentType: 'text/json') {[
                        'results': response
                ]}
            }

        } else {
            render(contentType: 'text/json') {[
                    'results': response
            ]}
        }
    }

    protected boolean authenticateUser(String authorization) {
        // Authorization: Basic base64credentials
        AuthenticationManager authenticationManager;
        def base64Credentials = authorization.substring("Basic".length()).trim();
        byte[] credentials = base64Credentials.decodeBase64()
        String actualCredential = new String(credentials)
        // credentials format like username:password
        final String[] values = actualCredential.split(":", 2);
        UsernamePasswordAuthenticationToken authRequest = new UsernamePasswordAuthenticationToken(values[0], values[1]);

        try {
            def authentication = authenticationManager.authenticate(authRequest);
            def securityContext = SecurityContextHolder.getContext();
            securityContext.setAuthentication(authentication);
            def session = request.session;
            session.setAttribute("SPRING_SECURITY_CONTEXT", securityContext);
        }
        catch (BadCredentialsException exception) {
            return false

        }
        return true

    }

    protected HttpServletResponse authFailedResponse(HttpServletResponse response) {
        response.setStatus(401)
        response.setHeader("WWW-Authenticate", "Basic realm=\"nmrs_m7VKmomQ2YM3:\"")
        return response;
    }

    public byte[] respondZip(){
        byte[] bufferFinal = new byte[1024];
        try {
            /*
            URL:http://localhost:8080/ISelling/api/API/respondZip
            Method:PUT
            Headers: Content-type / application-json
            Request:{"empresaId": "2"}
            Respond:zip de Imagenes de Productos
             */
            def results = request.getJSON()
            def idEmpresa = results.empresaId
            def carpeta = results.carpeta
            def archivoZip = results.archivoZip
            def procesoFinal = results.final

            //Validar si hubo alguna actualización, osea si el campo actualizacionImgProductos del Domain de Empresa es uno
            Empresa emp = Empresa.findById(idEmpresa)
            def actualizacionImgProductos = emp.actualizaImgProductos
            def actualizacionImgCategorias = emp.actualizaImgCategorias

            if (actualizacionImgProductos == 1 && carpeta == "imgProductos") {
                //bufferFinal = EjecutarImgZip("imgProductos","images/archivosProductos.zip");
                bufferFinal = EjecutarImgZip();
            }
            if(actualizacionImgCategorias == 1 && carpeta == "imgCategorias"){
                //bufferFinal = EjecutarImgZip("imgCategorias","images/archivosCategorias.zip");
                bufferFinal = EjecutarImgZip();
            }
            if (procesoFinal == "true") {

                if (actualizacionImgCategorias == 1) {
                    emp.actualizaImgCategorias = 0
                    emp.save(flush: true)
                }
                if (actualizacionImgProductos == 1) {
                    emp.actualizaImgProductos = 0
                    emp.save(flush: true)
                }
            }
        } catch (Exception ex ) {

        }

        render file: bufferFinal, contentType: 'text/html;charset=utf-8'

    }

    public byte[] EjecutarImgZip(){
        ByteArrayOutputStream byteArrayOutputStream = null;
        byte[] bufferFinal = new byte[1024];
        try {
            /*
            URL:http://localhost:8080/ISelling/api/API/respondZip
            Method:PUT
            Headers: Content-type / application-json
            Request:{"empresaId": "2"}
            Respond:zip de Imagenes de Productos
             */
            def results = request.getJSON()
            def idEmpresa = results.empresaId
            def carpeta = results.carpeta
            def archivoZip = results.archivoZip
            def procesoFinal = results.final


                //C:\Duxstar\Productos\Vennda\Trunk\Codigo\ISelling\web-app\imgProductos
                def webrootDir = servletContext.getRealPath("/")
                File carpetaComprimir = new File(webrootDir, carpeta)

                def webrootDir2 = servletContext.getRealPath("/")
                File carpetaComprimir2 = new File(webrootDir2, archivoZip)

                if (carpetaComprimir.exists()) {
                    String[] splitArrayFiles = carpetaComprimir.list();

                    ArrayList arrayFiles = new ArrayList();

                    for (int a = 0; a < splitArrayFiles.length; a++) {
                        if (splitArrayFiles[a].toString().contains(idEmpresa + "_")) {
                            arrayFiles.add(splitArrayFiles[a].toString())
                        }
                    }

                    int longitudArrayListFiles = arrayFiles.size()
                    String[] sourceFiles = new String[longitudArrayListFiles]

                    for (int c = 0; c < arrayFiles.size(); c++) {
                        sourceFiles[c] = arrayFiles[c].toString()
                    }

                    //create byte buffer
                    byte[] buffer = new byte[1024];
                    FileOutputStream fileOutputStream = new FileOutputStream(carpetaComprimir2.path);
                    FileOutputStream fout = fileOutputStream;
                    ZipOutputStream zout = new ZipOutputStream(fout);


                    for (int i = 0; i < sourceFiles.length; i++) {
                        FileInputStream fin = new FileInputStream(carpetaComprimir.path + "\\" + sourceFiles[i]);
                        zout.putNextEntry(new ZipEntry(sourceFiles[i]));
                        int length;
                        while ((length = fin.read(buffer)) > 0) {
                            zout.write(buffer, 0, length);
                        }
                        zout.closeEntry();
                        fin.close();
                    }
                    zout.close();

                }

                int start = 0;
                int length = 1024;
                int offset = -1;

                FileInputStream fileInuptStream = new FileInputStream(carpetaComprimir2.path);
                BufferedInputStream bufferedInputStream = new BufferedInputStream(fileInuptStream);
                byteArrayOutputStream = new ByteArrayOutputStream();

                while ((offset = bufferedInputStream.read(bufferFinal, start, length)) != -1) {
                    byteArrayOutputStream.write(bufferFinal, start, offset);
                }

                bufferedInputStream.close();
                byteArrayOutputStream.flush();
                bufferFinal = byteArrayOutputStream.toByteArray();

                byteArrayOutputStream.close();

                carpetaComprimir2.delete()

        } catch (Exception ex ) {

        }

        return bufferFinal

    }

    @Transactional
    def CierreDeCaja(){
        /*
        URL:http://localhost:8080/ISelling/api/API/CierreDeCaja
        Method:PUT
        Headers: Content-type / application-json
        Request:{"Clientes":[{"clave":"2","razonSocial":"hh","rfc":"5","domicilio":"g","colonia":"f","cp":"4","diasCredito":8,"limiteCredito":0,"creditoActual":0,"email":"y","listaPrecios":1,"telefonoCelular":"5","alta":2},{"clave":"5","razonSocial":"l","rfc":"49","domicilio":"f","colonia":"g","cp":"4","diasCredito":2,"limiteCredito":0,"creditoActual":0,"email":"f","listaPrecios":3,"telefonoCelular":"49","alta":2}]}
        Respond:Detalle de insert
         */
        def results = request.getJSON()
        def resultadoInsertCliente = "";
        def resultadoInsertAperturaCierre = "";
        def resultadoInsertInventarios = "";
        def resultadoInsertVentas = "";

        //Guardar Clientes
        if(results.toString().contains("Clientes")) {

            for(int x = 1; x< results.Clientes.size();x++) {
                Cliente cliente = new Cliente()
                cliente.clave = results.Clientes[x].clave
                cliente.razonSocial = results.Clientes[x].razonSocial
                cliente.rfc = results.Clientes[x].rfc
                cliente.domicilio = results.Clientes[x].domicilio
                cliente.colonia = results.Clientes[x].colonia
                cliente.cp = results.Clientes[x].cp
                cliente.diasCredito = results.Clientes[x].diasCredito
                cliente.limiteCredito = results.Clientes[x].limiteCredito
                cliente.creditoActual = results.Clientes[x].creditoActual
                cliente.email = results.Clientes[x].email
                cliente.listaPrecios = results.Clientes[x].listaPrecios
                cliente.telefonoCelular = results.Clientes[x].telefonoCelular
                cliente.alta = results.Clientes[x].alta
                Empresa empresa = Empresa.get(results.Clientes[x].empresa)
                cliente.empresa = empresa
                cliente.save(flush: true)

                resultadoInsertCliente =  results.Clientes.size().toString()+" clientes registrados exitosamente";
            }
        }

        //Guardar Apertura Cierre
        if(results.toString().contains("AperturaCierre")) {
            AperturaCierre aperturaCierre = new AperturaCierre()
            Date dateAbre = new Date(results.AperturaCierre.fechaAbre)
            aperturaCierre.fechaAbre = dateAbre
            aperturaCierre.usuarioAbre = results.AperturaCierre.usuarioAbre
            aperturaCierre.montoAbre = results.AperturaCierre.montoAbre
            aperturaCierre.usuarioCierra = results.AperturaCierre.usuarioCierra
            Date dateCierra = new Date(results.AperturaCierre.fechaCierra)
            aperturaCierre.fechaCierra = dateCierra
            aperturaCierre.montoCierra = results.AperturaCierre.montoCierra
            aperturaCierre.save(flush: true)

            resultadoInsertAperturaCierre = "Apertura Cierre registrados exitosamente";

        }

        //Guardar Inventario
        if(results.toString().contains("Inventarios")) {
            for(int x = 1; x< results.Inventarios.size();x++) {
                Inventario inventario = Inventario.get(results.Inventarios[x].idInventario)
                inventario.cantidad = results.Inventarios[x].cantidad
                inventario.save(flush: true)
                resultadoInsertInventarios = results.Inventarios.size().toString()+" inventarios registrados exitosamente";
            }
        }

        //Guardar Ventas
        if(results.toString().contains("Ventas")) {
            for(int x = 1; x< results.Ventas.size();x++) {
                int idVenta = results.Ventas[x].id;
                Venta venta = Venta.findById(idVenta);
                if(!venta){
                    venta = new Venta();
                    venta.id = idVenta
                }
                venta.tipo = results.Ventas[x].tipo
                Date dateCreacion = new Date(results.Ventas[x].fechaCreacion)
                venta.fechaCreacion = dateCreacion
                venta.folio = results.Ventas[x].folio
                venta.subtotal = results.Ventas[x].subtotal
                venta.impuestos = results.Ventas[x].impuestos
                venta.descuento = results.Ventas[x].descuento
                venta.total = results.Ventas[x].total
                venta.saldo = results.Ventas[x].saldo
                venta.formaPago = results.Ventas[x].formaPago
                venta.recibido = results.Ventas[x].recibido
                venta.cambio = results.Ventas[x].cambio
                if(!results.Ventas[x].fechaCancelacion.toString().equals("null")){
                    Date dateCancelacion = new Date(results.Ventas[x].fechaCancelacion)
                    venta.fechaCancelacion = dateCancelacion
                }
                if(!results.Ventas[x].fechaVencimiento.toString().equals("null")){
                    Date fechaVencimiento = new Date(results.Ventas[x].fechaVencimiento)
                    venta.fechaVencimiento = fechaVencimiento
                }
                venta.motivoCancelacion = results.Ventas[x].motivoCancelacion
                Staff staff = Staff.get(results.Ventas[x].staff)
                venta.staff = staff
                if(!results.Ventas[x].staffCancelacion.toString().equals("")){
                    Staff staffCancelacion = Staff.get(results.Ventas[x].staffCancelacion)
                    venta.staffCancelacionId = staffCancelacion
                }
                Cliente cliente = Cliente.get(results.Ventas[x].cliente)
                venta.cliente = cliente
                PuntoVenta puntoVenta = PuntoVenta.get(results.Ventas[x].puntoVenta)
                venta.puntoVenta = puntoVenta
                Empresa empresa = Empresa.get(results.Ventas[x].empresa)
                venta.empresa = empresa

                venta.save(flush: true)

                VentaDetalle ventaDetalle = new VentaDetalle()
                ventaDetalle.venta = venta
                ventaDetalle.listaPrecio = results.Ventas[x].listaPrecioD
                ventaDetalle.cantidadProducto = results.Ventas[x].cantidadProductoD
                ventaDetalle.precioUnitario = results.Ventas[x].precioUnitarioD
                ventaDetalle.impuestoUnitario = results.Ventas[x].impuestoUnitarioD
                ventaDetalle.impuestoTotal = results.Ventas[x].impuestoTotalD
                ventaDetalle.subtotal = results.Ventas[x].subtotalD
                ventaDetalle.total = results.Ventas[x].totalD
                ventaDetalle.descuento = results.Ventas[x].descuentoD
                ventaDetalle.partida = results.Ventas[x].partidaD
                Date dateTimeD = new Date(results.Ventas[x].mFechaHoraD)
                ventaDetalle.mFechaHora = dateTimeD
                ventaDetalle.mUsuario = results.Ventas[x].mUsuarioD
                Producto producto = Producto.get(results.Ventas[x].productoD)
                ventaDetalle.producto = producto

                ventaDetalle.save(flush: true)

                ImpuestoDetalle impuestoDetalle = new ImpuestoDetalle()
                impuestoDetalle.ventaDetalle = VentaDetalle.get(ventaDetalle.id)
                impuestoDetalle.precioBase = results.Ventas[x].precioBaseI
                impuestoDetalle.tasa = results.Ventas[x].tasaI
                impuestoDetalle.importe = results.Ventas[x].importeI
                impuestoDetalle.save(flush: true)

                if(results.Ventas[x].toString().contains("fechaC")){
                    if(results.Ventas[x].toString().contains("montoA")) {
                        Abono abono = new Abono()
                        abono.metodoPago = results.Ventas[x].metodoPagoA
                        abono.referencia = results.Ventas[x].referenciaA
                        abono.monto = results.Ventas[x].montoA
                        abono.save(flush: true)

                        Cobranza cobranza = new Cobranza()
                        Date dateFechaCobranza = new Date(results.Ventas[x].fechaC)
                        cobranza.fecha = dateFechaCobranza
                        cobranza.saldo = results.Ventas[x].saldoC
                        cobranza.saldoAbono = results.Ventas[x].saldoAbonoC
                        cobranza.venta = venta
                        cobranza.abono = abono
                        cobranza.save(flush: true)
                    }

                }

            }
        }

        if(results.toString().contains("Devoluciones")) {
            for (int x = 1; x < results.Devoluciones.size(); x++) {
                Devolucion devolucion = new Devolucion()
                devolucion.tipo = results.Devoluciones[x].tipo
                devolucion.formaPago = results.Devoluciones[x].formaPago
                devolucion.fechaCreacion = new Date(results.Devoluciones[x].fechaCreacion)
                devolucion.folio = results.Devoluciones[x].folio
                devolucion.subtotal = results.Devoluciones[x].subtotal
                devolucion.impuestos = results.Devoluciones[x].impuestos
                devolucion.descuento = results.Devoluciones[x].descuento
                devolucion.total = results.Devoluciones[x].total
                devolucion.saldo = results.Devoluciones[x].saldo
                devolucion.motivo = results.Devoluciones[x].motivo
                devolucion.staff = Staff.findById(results.Devoluciones[x].staff)
                devolucion.cliente = Cliente.findById(results.Devoluciones[x].cliente)
                devolucion.puntoVenta = PuntoVenta.findById(results.Devoluciones[x].puntoVenta)
                devolucion.empresa =  Empresa.findById(results.Devoluciones[x].empresa)
                devolucion.venta = Venta.findById(results.Devoluciones[x].venta)
                devolucion.save(flush: true)

                DevolucionDetalle detalle = new DevolucionDetalle()
                detalle.listaPrecio = results.Devoluciones[x].listaPrecioD
                detalle.cantidadProducto = results.Devoluciones[x].cantidadProductoD
                detalle.precioUnitario = results.Devoluciones[x].precioUnitarioD
                detalle.impuestoUnitario = results.Devoluciones[x].impuestoUnitarioD
                detalle.impuestoTotal = results.Devoluciones[x].impuestoTotalD
                detalle.subtotal = results.Devoluciones[x].subtotalD
                detalle.total = results.Devoluciones[x].totalD
                detalle.descuento = results.Devoluciones[x].descuentoD
                detalle.mFechaHora = new Date(results.Devoluciones[x].mFechaHoraD)
                detalle.mUsuario = results.Devoluciones[x].mUsuarioD
                detalle.devolucion = devolucion
                detalle.producto = Producto.findById(results.Devoluciones[x].productoD)

            }
        }

        render(contentType: 'text/json') {[
                'Resultado CierreCaja': [
                        'Clientes': resultadoInsertCliente,
                        'AperturaCierre':resultadoInsertAperturaCierre,
                        'Inventarios':resultadoInsertInventarios,
                        'Ventas':resultadoInsertVentas
                ]
        ]}


    }

    def ConsultaVentaDevolucion() {
        /*
        URL:http://localhost:8080/ISelling/api/API/ConsultaVentaDevolucion
        Method:PUT
        Headers: Content-type / application-json
        Request:{"empresaId": "2","ventaFolio": "2","puntoVenta":"1"}
        Respond: información de la venta de la que se hara una devolución.
         */
        try {
            def results = request.getJSON()
            def idVenta = results.ventaFolio
            def idPuntoVenta = results.puntoVenta
            def resultsPuntoVenta = PuntoVenta.findAllById(idPuntoVenta)
            Venta resultsVenta = Venta.findByFolioAndPuntoVenta(idVenta, resultsPuntoVenta)
            def resultVentaDetalle = VentaDetalle.findAllByVenta(resultsVenta)

            render(contentType: 'text/json') {
                [
                        'resultsVentaDevolucion': resultsVenta,
                        'resultsVentaDetalle': resultVentaDetalle
                ]
            }
        }catch(Exception ex) {
            println(ex)
        }
    }

}
