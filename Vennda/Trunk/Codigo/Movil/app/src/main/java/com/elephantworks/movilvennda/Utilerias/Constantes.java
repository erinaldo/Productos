package com.elephantworks.movilvennda.Utilerias;

/**
 * Created by ldelatorre on 29/05/2017.
 */
public class Constantes {

    public static final int SPLASH_SHOW_TIME = 2000;
    public static final long REALM_BD_VERSION = 0;

    public final class TipoAplicaionImpusto
    {
        public final static int PORCENTAJE = 1;
        public final static int IMPORTE = 2;
    }

    public final class TipoCliente
    {
        public final static int WEB = 1;
        public final static int MOVIL = 2;
        public final static String STRWEB = "WEB";
        public final static String STRMOVIL = "MOVIL";
    }

    public final class TipoVenta
    {
        public final static int AMBAS = 0;
        public final static int CONTADO = 1;
        public final static int CREDITO = 2;
        public final static int DEVOLUCION = 3;
    }

    public final class TodasCategorias
    {
        public final static int TODAS_CATEGORIAS = 0;
    }

    public final class TipoAplicacionImp
    {
        public final static int PORCENTAJE = 1;
        public final static int IMPORTE = 2;
    }

    public final class BillPocket
    {
        public final static int CREDIT_CARD_INTENT = 1000;

    }

    public final class FormaPago
    {
        public final static int EFECTIVO = 1;
        public final static int TARJETA = 2;
    }
}
