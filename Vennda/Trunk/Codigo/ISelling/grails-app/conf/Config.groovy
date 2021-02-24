// locations to search for config files that get merged into the main config;
// config files can be ConfigSlurper scripts, Java properties files, or classes
// in the classpath in ConfigSlurper format

// grails.config.locations = [ "classpath:${appName}-config.properties",
//                             "classpath:${appName}-config.groovy",
//                             "file:${userHome}/.grails/${appName}-config.properties",
//                             "file:${userHome}/.grails/${appName}-config.groovy"]

// if (System.properties["${appName}.config.location"]) {
//    grails.config.locations << "file:" + System.properties["${appName}.config.location"]
// }

grails.project.groupId = appName // change this to alter the default package name and Maven publishing destination

// The ACCEPT header will not be used for content negotiation for user agents containing the following strings (defaults to the 4 major rendering engines)
grails.mime.disable.accept.header.userAgents = ['Gecko', 'WebKit', 'Presto', 'Trident']
grails.mime.types = [ // the first one is the default format
    all:           '*/*', // 'all' maps to '*' or the first available format in withFormat
    atom:          'application/atom+xml',
    css:           'text/css',
    csv:           'text/csv',
    form:          'application/x-www-form-urlencoded',
    html:          ['text/html','application/xhtml+xml'],
    js:            'text/javascript',
    json:          ['application/json', 'text/json'],
    multipartForm: 'multipart/form-data',
    rss:           'application/rss+xml',
    text:          'text/plain',
    hal:           ['application/hal+json','application/hal+xml'],
    xml:           ['text/xml', 'application/xml']
]

// URL Mapping Cache Max Size, defaults to 5000
//grails.urlmapping.cache.maxsize = 1000

// Legacy setting for codec used to encode data with ${}
grails.views.default.codec = "html"

// The default scope for controllers. May be prototype, session or singleton.
// If unspecified, controllers are prototype scoped.
grails.controllers.defaultScope = 'singleton'

// GSP settings
grails {
    views {
        gsp {
            encoding = 'UTF-8'
            htmlcodec = 'xml' // use xml escaping instead of HTML4 escaping
            codecs {
                expression = 'html' // escapes values inside ${}
                scriptlet = 'html' // escapes output from scriptlets in GSPs
                taglib = 'none' // escapes output from taglibs
                staticparts = 'none' // escapes output from static template parts
            }
        }
        // escapes all not-encoded output at final stage of outputting
        // filteringCodecForContentType.'text/html' = 'html'
    }
}


grails.converters.encoding = "UTF-8"
// scaffolding templates configuration
grails.scaffolding.templates.domainSuffix = 'Instance'

// Set to false to use the new Grails 1.2 JSONBuilder in the render method
grails.json.legacy.builder = false
// enabled native2ascii conversion of i18n properties files
grails.enable.native2ascii = true
// packages to include in Spring bean scanning
grails.spring.bean.packages = []
// whether to disable processing of multi part requests
grails.web.disable.multipart=false

// request parameters to mask when logging exceptions
grails.exceptionresolver.params.exclude = ['password']

// configure auto-caching of queries by default (if false you can cache individual queries with 'cache: true')
grails.hibernate.cache.queries = false

// configure passing transaction's read-only attribute to Hibernate session, queries and criterias
// set "singleSession = false" OSIV mode in hibernate configuration after enabling
grails.hibernate.pass.readonly = false
// configure passing read-only to OSIV session by default, requires "singleSession = false" OSIV mode
grails.hibernate.osiv.readonly = false

environments {
    development {
        grails{

            logging.jul.usebridge = true

            mail {
                host = "smtp.gmail.com"
                port = 465
                username = "venndaew@gmail.com"
                password = "Duxstar*123"
                props = ["mail.smtp.auth":"true",
                         "mail.smtp.socketFactory.port":"465",
                         "mail.smtp.socketFactory.class":"javax.net.ssl.SSLSocketFactory",
                         "mail.smtp.socketFactory.fallback":"false"]
            }

        }

    }
    test {
        grails {

            mail {
                host = "smtp.gmail.com"
                port = 465
                username = "venndaew@gmail.com"
                password = "Duxstar*123"
                props = ["mail.smtp.auth":"true",
                         "mail.smtp.socketFactory.port":"465",
                         "mail.smtp.socketFactory.class":"javax.net.ssl.SSLSocketFactory",
                         "mail.smtp.socketFactory.fallback":"false"]
            }
            logging.jul.usebridge = false
            // TODO: serverURL = "http://www.changeme.com"
        }
    }
    production {
        grails {

            mail {
                //TODO configurar cuenta de correo produccion
            }
            logging.jul.usebridge = false
            // TODO: serverURL = "http://www.changeme.com"
        }
    }
}

// log4j configuration
log4j.main = {
    // Example of changing the log pattern for the default console appender:
    //
    //appenders {
    //    console name:'stdout', layout:pattern(conversionPattern: '%c{2} %m%n')
    //}

    error  'org.codehaus.groovy.grails.web.servlet',        // controllers
           'org.codehaus.groovy.grails.web.pages',          // GSP
           'org.codehaus.groovy.grails.web.sitemesh',       // layouts
           'org.codehaus.groovy.grails.web.mapping.filter', // URL mapping
           'org.codehaus.groovy.grails.web.mapping',        // URL mapping
           'org.codehaus.groovy.grails.commons',            // core / classloading
           'org.codehaus.groovy.grails.plugins',            // plugins
           'org.codehaus.groovy.grails.orm.hibernate'//,      // hibernate integration
    //       'org.springframework'
    //       'org.hibernate',
    //       'net.sf.ehcache.hibernate'

    //trace 'org.hibernate.type.descriptor.sql.BasicBinder'
    //debug 'org.hibernate.SQL'
}


// Added by the Spring Security Core plugin:
grails.plugin.springsecurity.userLookup.userDomainClassName = 'mx.elephantworks.iselling.Usuario'
grails.plugin.springsecurity.userLookup.authorityJoinClassName = 'mx.elephantworks.iselling.UsuarioRol'
grails.plugin.springsecurity.userLookup.usernamePropertyName = "username"
grails.plugin.springsecurity.authority.className = 'mx.elephantworks.iselling.Rol'
grails.plugin.springsecurity.ui.register.defaultRoleNames = ['ROLE_USUARIO']
grails.plugin.springsecurity.rememberMe.persistent=false

grails.plugin.springsecurity.logout.postOnly = false
grails.plugin.springsecurity.rejectIfNoRule = true
grails.plugin.springsecurity.fii.rejectPublicInvocations = false
grails.plugin.springsecurity.controllerAnnotations.staticRules = [
//IS_AUTHENTICATED_FULLY
        '/usuarios/resetPassword/**':   ['ROLE_SUPERADMIN','ROLE_EMPRESA','IS_AUTHENTICATED_FULLY'],
//ADMINISTRADOR
        '/monitoring/**':       ['ROLE_SUPERADMIN'],
    //Configuraciones seguridad
        '/registrationCode/**': ['ROLE_SUPERADMIN'],
        '/securityInfo/**':     ['ROLE_SUPERADMIN'],
    //Administraciones de usuarios/roles
        '/user/**':             ['ROLE_SUPERADMIN'],
        '/role/**':             ['ROLE_SUPERADMIN'],
        '/usuarios/**':          ['ROLE_SUPERADMIN'],
    //Administracion de catalogos
        '/impuesto/**':     ['ROLE_SUPERADMIN'],
        '/tipoImpuesto/**':     ['ROLE_SUPERADMIN'],
        '/unidad/**':           ['ROLE_SUPERADMIN'],
        '/descuento/**': ['ROLE_SUPERADMIN'],
        '/plan/**': ['ROLE_SUPERADMIN'],
        '/ajax/addValorImpuestoForm/**':    ['ROLE_SUPERADMIN'],
        '/ajax/removeValorImpuesto/**':    ['ROLE_SUPERADMIN'],
        '/ajax/impuestos/**':    ['ROLE_SUPERADMIN'],

//USUARIO EMPRESA
        '/list.gsp':           ['ROLE_SUPERADMIN','ROLE_EMPRESA'],
        '/cliente/**':          ['ROLE_EMPRESA'],
        '/cobranza/**': ['ROLE_EMPRESA'],
        '/abono/**':['ROLE_EMPRESA'],
        '/categoria/**':        ['ROLE_EMPRESA'],
        '/producto/**':         ['ROLE_EMPRESA'],
        '/producto/productoMasterAjax': ['ROLE_EMPRESA'],
        '/puntoVenta/**': ['ROLE_EMPRESA'],
        '/indicadores/**': ['ROLE_EMPRESA'],
        '/staff/**': ['ROLE_EMPRESA'],
        '/empresa/**':          ['ROLE_EMPRESA'],
        '/inventario/**':          ['ROLE_EMPRESA'],
        '/register/vendedor/**':    ['ROLE_EMPRESA'],
        '/register/registrarVendedor/**':    ['ROLE_EMPRESA'],
        '/ajax/**':    ['ROLE_EMPRESA'],

//CUALQUIER ROL
        '/index':               ['ROLE_SUPERADMIN','ROLE_EMPRESA','ROLE_VENDEDOR'],
//TODOS
        '/':                    ['permitAll'],
        '/assets/**':           ['permitAll'],
        '/**/js/**':            ['permitAll'],
        '/**/css/**':           ['permitAll'],
        '/**/images/**':        ['permitAll'],
        '/**/favicon.ico':      ['permitAll'],
        '/register/**':         ['permitAll'],
        '/**/imgProductos/**':         ['permitAll'],
        '/**/imgCategorias/**':         ['permitAll'],
        '/**/imgLogo/**':         ['permitAll'],
        '/**/plantilla/**':         ['permitAll'],
        '/api/**':          ['permitAll'],

//TEST ONLY, remover para PROD
        '/dbconsole/**':        ['permitAll'],
]

grails.plugin.springsecurity.filterChain.chainMap = [
    '/api/**': 'JOINED_FILTERS,-exceptionTranslationFilter,-authenticationProcessingFilter,-securityContextPersistenceFilter,-rememberMeAuthenticationFilter',  // Stateless chain
    '/**': 'JOINED_FILTERS,-restTokenValidationFilter,-restExceptionTranslationFilter'                                                                          // Traditional chain
]
grails.plugin.springsecurity.rest.token.generation.useUUID = true

grails.gorm.default.constraints = {
    defaultDineroConstraint( scale: 2, max: new BigDecimal("999999999999.999999"))
}