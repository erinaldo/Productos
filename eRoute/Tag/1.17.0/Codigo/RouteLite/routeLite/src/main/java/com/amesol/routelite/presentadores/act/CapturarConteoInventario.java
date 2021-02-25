package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ConteoInventario;
import com.amesol.routelite.datos.ConteoInventarioDet;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.Producto;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICambiaProducto;
import com.amesol.routelite.presentadores.interfaces.ICapturaConteoInventario;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class CapturarConteoInventario extends Presentador {

    ConteoInventario conteoInventario;
    ICapturaConteoInventario mVista;
    String mAccion;
    String errorInicial="";

    public CapturarConteoInventario(ICapturaConteoInventario vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }
    @Override
    public void iniciar() {
        try{
            generarConteoInventario();
        }catch (Exception ex){
           errorInicial = ex.getMessage();
        }
    }

    private void generarConteoInventario() throws Exception {
        conteoInventario = new ConteoInventario();
        conteoInventario.ContId = KeyGen.getId();
        conteoInventario.FechaHoraAlta = Generales.getFechaHoraActual();
        conteoInventario.AlmacenID = ((Vendedor)Sesion.get(Sesion.Campo.VendedorActual)).AlmacenID;
        conteoInventario.UsuarioId = ((Usuario)Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
        conteoInventario.TipoFase = 1;
        conteoInventario.MFechaHora = Generales.getFechaHoraActual();
        conteoInventario.MUsuarioID = ((Usuario)Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
        conteoInventario.Enviado = false;
        BDVend.guardarInsertar(conteoInventario);

    }

    public void generarConteoInventarioDet(Producto producto, short tipoUnidad, float cantidad) throws Exception {
        ConteoInventarioDet cid = new ConteoInventarioDet();
        cid.ContDEId = KeyGen.getId();
        cid.ContId = conteoInventario.ContId;
        cid.ProductoClave = producto.ProductoClave;
        cid.TipoUnidad = tipoUnidad;
        cid.BuenEstadoL = 0f;
        cid.MalEstadoL = 0f;
        cid.BuenEstadoF = cantidad;
        cid.MalEstadoF = 0f;
        cid.MFechaHora = Generales.getFechaHoraActual();
        cid.MUsuarioID =  ((Usuario)Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
        cid.Enviado = false;
        conteoInventario.ConteoInventarioDet.add(cid);
        BDVend.guardarInsertar(cid);
    }

    public ConteoInventario getConteoInventario(){
        return conteoInventario;
    }
    public String getErrorInicial(){
        return errorInicial;
    }
}

