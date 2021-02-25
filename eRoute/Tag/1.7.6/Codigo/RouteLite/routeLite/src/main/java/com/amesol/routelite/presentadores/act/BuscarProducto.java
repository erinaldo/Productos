package com.amesol.routelite.presentadores.act;


import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.TiposTransProd;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IBuscaProducto;

public class BuscarProducto extends Presentador {

    IBuscaProducto mVista;
    String mAccion;
    //HashMap<String, Object> oParametros;

    public BuscarProducto(IBuscaProducto vista, String accion) {
        mVista = vista;
        mAccion = accion;
        //oParametros = new HashMap<String, Object>();
    }

    @Override
    public void iniciar() {
        try {
            mVista.iniciar();
            if (mVista.obtenerProductos() != null) {
                mVista.mostrarProductos(mVista.obtenerProductos());
            }
        } catch (Exception e) {
            mVista.mostrarError(e.getMessage());
        }
    }

    public boolean validarCantMax(float cantidad, int tipoTransProd) {
        MOTConfiguracion oMot = ((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion));
        if (Integer.parseInt(oMot.get("CantidadMaxProd").toString()) > 0 && (tipoTransProd == TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.MOV_SIN_INV_EV)) { //solo se valida para los pedidos y msiev
            if (cantidad > Integer.parseInt(oMot.get("CantidadMaxProd").toString())) {
                mVista.mostrarPreguntaSiNo(Mensajes.get("P0245").replace("$0$", oMot.get("CantidadMaxProd").toString()), 30);
                return true;
            }
        }
        return false;
    }

    public boolean validarMultiplo(String productoClave,float cantidad, int tipoTransProd) {
        if (tipoTransProd == Enumeradores.TiposTransProd.PEDIDO || tipoTransProd == TiposTransProd.MOV_SIN_INV_EV) {
            try {
                if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarVtaMultiplo").length() > 0) {
                    if (((ConfigParametro) Sesion.get(Campo.ConfigParametro)).get("ValidarVtaMultiplo").equals("1")) {
                        float cantidadProduccion = Consultas.ConsultasProducto.obtenerCantidadProduccion(productoClave);
                        if (cantidadProduccion > 0) {
                            if ((cantidad % cantidadProduccion) != 0) {
                                mVista.mostrarError(Mensajes.get("E0935", String.valueOf(cantidadProduccion)),50);
                                return false;
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                mVista.mostrarError(ex.getMessage(), 50);
                return false;
            }
        }
        return true;
    }
/*	public void setParametros(	HashMap<String, Object> parametros)
	{
		oParametros=parametros;
	}
*/
}
