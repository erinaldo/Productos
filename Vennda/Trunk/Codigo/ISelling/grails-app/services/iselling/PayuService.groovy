package iselling

import com.payu.sdk.PayU
import com.payu.sdk.PayUReports
import com.payu.sdk.exceptions.PayUException
import com.payu.sdk.model.Currency
import com.payu.sdk.PayUCustomers
import com.payu.sdk.PayUPayments
import com.payu.sdk.PayUPlans
import com.payu.sdk.model.PaymentCountry
import com.payu.sdk.model.TransactionResponse
import com.payu.sdk.paymentplan.model.Customer
import com.payu.sdk.paymentplan.model.SubscriptionPlan
import grails.transaction.Transactional
import mx.elephantworks.iselling.Empresa
import mx.elephantworks.iselling.Plan

import javax.xml.bind.ValidationException
import java.util.concurrent.ExecutionException

@Transactional
class PayuService {

    def crearCodigo(String nombre){
        def i = 0, codigoValido = false;
        while (!codigoValido) {
            def rand = Math.floor((Math.random() * 900000) + 1000000);
            nombre = nombre.toUpperCase().concat(rand.toString().substring(0,7));
            codigoValido = validarCodigo(nombre);
        }
        return nombre;
    }

    def validarCodigo(String codigo){
        return true
    }

    def crearPlanPAYU(Plan plan){
        PayU.paymentsUrl = "https://sandbox.api.payulatam.com/payments-api/";
        PayU.reportsUrl = "https://sandbox.api.payulatam.com/reports-api/";
        PayU.apiKey = "4Vj8eK4rloUd272L48hsrarnUA"
        PayU.apiLogin = "pRRXKOl8ikMmt9u"
        PayU.merchantId = "508029"
        PayU.isTest = true;

        Map<String, String> parameters = new HashMap<String, String>();
        // Ingresa aquí la descripción del plan
        parameters.put(PayU.PARAMETERS.PLAN_DESCRIPTION, "Basic Plan");
        // Ingresa aquí el código de identificación para el plan
        parameters.put(PayU.PARAMETERS.PLAN_CODE, "ASd456" + System.currentTimeMillis());
        // Ingresa aquí el intervalo del plan
        parameters.put(PayU.PARAMETERS.PLAN_INTERVAL, "MONTH");
        // Ingresa aquí la cantidad de intervalos
        parameters.put(PayU.PARAMETERS.PLAN_INTERVAL_COUNT, "12");
        // Ingresa aquí la moneda para el plan
        parameters.put(PayU.PARAMETERS.PLAN_CURRENCY, "COP");
        // Ingresa aquí el valor del plan
        parameters.put(PayU.PARAMETERS.PLAN_VALUE, "50000");
        //(OPCIONAL) Ingresa aquí el valor del impuesto
        parameters.put(PayU.PARAMETERS.PLAN_TAX, "10000");
        //(OPCIONAL) Ingresa aquí la base de devolución sobre el impuesto
        parameters.put(PayU.PARAMETERS.PLAN_TAX_RETURN_BASE, "40000");
        // Ingresa aquí la cuenta Id del plan
        parameters.put(PayU.PARAMETERS.ACCOUNT_ID, "2");
        // Ingresa aquí el intervalo de reintentos
        parameters.put(PayU.PARAMETERS.PLAN_ATTEMPTS_DELAY, "2");
        // Ingresa aquí la cantidad de cobros que componen el plan
        parameters.put(PayU.PARAMETERS.PLAN_MAX_PAYMENTS, "2");
        SubscriptionPlan response = PayUPlans.create(parameters);

        if(response){
            plan.idPlanPayu = response.id
            plan.save(flush: true)
        }
    }

    def crearClientePAYU(Empresa empresa){

        PayU.paymentsUrl = "https://sandbox.api.payulatam.com/payments-api/";
        PayU.reportsUrl = "https://sandbox.api.payulatam.com/reports-api/";
        PayU.apiKey = "4Vj8eK4rloUd272L48hsrarnUA"
        PayU.apiLogin = "pRRXKOl8ikMmt9u"
        PayU.merchantId = "508029"
        PayU.isTest = true;

        Map<String, String> parameters = new HashMap<String, String>();
        //Ingresa aquí el Nombre del cliente
        parameters.put(PayU.PARAMETERS.CUSTOMER_NAME, "Oscar");
        //Ingresa aquí el E-mail del Cliente
        parameters.put(PayU.PARAMETERS.CUSTOMER_EMAIL, "oscar.romero@payulatam.com");
        //Operación crear el cliente
        Customer response = PayUCustomers.create(parameters);

        if(response){
            empresa.idClientePAYU = response.id
            empresa.save(flush: true)
        }


    }

   /* def crearTarjetaCreditoPAYU(Empresa empresa, Map<String, String> datosTarjeta){

        crearTokenTarjetaPAYU(empresa, datosTarjeta.get("numeroTarjeta"), datosTarjeta.get("fechaVencimiento"), datosTarjeta.get("tipoTarjeta"))
        def nombreCompleto = empresa.nombre +" "+ empresa.apellidoPaterno +" "+empresa.apellidoMaterno

        PayU.paymentsUrl = "https://sandbox.api.payulatam.com/payments-api/";
        PayU.reportsUrl = "https://sandbox.api.payulatam.com/reports-api/";
        PayU.apiKey = "4Vj8eK4rloUd272L48hsrarnUA"
        PayU.apiLogin = "pRRXKOl8ikMmt9u"
        PayU.merchantId = "508029"

        Map<String, String> parameters = new HashMap<String, String>();
        // Ingresa aquí el identificador del pagador.
        parameters.put(PayU.PARAMETERS.CUSTOMER_ID, empresa.idClientePAYU);
        // Ingresa aquí el número de la tarjera.
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_NUMBER, datosTarjeta.get("numeroTarjeta"));
        // Ingresa aquí la fecha de expiración de la tarjeta.
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_EXPIRATION_DATE, datosTarjeta.get("fechaVencimiento"));
        // Ingresa aquí el tipo de la tarjeta.
        parameters.put(PayU.PARAMETERS.PAYMENT_METHOD,  datosTarjeta.get("tipoTarjeta"));
        // Ingresa aquí el nombre del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_NAME, nombreCompleto);
        // Ingresa aquí el documento de identificación asociado a la tarjeta.
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_DOCUMENT, "1020304050");
        // -- Todos los parámetros que siguen son opcionales. --
        // Ingresa aquí la primera parte de la dirección.
        parameters.put(PayU.PARAMETERS.PAYER_STREET, "Calle falsa");
        // Ingresa aquí la segunda parte de la dirección (si aplica).
        parameters.put(PayU.PARAMETERS.PAYER_STREET_2, "123");
        // Ingresa aquí la tercera parte de la dirección (si aplica).
        parameters.put(PayU.PARAMETERS.PAYER_STREET_3, "patio trasero");
        // Ingresa aquí el departamento.
        parameters.put(PayU.PARAMETERS.PAYER_CITY, "Bogotá");
        // Ingresa aquí la ciudad.
        parameters.put(PayU.PARAMETERS.PAYER_STATE, "Bogotá D.C.");
        // Ingresa aquí el país.
        parameters.put(PayU.PARAMETERS.PAYER_COUNTRY, PaymentCountry.CO.name());
        // Ingresa aquí el código postal.
        parameters.put(PayU.PARAMETERS.PAYER_POSTAL_CODE, "00000");
        // Ingresa aquí el teléfono.
        parameters.put(PayU.PARAMETERS.PAYER_PHONE, "300300300");
        CreditCard response = PayUCreditCard.create(parameters);

        if(response){
            empresa.idTarjetaCreditoPAYU = response.
        }



    }*/

   /* def crearTokenTarjetaPAYU(Empresa empresa, String nombreCompleto, String numeroTarjeta, String fechaVencimiento, String tipoTarjeta){
        PayU.paymentsUrl = "https://sandbox.api.payulatam.com/payments-api/";
        PayU.reportsUrl = "https://sandbox.api.payulatam.com/reports-api/";
        PayU.apiKey = "4Vj8eK4rloUd272L48hsrarnUA"
        PayU.apiLogin = "pRRXKOl8ikMmt9u"
        PayU.merchantId = "508029"

        //def nombreCompleto = empresa.nombre +" "+ empresa.apellidoPaterno +" "+empresa.apellidoMaterno

        // -- Operación "Crear Token" --
        Map<String, String> parameters = new HashMap<String, String>();
        //Ingrese aquí el nombre del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_NAME, nombreCompleto);
        //Ingrese aquí el identificador del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_ID, "10");
        //Ingrese aquí el documento de identificación del comprador.
        parameters.put(PayU.PARAMETERS.PAYER_DNI, "32144457");
        //Ingrese aquí el número de la tarjeta de crédito
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_NUMBER, numeroTarjeta);
        //Ingrese aquí la fecha de vencimiento de la tarjeta de crédito
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_EXPIRATION_DATE, fechaVencimiento);
        //Ingrese aquí el nombre de la tarjeta de crédito VISA o MASTERCARD
        parameters.put(PayU.PARAMETERS.PAYMENT_METHOD, tipoTarjeta);
        CreditCardToken response = PayUTokens.create(parameters);

        if(response != null){
            empresa.tokenTarjetaPAYU = response.getTokenId();
            empresa.save(flush: true)
            /*response.getMaskedNumber();
            response.getPayerId();
            response.getIdentificationNumber();
            response.getPaymentMethod();
        }
    }*/

    def crearSubscripcionPAYU(Empresa empresa, String nombreCompleto, String numeroTarjeta, String fechaVencimiento, String tipoTarjeta){

        PayU.paymentsUrl = "https://sandbox.api.payulatam.com/payments-api/";
        PayU.reportsUrl = "https://sandbox.api.payulatam.com/reports-api/";
        PayU.apiKey = "4Vj8eK4rloUd272L48hsrarnUA"
        PayU.apiLogin = "pRRXKOl8ikMmt9u"
        PayU.merchantId = "508029"
        PayU.isTest = true;

        PayU.isTest = true;
        def fecha = new Date()
        String reference = crearCodigo("PAYMENT_REFERENCE_".concat(fecha.format("dd/MM/YYYY").toString().replace("/","_")).concat("_"));
        String value = empresa.plan.precio.toString()
        String id = empresa.id.toString()
        String nombre = empresa.nombre +" "+empresa.apellidoPaterno +" "+empresa.apellidoMaterno

        Map<String, String> parameters = new HashMap<String, String>();

        //Ingrese aquí el identificador de la cuenta.
        parameters.put(PayU.PARAMETERS.ACCOUNT_ID, "512321");
        //Ingrese aquí el código de referencia.
        parameters.put(PayU.PARAMETERS.REFERENCE_CODE, ""+reference);
        //Ingrese aquí la descripción.
        parameters.put(PayU.PARAMETERS.DESCRIPTION, "payment test");
        //Ingrese aquí el idioma de la orden.
        parameters.put(PayU.PARAMETERS.LANGUAGE, "Language.es");

        // -- Valores --
        //Ingrese aquí el valor.
        parameters.put(PayU.PARAMETERS.VALUE, ""+value);
        //Ingrese aquí la moneda.
        parameters.put(PayU.PARAMETERS.CURRENCY, ""+Currency.COP.name());

        // -- Comprador --
        //Ingrese aquí el id del comprador.
        parameters.put(PayU.PARAMETERS.BUYER_ID, id);
        //Ingrese aquí el nombre del comprador.
        parameters.put(PayU.PARAMETERS.BUYER_NAME, nombre);
        //Ingrese aquí el email del comprador.
        parameters.put(PayU.PARAMETERS.BUYER_EMAIL, "buyer_test@test.com");
        //Ingrese aquí el teléfono de contacto del comprador.
        parameters.put(PayU.PARAMETERS.BUYER_CONTACT_PHONE, "7563126");
        //Ingrese aquí el documento de contacto del comprador.
        parameters.put(PayU.PARAMETERS.BUYER_DNI, "5415668464654");
        //Ingrese aquí la dirección del comprador.
        parameters.put(PayU.PARAMETERS.BUYER_STREET, "calle 100");
        parameters.put(PayU.PARAMETERS.BUYER_STREET_2, "5555487");
        parameters.put(PayU.PARAMETERS.BUYER_CITY, "Medellin");
        parameters.put(PayU.PARAMETERS.BUYER_STATE, "Antioquia");
        parameters.put(PayU.PARAMETERS.BUYER_COUNTRY, "CO");
        parameters.put(PayU.PARAMETERS.BUYER_POSTAL_CODE, "000000");
        parameters.put(PayU.PARAMETERS.BUYER_PHONE, "7563126");

        // -- Pagador --
        //Ingrese aquí el id del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_ID, "1");
        //Ingrese aquí el nombre del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_NAME, "APPROVED");
        //Ingrese aquí el email del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_EMAIL, "payer_test@test.com");
        //Ingrese aquí el teléfono de contacto del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_CONTACT_PHONE, "7563126");
        //Ingrese aquí el documento de contacto del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_DNI, "5415668464654");
        //Ingrese aquí la dirección del pagador.
        parameters.put(PayU.PARAMETERS.PAYER_STREET, "calle 93");
        parameters.put(PayU.PARAMETERS.PAYER_STREET_2, "125544");
        parameters.put(PayU.PARAMETERS.PAYER_CITY, "Bogota");
        parameters.put(PayU.PARAMETERS.PAYER_STATE, "Bogota");
        parameters.put(PayU.PARAMETERS.PAYER_COUNTRY, "CO");
        parameters.put(PayU.PARAMETERS.PAYER_POSTAL_CODE, "000000");
        parameters.put(PayU.PARAMETERS.PAYER_PHONE, "7563126");

        // -- Datos de la tarjeta de crédito --
        //Ingrese aquí el número de la tarjeta de crédito
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_NUMBER, numeroTarjeta);
        //Ingrese aquí la fecha de vencimiento de la tarjeta de crédito
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_EXPIRATION_DATE, fechaVencimiento);
        //Ingrese aquí el código de seguridad de la tarjeta de crédito
        parameters.put(PayU.PARAMETERS.CREDIT_CARD_SECURITY_CODE, "321");
        //Ingrese aquí el nombre de la tarjeta de crédito
        parameters.put(PayU.PARAMETERS.PAYMENT_METHOD, tipoTarjeta);

        //Ingrese aquí el número de cuotas.
        parameters.put(PayU.PARAMETERS.INSTALLMENTS_NUMBER, "1");
        //Ingrese aquí el nombre del pais.
        parameters.put(PayU.PARAMETERS.COUNTRY, PaymentCountry.CO.name());

        //Session id del device.
        parameters.put(PayU.PARAMETERS.DEVICE_SESSION_ID, "vghs6tvkcle931686k1900o6e1");
        //IP del pagadador
        parameters.put(PayU.PARAMETERS.IP_ADDRESS, "127.0.0.1");
        //Cookie de la sesión actual.
        parameters.put(PayU.PARAMETERS.COOKIE, "pt1t38347bs6jc9ruv2ecpv7o2");
        //Cookie de la sesión actual.
        parameters.put(PayU.PARAMETERS.USER_AGENT, "Mozilla/5.0 (Windows NT 5.1; rv:18.0) Gecko/20100101 Firefox/18.0");

        //Solicitud de autorización y captura
        TransactionResponse response
        try{
             response = PayUPayments.doAuthorizationAndCapture(parameters);
        }catch(e) {
            // throw new AuthorException("too old", author)
            throw new ValidationException(e.message, "Error")
        }


        //Respuesta
        if(response != null){
            empresa.idTransaccionPAYU = response.getTransactionId()
            empresa.formaPago = 1
            empresa.save(flush: true)

            if(response.getState().toString().equalsIgnoreCase("PENDING")){
                response.getPendingReason();
            }

        }


    }

    def validarPagosTransaccion(String transaccionID){
        //TODO: Cambiar en productivo a vacio
        def respuesta = "APPROVED"

        if(transaccionID){

            Map<String, String> parameters = new HashMap<String, String>();

            //Ingresa aquí el identificador de la transacción.
            parameters.put(PayU.PARAMETERS.TRANSACTION_ID, transaccionID);

            TransactionResponse response = PayUReports.getTransactionResponse(parameters);
            //  -- podrás obtener las propiedades de la respuesta --
            if(response != null){
                respuesta = response.getState();
            }

        }

        return respuesta
    }

}
