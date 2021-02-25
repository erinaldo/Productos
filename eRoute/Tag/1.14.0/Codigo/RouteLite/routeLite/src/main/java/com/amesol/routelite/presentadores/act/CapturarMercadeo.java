package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.MERDetalle;
import com.amesol.routelite.datos.MercadeoMarca;
import com.amesol.routelite.datos.MercadeoProducto;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaMercadeo;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class CapturarMercadeo  extends Presentador {
    ICapturaMercadeo mVista;
    String mAccion;
    String clienteClave;
    String diaClave;
    String visitaClave;

    MERDetalle oMERDetalle = null;

    public CapturarMercadeo(ICapturaMercadeo vista, String accion)
    {
        mVista = vista;
        mAccion = accion;
    }

    @Override
    public void iniciar()
    {
        try
        {
            Cliente cliente = (Cliente) Sesion.get(Sesion.Campo.ClienteActual);

            Dia dia = (Dia) Sesion.get(Sesion.Campo.DiaActual);
            Visita visita = (Visita) Sesion.get(Sesion.Campo.VisitaActual);

            mVista.setCliente(cliente.Clave + " - " + cliente.RazonSocial);
            mVista.setRuta(((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mVista.setDia(((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            diaClave = dia.DiaClave;
            clienteClave = cliente.ClienteClave;
            visitaClave = visita.VisitaClave;

            if (mAccion != null && mAccion.equals(Enumeradores.Acciones.ACCION_MODIFICAR_MERDETALLE)){
                if (!mVista.getMRDId().equals("")){
                    oMERDetalle = new MERDetalle();
                    oMERDetalle.MRDId = mVista.getMRDId();
                    BDVend.recuperar(oMERDetalle);
                    if(oMERDetalle.isRecuperado()) {
                        llenarMERDetalle();
                    }
                }
            }
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }

    }

    public boolean validarCaptura(){
        if(mVista.getMPRId().equals("0")){
            if (mVista.getProducto().trim().equals("")) {
                mVista.mostrarError(Mensajes.get("BE0001", Mensajes.get("XProducto")));
                mVista.setFocus("PRODUCTO");
                return false;
            }
        }
        if(mVista.getMEMId().equals("0")){
            if (mVista.getMarca().trim().equals("")){
                mVista.mostrarError(Mensajes.get("BE0001",Mensajes.get("XMarca")));
                mVista.setFocus("MARCA");
                return false;
            }
        }
        if(mVista.getPresentacion() == 0){
            if (mVista.getPresentacion2().trim().equals("")){
                mVista.mostrarError(Mensajes.get("BE0001",Mensajes.get("MRDPresentacion")));
                mVista.setFocus("PRESENTACION");
                return false;
            }
        }

        if(mVista.getTipo() == 0){
            if (mVista.getTipo2().trim().equals("")){
                mVista.mostrarError(Mensajes.get("BE0001",Mensajes.get("XTipo")));
                mVista.setFocus("TIPO");
                return false;
            }
        }
        if(mVista.getPrecio() == null){
                mVista.mostrarError(Mensajes.get("BE0001",Mensajes.get("XPrecio")));
                mVista.setFocus("PRECIO");
                return false;
        }
        if(mVista.getCantidad() == null){
            mVista.mostrarError(Mensajes.get("BE0001",Mensajes.get("XCantidad")));
            mVista.setFocus("CANTIDAD");
            return false;
        }

        return true;
    }

    public boolean huboCambios(boolean modificando){
        try {
            if (modificando) {
                if (mVista.getPrecio() == null || !mVista.getPrecio().equals(oMERDetalle.Precio)) {
                    return true;
                }
                if ((mVista.getPrecioOferta() == null && oMERDetalle.PrecioOferta != null) || (mVista.getPrecioOferta() != null && oMERDetalle.PrecioOferta == null) || !mVista.getPrecioOferta().equals(oMERDetalle.PrecioOferta)) {
                    return true;
                }
                if (mVista.getVigenciaOferta() != oMERDetalle.FechaVigencia) {
                    return true;
                }
                if (mVista.getCantidad() == null || (!mVista.getCantidad().equals(oMERDetalle.Cantidad))) {
                    return true;
                }
                if (!(mVista.getNotas() == null ? "" : mVista.getNotas()).equals((oMERDetalle.Notas == null ? "" : oMERDetalle.Notas))) {
                    return true;
                }
            } else {
                if (!mVista.getMPRId().equals("0")) {
                    return true;
                }
                if (!mVista.getProducto().trim().equals("") && mVista.getProducto().trim().length() > 0) {
                    return true;
                }
                if (!mVista.getMEMId().equals("0")) {
                    return true;
                }
                if (!mVista.getMarca().trim().equals("") && mVista.getMarca().trim().length() > 0) {
                    return true;
                }
                if (mVista.getPresentacion() != 0) {
                    return true;
                }
                if (!mVista.getPresentacion2().trim().equals("") && mVista.getPresentacion2().trim().length() > 0) {
                    return true;
                }
                if (mVista.getTipo() != 0) {
                    return true;
                }
                if (!mVista.getTipo2().trim().equals("") && mVista.getTipo2().trim().length() > 0) {
                    return true;
                }
                if (mVista.getPrecio() != null) {
                    return true;
                }
                if (mVista.getPrecioOferta() != null) {
                    return true;
                }
                if (mVista.getVigenciaOferta() != null) {
                    return true;
                }
                if (mVista.getCantidad() != null) {
                    return true;
                }
                if (mVista.getNotas() != null && mVista.getNotas().trim().length() > 0) {
                    return true;
                }
            }
        }catch(Exception ex){
            return false;
        }

        return false;
    }

    public String generarMercadeoProducto(String producto){
        MercadeoProducto MPR = null;
        try {

            MPR = Consultas.ConsultasMercadeo.recuperarMercadeoProducto(producto);
            if (MPR == null){
                MPR = new MercadeoProducto();
                MPR.MPRId = KeyGen.getId();
                MPR.Producto = producto;
                MPR.Estado = 1;
                MPR.MFechaHora = Generales.getFechaHoraActual();
                MPR.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                MPR.Enviado = false;
                BDVend.guardarInsertar(MPR);
            }
        }catch(Exception ex){
            if (ex != null && ex.getMessage() != null) {
                mVista.mostrarError(ex.getMessage());
            }else{
                mVista.mostrarError("Error al dar de alta el producto");
            }
        }
        return MPR.MPRId;
    }

    public String generarMercadeoMarca(String marca){
        MercadeoMarca MEM = null;
        try {
            MEM = Consultas.ConsultasMercadeo.recuperarMercadeoMarca(marca);
            if (MEM == null) {
                MEM = new MercadeoMarca();
                MEM.MEMId = KeyGen.getId();
                MEM.Marca = marca;
                MEM.Estado = 1;
                MEM.MFechaHora = Generales.getFechaHoraActual();
                MEM.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
                MEM.Enviado = false;
                BDVend.guardarInsertar(MEM);
            }
        }catch (Exception ex){
            if (ex != null && ex.getMessage() != null) {
                mVista.mostrarError(ex.getMessage());
            }else{
                mVista.mostrarError("Error al dar de alta la marca");
            }
        }
        return MEM.MEMId;
    }

    public String generarMERDetalle(String MPRId, String MEMId){
        MERDetalle MRD = new MERDetalle();
        try {
            MRD.MRDId = KeyGen.getId();
            MRD.MPRId = MPRId;
            MRD.MEMId = MEMId;
            MRD.VisitaClave = ((Visita) Sesion.get(Sesion.Campo.VisitaActual)).VisitaClave;
            MRD.DiaClave = ((Visita) Sesion.get(Sesion.Campo.VisitaActual)).DiaClave;
            MRD.ClienteClave= ((Visita) Sesion.get(Sesion.Campo.VisitaActual)).ClienteClave;
            if (mVista.getTipo() != 0) {
                MRD.Tipo = ValoresReferencia.getDescripcion("MRDTIPO",String.valueOf(mVista.getTipo()));
            }else{
                MRD.Tipo = mVista.getTipo2();
            }

            if ( mVista.getPresentacion() != 0) {
                MRD.Presentacion = ValoresReferencia.getDescripcion("MRDPRES", String.valueOf(mVista.getPresentacion()));
            }else{
                MRD.Presentacion = mVista.getPresentacion2();
            }

            MRD.Precio = mVista.getPrecio();
            if (mVista.getPrecioOferta() != null && mVista.getPrecioOferta() > 0 ) {
                MRD.PrecioOferta = mVista.getPrecioOferta();
            }

            MRD.Cantidad = mVista.getCantidad();

            if (mVista.getVigenciaOferta() != null){
                MRD.FechaVigencia = mVista.getVigenciaOferta();
            }
            if (mVista.getNotas()!= null &&  mVista.getNotas().length()>0) {
                MRD.Notas = mVista.getNotas();
            }
            MRD.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
            MRD.MFechaHora = Generales.getFechaHoraActual();
            MRD.Enviado = false;

            BDVend.guardarInsertar(MRD);

            return MRD.MRDId;
        }catch (Exception ex){
            if (ex != null && ex.getMessage() != null) {
                mVista.mostrarError(ex.getMessage());
            }else{
                mVista.mostrarError("Error al dar de alta la marca");
            }
        }
        return null;
    }

    public String modificarMERDetalle(String MPRId, String MEMId){
        try {
            oMERDetalle.MPRId = MPRId;
            oMERDetalle.MEMId = MEMId;

            if (mVista.getTipo() != 0) {
                oMERDetalle.Tipo = ValoresReferencia.getDescripcion("MRDTIPO",String.valueOf(mVista.getTipo()));
            }else{
                oMERDetalle.Tipo = mVista.getTipo2();
            }

            if ( mVista.getPresentacion() != 0) {
                oMERDetalle.Presentacion = ValoresReferencia.getDescripcion("MRDPRES", String.valueOf(mVista.getPresentacion()));
            }else{
                oMERDetalle.Presentacion = mVista.getPresentacion2();
            }

            oMERDetalle.Precio = mVista.getPrecio();
            if (mVista.getPrecioOferta() != null && mVista.getPrecioOferta() > 0 ) {
                oMERDetalle.PrecioOferta = mVista.getPrecioOferta();
            }

            oMERDetalle.Cantidad = mVista.getCantidad();

            if (mVista.getVigenciaOferta() != null){
                oMERDetalle.FechaVigencia = mVista.getVigenciaOferta();
            }
            if (mVista.getNotas()!= null && mVista.getNotas().length()>0) {
                oMERDetalle.Notas = mVista.getNotas();
            }
            oMERDetalle.MUsuarioID = ((Usuario) Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
            oMERDetalle.MFechaHora = Generales.getFechaHoraActual();
            oMERDetalle.Enviado = false;

            BDVend.guardarInsertar(oMERDetalle);

            return oMERDetalle.MRDId;
        }catch (Exception ex){
            if (ex != null && ex.getMessage() != null) {
                mVista.mostrarError(ex.getMessage());
            }else{
                mVista.mostrarError("Error al dar de alta la marca");
            }
        }
        return null;
    }

    public boolean grabarMercadeo(){
        try {
            if (validarCaptura()) {
                String sMPRId = null;
                String sMEMId = null;
                if (mVista.getMPRId().equals("0")) {

                    sMPRId = generarMercadeoProducto(mVista.getProducto());
                } else {
                    sMPRId = mVista.getMPRId();
                }
                if (mVista.getMEMId().equals("0")) {
                    sMEMId =generarMercadeoMarca(mVista.getMarca());
                } else {
                    sMEMId = mVista.getMEMId();
                }
                if (sMPRId == null || sMEMId == null || sMPRId.equals("") || sMEMId.equals("")){
                    return false;
                }
                if (oMERDetalle != null){
                    if(modificarMERDetalle(sMPRId, sMEMId) == null){
                        return false;
                    }
                }else {
                    if (generarMERDetalle(sMPRId, sMEMId) == null) {
                        return false;
                    }
                }

                BDVend.commit();
                return true;
            }

        }catch(Exception ex){
            if (ex != null && ex.getMessage() != null) {
                mVista.mostrarError(ex.getMessage());
            }else{
                mVista.mostrarError("Error al guardar el Mercadeo");
            }
        }
        return false;
    }

    private void llenarMERDetalle(){
        mVista.setMPRId(oMERDetalle.MPRId);
        mVista.setMEMId(oMERDetalle.MEMId);
        mVista.setPresentacion(oMERDetalle.Presentacion);
        mVista.setTipo(oMERDetalle.Tipo);
        mVista.setCantidad(oMERDetalle.Cantidad);
        mVista.setPrecio(oMERDetalle.Precio);
        if (oMERDetalle.PrecioOferta != null){
            mVista.setPrecioOferta(oMERDetalle.PrecioOferta);
        }
        if (oMERDetalle.FechaVigencia != null){
            mVista.setVigenciaOferta(oMERDetalle.FechaVigencia);
        }
        if (oMERDetalle.Notas != null && !oMERDetalle.Notas.equals("")){
            mVista.setNotas(oMERDetalle.Notas);
        }
    }
}
