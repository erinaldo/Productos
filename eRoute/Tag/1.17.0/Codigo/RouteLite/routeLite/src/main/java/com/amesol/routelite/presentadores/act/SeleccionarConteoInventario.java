package com.amesol.routelite.presentadores.act;

import android.widget.ListView;

import com.amesol.routelite.R;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.basedatos.SetDatos;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaConteoInventario;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConteoInventario;
import com.amesol.routelite.vistas.generico.PedidosAdapter;

public class SeleccionarConteoInventario extends Presentador {
    ISeleccionConteoInventario mVista;
    String mAccion;

    public SeleccionarConteoInventario(ISeleccionConteoInventario vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }
    @Override
    public void iniciar() {
        try {
            ISetDatos sdConteoInventario = Consultas.ConsultasConteoInventario.obtenerConteoInventario();
            if (sdConteoInventario.getCount() > 0)
            {
                //iniciarActividad = false;
                mVista.mostrarConteosInventario(sdConteoInventario);
            }
            else {
                mVista.iniciarActividadConResultado(ICapturaConteoInventario.class, 0, null);
            }
        }catch(Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
    }

}
