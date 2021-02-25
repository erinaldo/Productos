package com.selling.movil.utilerias;

/**
 * Created by Eduardo on 02/10/15.
 */
public class ValoresEstaticos {

    public static final String DESARROLLO_SERVIDOR = "http://192.168.1.27:8080/api/";
    public static final String TESTING_SERVIDOR = "";
    public static final String PRODUCCION_SERVIDOR = "";


    public static final String PROTOCOLO="http://";
    public static String ACTUAL_SERVIDOR ;

    public static final String PREFERENCES_NAME = "com.selling.movil";
    public static final String PREFERENCES_TOKEN = "token";
    public static final String PREFERENCES_USERNAME = "username";
    public static final String PREFERENCES_COMPANIA_CLAVE = "companiaClave";
    public static final String PREFERENCES_SUCURSAL_CLAVE = "sucursalClave";
    public static final String PREFERENCES_SUCURSAL_NOMBRE = "sucursalNombre";
    public static final String PREFERENCES_SUCURSAL_UBICACION_RECIBO = "sucursalUbicacionRecibo";
    public static final String PREFERENCES_ALMACEN_CLAVE = "almacenClave";
    public static final String PREFERENCES_ALMACEN_NOMBRE = "almacenNombre";
    public static final String PREFERENCES_IP = "ipserver";
    public static final String PREFERENCES_TERMINAL = "terminal";
    public static final String PREFERENCES_MOSTRADOR = "mostrador";
    public static final String PREFERENCES_FIJARUBI = "fijarUbicacion";
    public static final String PREFERENCES_CONTEO = "conteoManual";
    public static final String PREFERENCES_TALLACOLOR = "tallaColor";

    public static final int CONNECTION_TIMEOUT = 2000;

    public static final long REALM_SCHEMA_VERSION = 0;

    public static final String ESTADO_BLOQUEADO = "Bloqueado";
    public static final String ESTADO_DESBLOQUEADO = "Desbloquear";
    public static final String ALMACENAJE_DIRIGIDO = "Dirigido";
    public static final String ALMACENAJE_NO_DIRIGIDO = "No Dirigido";


    public static final String PREFERENCES_TERMINAL_GENERICA = "Genérica";
    public static final String PREFERENCES_TERMINAL_INT_CN51 = "Intermec CN51";

    public static final String PARAMETRO_ALMACEN="ALMClave";
    public static final String PARAMETRO_UBICACION="UBCClave";
    public static final String PARAMETRO_PRODUCTO="PROClave";

    public static final int DIALOG_OPTION_ALMACENAJE = 1;
    public static final int DIALOG_OPTION_SURTIDO = 2;
    public static final int DIALOG_OPTION_UBICACION_ORIGEN = 3;

    public static final int SURTIDO_ESTADO_DISPONIBLE = 1;
    public static final int SURTIDO_ESTADO_ASIGNADO  = 2;
    public static final int SURTIDO_ESTADO_TERMINADO = 3;

    public static final int OPCION_UBICACION_FIJA = 0;
    public static final int OPCION_UBICACION_VARIABLE = 1;

    public static final String ACTIVITY_DEFECTO = "Defecto";
    public static final String ACTIVITY_CONTEO = "Conteo";
    public static final String ACTIVITY_REUBICACION = "Reubicacion";

}
