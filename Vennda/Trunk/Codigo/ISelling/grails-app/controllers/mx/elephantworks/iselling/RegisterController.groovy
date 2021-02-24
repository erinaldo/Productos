package mx.elephantworks.iselling

import com.payu.sdk.PayU
import com.payu.sdk.PayUPayments
import com.payu.sdk.model.PaymentCountry
import com.payu.sdk.model.TransactionResponse
import com.payu.sdk.model.TransactionState
import com.payu.sdk.model.Currency
import grails.plugin.springsecurity.SpringSecurityUtils
import grails.plugin.springsecurity.authentication.dao.NullSaltSource
import grails.plugin.springsecurity.ui.RegistrationCode

class RegisterController extends grails.plugin.springsecurity.ui.RegisterController {
    def payuService

    def index() {
        def copy = [:] + (flash.chainedParams ?: [:])
        copy.remove 'controller'
        copy.remove 'action'
        [command: new RegisterCommand(copy)]
    }

    def register(RegisterCommand command) {

        if (command.hasErrors()) {
            render view: 'index', model: [command: command]
            return
        }

        String salt = saltSource instanceof NullSaltSource ? null : command.username
        def user = Empresa.newInstance()
        bindData(user,command)

        if (user.hasErrors()) {
            render view: 'index', model: [command: user]
            return
        }

        RegistrationCode registrationCode = springSecurityUiService.register(user, command.password, salt)
        if (registrationCode == null || registrationCode.hasErrors()) {
            // null means problem creating the user
            flash.error = message(code: 'spring.security.ui.register.miscError')
            flash.chainedParams = params
            redirect action: 'index'
            return
        }

        Rol rolEmpresa = Rol.findByAuthority("ROLE_EMPRESA")
        if(null != user && null != rolEmpresa)
            UsuarioRol.create(user,rolEmpresa,true)

        String url = generateLink('verifyRegistration', [t: registrationCode.token])

        def conf = SpringSecurityUtils.securityConfig
       /* def body = conf.ui.register.emailBody
        if (body.contains('$')) {
            body = evaluate(body, [user: user, url: url])
        }*/
        mailService.sendMail {
            to command.username
            from conf.ui.register.emailFrom
            subject message(code: 'registro.correoActivacion.label', default: 'Activación de la cuenta')
            html g.render(template: 'correoActivacion', model: [url: url])
        }

        //payuService.crearClientePAYU(user)

        redirect action: 'escogerPlan', id: user.id

       // render view: 'index', model: [emailSent: true]
    }

    def forgotPassword() {

        if (!request.post) {
            // show the form
            return
        }

        String username = params.username
        if (!username) {
            flash.error = "Es necesario llenar todos los campos."
            redirect action: 'forgotPassword'
            return
        }

        String usernameFieldName = SpringSecurityUtils.securityConfig.userLookup.usernamePropertyName
        def user = lookupUserClass().findWhere((usernameFieldName): username)
        if (!user) {
            flash.error = "El usuario no existe."
            redirect action: 'forgotPassword'
            return
        }

        def registrationCode = new RegistrationCode(username: user."$usernameFieldName")
        registrationCode.save(flush: true)

        String url = generateLink('resetPassword', [t: registrationCode.token])

        def conf = SpringSecurityUtils.securityConfig
        def body = conf.ui.forgotPassword.emailBody
        if (body.contains('$')) {
            body = evaluate(body, [user: user, url: url])
        }
        mailService.sendMail {
            to user.username
            from conf.ui.forgotPassword.emailFrom
            subject  message(code: 'registro.recuperarContrasena.label', default: 'Recuperar Contraseña')
            html g.render(template: 'correoContrasena', model:[url: url])
        }

        [emailSent: true]
    }

    def vendedor(){
        def copy = [:] + (flash.chainedParams ?: [:])
        copy.remove 'controller'
        copy.remove 'action'
        [command: new RegisterVendedorCommand(copy)]
    }

    def registrarVendedor(RegisterVendedorCommand command) {

        if (command.hasErrors()) {
            render view: 'vendedor', model: [command: command]
            return
        }

        String salt = saltSource instanceof NullSaltSource ? null : command.username
        def user = Vendedor.newInstance()
        bindData(user,command)

        if (user.hasErrors()) {
            render view: 'vendedor', model: [command: user]
            return
        }

        String password = UUID.randomUUID().toString();
        RegistrationCode registrationCode = springSecurityUiService.register(user, password, salt)
        if (registrationCode == null || registrationCode.hasErrors()) {
            // null means problem creating the user
            flash.error = message(code: 'spring.security.ui.register.miscError')
            flash.chainedParams = params
            redirect action: 'registrarVendedor'
            return
        }

        String url = generateLink('verifyRegistrationVendedor', [t: registrationCode.token])

        def conf = SpringSecurityUtils.securityConfig
        def body = conf.ui.register.emailBody
        if (body.contains('$')) {
            body = evaluate(body, [user: user, url: url])
        }
        mailService.sendMail {
            to command.username
            from conf.ui.register.emailFrom
            subject conf.ui.register.emailSubject
            html body.toString()
        }

        render view: 'vendedor', model: [emailSent: true]
    }

    def verifyRegistrationVendedor(grails.plugin.springsecurity.ui.ResetPasswordCommand command) {

        def conf = SpringSecurityUtils.securityConfig
        String defaultTargetUrl = conf.successHandler.defaultTargetUrl

        String token = params.t

        def registrationCode = token ? RegistrationCode.findByToken(token) : null
        if (!registrationCode) {
            flash.error = message(code: 'spring.security.ui.register.badCode')
            redirect uri: defaultTargetUrl
            return
        }

        if (!request.post) {
            return [token: token, command: new ResetPasswordCommand()]
        }

        command.username = registrationCode.username
        command.validate()

        if (command.hasErrors()) {
            return [token: token, command: command]
        }

        def user
        String salt = saltSource instanceof NullSaltSource ? null : registrationCode.username
        RegistrationCode.withTransaction { status ->
            String usernameFieldName = "username"
            user = Vendedor.findWhere((usernameFieldName): command.username)
            if (!user) {
                log.error("NO USER FOUND!")
                return
            }
            user.accountLocked = false
            user.password = springSecurityUiService.encodePassword(command.password, salt)
            user.save(flush: true)
            Rol rolVendedor = Rol.findByAuthority("ROLE_VENDEDOR")
            UsuarioRol.create(user,rolVendedor,true)

            registrationCode.delete()
        }

        if (!user) {
            flash.error = message(code: 'spring.security.ui.register.badCode')
            redirect uri: defaultTargetUrl
            return
        }

        springSecurityService.reauthenticate user.username

        flash.message = message(code: 'spring.security.ui.register.complete')
        redirect uri: conf.ui.register.postRegisterUrl ?: defaultTargetUrl
    }

    def escogerPlan(Empresa empresaInstance){
        if(!empresaInstance.plan){
            def planes = Plan.findAll()
            respond empresaInstance, model: [planes: planes]
        }else {
            redirect(controller: 'login', action: 'auth')
        }

    }

    def guardarPlan(Empresa empresaInstance){

        def id = params.idPlan
        Plan planInstance = Plan.get(id as Long)

        if(planInstance){
            if(empresaInstance){
                empresaInstance.plan = planInstance
                empresaInstance.save(flush: true)
                if(planInstance.precio == 0.00){
                    render view: 'index', model: [emailSent: true]
                }else {
                    redirect action: 'escogerFormaPago', id: empresaInstance.id
                }
            }else{
                redirect action: 'escogerPlan', id: empresaInstance.id
            }
        }else{
            redirect action: 'escogerPlan', id: empresaInstance.id
        }

    }

    def escogerFormaPago(Empresa empresaInstance){
        if(empresaInstance.formaPago <= 0 || empresaInstance.formaPago == null) {
            respond empresaInstance
        }else {
            redirect(controller: 'login', action: 'auth')
        }

    }

    def pagoEfectivo(Empresa empresaInstance){

        if(empresaInstance.formaPago <= 0 || empresaInstance.formaPago == null){
            PayU.paymentsUrl = "https://sandbox.api.payulatam.com/payments-api/";
            PayU.reportsUrl = "https://sandbox.api.payulatam.com/reports-api/";
            PayU.apiKey = "4Vj8eK4rloUd272L48hsrarnUA"
            PayU.apiLogin = "pRRXKOl8ikMmt9u"
            PayU.merchantId = "508029"

            //datos
            String reference, metodo = params.metodoPago, url
            def fecha = new Date()
            reference = payuService.crearCodigo(metodo + "_REFERENCE_".concat(fecha.format("dd/MM/YYYY").toString().replace("/","_")).concat("_"))
            def nombrePagador = empresaInstance.nombre + " " + empresaInstance.apellidoPaterno
            String precioPlan= empresaInstance.plan.precio.toString(); //Valor del servicio
            Calendar calendar = Calendar.getInstance();
            calendar.setTime(new Date()); // Configuramos la fecha que se recibe
            calendar.add(Calendar.DAY_OF_YEAR, 1);
            def ano = Integer.toString(calendar.get(Calendar.YEAR));
            def mes = Integer.toString(calendar.get(Calendar.MONTH) + 1);
            def dia = Integer.toString(calendar.get(Calendar.DAY_OF_MONTH));
            def fechaExpiracion = ano +"-"+ mes +"-" +dia+"T00:00:00"
            def planCompra = "Servicio de Vennda, Plan: "+empresaInstance.plan.identificador


            //para realizar un pago en efectivo ---------------------------------
            Map<String, String> parameters = new HashMap<String, String>();
            //Ingrese aquí el identificador de la cuenta.
            parameters.put(PayU.PARAMETERS.ACCOUNT_ID, "512324");
            //Ingrese aquí el código de referencia.
            parameters.put(PayU.PARAMETERS.REFERENCE_CODE, ""+reference);
            //Ingrese aquí la descripción.
            parameters.put(PayU.PARAMETERS.DESCRIPTION, planCompra);
            //Ingrese aquí el idima de la orden.
            parameters.put(PayU.PARAMETERS.LANGUAGE, "Language.es");

            // -- Valores --
            //Ingrese aquí el valor.
            parameters.put(PayU.PARAMETERS.VALUE, ""+precioPlan);
            //Ingrese aquí la moneda.
            parameters.put(PayU.PARAMETERS.CURRENCY, ""+Currency.MXN.name());

            //Ingrese aquí el email del comprador.
            parameters.put(PayU.PARAMETERS.BUYER_EMAIL, "vennda@test.com");

            //Ingrese aquí el nombre del pagador.
            parameters.put(PayU.PARAMETERS.PAYER_NAME, nombrePagador);

            //Ingrese aquí el nombre del medio de pago en efectivo
            parameters.put(PayU.PARAMETERS.PAYMENT_METHOD, metodo); //or SEVEN_ELEVEN or SCOTIABANK or SANTANDER or BANCOMER or OTHERS_CASH_MX

            //DNI
            parameters.put(PayU.PARAMETERS.PAYER_DNI, "1234568")

            //Ingrese aquí el nombre del pais.
            parameters.put(PayU.PARAMETERS.COUNTRY, PaymentCountry.MX.name());

            //Ingrese aquí la fecha de expiración. Sólo para OXXO y SEVEN_ELEVEN

            parameters.put(PayU.PARAMETERS.EXPIRATION_DATE, fechaExpiracion);

            //IP del pagadador
            parameters.put(PayU.PARAMETERS.IP_ADDRESS, "127.0.0.1");

            //Solicitud de autorización y captura
            TransactionResponse response = PayUPayments.doAuthorizationAndCapture(parameters)

            //Respuesta
            if(response != null){

                //asignamos la forma de pago que eligio
                empresaInstance.formaPago = 2
                empresaInstance.idTransaccionPAYU = response.getTransactionId()


                if(response.getState().equals(TransactionState.PENDING)){
                    response.getPendingReason();
                    Map extraParameters = response.getExtraParameters();

                    //obtener la url del comprobante de pago
                    url=(String)extraParameters.get("URL_PAYMENT_RECEIPT_HTML");
                    //guardamos la url por si se quiere sacar de nuevo el comprobante
                    empresaInstance.urlPagoEfectivoPAYU = url
                }
                empresaInstance.save(flush: true)

            }

            redirect(url: url)

        }else{
            redirect(controller: 'login', action: 'auth')
        }

    }

    def pagoTarjeta(Empresa empresaInstance){

        String nombreCompleto = params.nombreCompleto
        String numeroTarjeta = params.numeroTarjeta
        String fechaVencimiento = params.ano +"/"+params.mes
        String tipoTarjeta = params.tipoTarjeta

       // payuService.crearTokenTarjetaPAYU(empresaInstance, nombreCompleto, numeroTarjeta, fechaVencimiento, tipoTarjeta)


        try {
            payuService.crearSubscripcionPAYU(empresaInstance, nombreCompleto, numeroTarjeta, fechaVencimiento, tipoTarjeta)
        }
        catch(e) {
            flash.error = e.message
            redirect action: 'escogerFormaPago', id: empresaInstance.id
        }

        render view: 'index', model: [emailSent: true]
    }


}

class RegisterCommand extends grails.plugin.springsecurity.ui.RegisterCommand{

    String username2

    Boolean accountLocked = true
    Boolean enabled = true

    //Datos de la empresa
    String nombreEmpresa
    String direccion
    String cp
    String colonia
    String ciudad
    String estado
    String rfc

    //Datos del dueño
    String nombre
    String apellidoPaterno
    String apellidoMaterno
    String curp
    String pin

    Boolean baja = false

    TipoCuenta tipoCuenta

    def grailsApplication

    static constraints = {
        importFrom Empresa
        email blank: true, nullable: true
        password2 blank: true, nullable: true, validator: null
        username2 validator: { val, command ->
            if (command.username != command.username2) {
                return 'command.email2.error.mismatch'
            }
        }
        pin nullable: false, blank: false, maxSize: 4, minSize: 4
        estado nullable: true, blank: true
    }
}

class RegisterVendedorCommand {
    String username
    Boolean accountLocked = true
    Boolean enabled = true

    //Datos del Vendedor
    String nombre
    String apellidoPaterno
    String apellidoMaterno
    Float porcentajeMaxDescuento
    Empresa empresa

    def grailsApplication

    static constraints = {
        importFrom Vendedor
        username blank: false, validator: { value, command ->
            if (value) {
                def User = command.grailsApplication.getDomainClass(
                        SpringSecurityUtils.securityConfig.userLookup.userDomainClassName).clazz
                if (User.findByUsername(value)) {
                    return 'registerCommand.username.unique'
                }
            }
        }
    }
}