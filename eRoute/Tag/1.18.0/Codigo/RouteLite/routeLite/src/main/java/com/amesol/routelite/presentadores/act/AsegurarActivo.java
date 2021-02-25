package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Activo;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IAseguraActivo;
import com.amesol.routelite.presentadores.interfaces.ISeleccionVisita;

import java.util.HashMap;
import java.util.Hashtable;
import java.util.Set;

public class AsegurarActivo  extends Presentador {
    IAseguraActivo mVista;
    String mAccion;
    int contador;
    int asignados;
    int asegurados;
    ISetDatos activos;
    String activoClave;

    class ActivoAsegurado{
        String clave;
        boolean asegurado;

        public ActivoAsegurado(String Clave, boolean Asegurado){
            clave = Clave;
            asegurado = Asegurado;
        }
    }

    Hashtable<String, ActivoAsegurado> activosAsegurados;

    public AsegurarActivo(IAseguraActivo vista, String accion)
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
            activos = Consultas2.ConsultasActivos.obtenerActivosAsignados(cliente.ClienteClave);
            asignados = activos.getCount();
            asegurados = 0;
            contador = 1;

            activosAsegurados = new Hashtable<>();
            while(activos.moveToNext()){
                activosAsegurados.put(activos.getString("IdElectronico"), new ActivoAsegurado(activos.getString("ActivoClave"), false));
            }

            mVista.setCliente(cliente.Clave + " - " + cliente.RazonSocial);
            mVista.setRuta(((Ruta) Sesion.get(Sesion.Campo.RutaActual)).Descripcion);
            mVista.setDia(((Dia) Sesion.get(Sesion.Campo.DiaActual)).DiaClave);

            activos.moveToFirst();
            setDatosActivo();
        }
        catch (Exception e)
        {
            mVista.mostrarError(e.getMessage());
        }

    }

    private void setDatosActivo(){
        activoClave = activos.getString("ActivoClave");
        mVista.setActivoClave(activoClave);
        mVista.setNombre(activos.getString("Nombre"));
        mVista.setTipo(ValoresReferencia.getDescripcion("ACITIPO", activos.getString("Tipo")));

        mVista.setContador(String.valueOf(contador) + "/" + String.valueOf(asignados));

    }

    public boolean validarActivo(String idElectronico){
        if (!activosAsegurados.containsKey(idElectronico)){
            mVista.mostrarError(Mensajes.get("E0489").replace("$0$", Mensajes.get("XActivo")));
            return false;
        }
        if (!activosAsegurados.get(idElectronico).clave.equals(activoClave)){
            mVista.mostrarError(Mensajes.get("E0489").replace("$0$", Mensajes.get("XActivo")));
            return false;
        }
        if (activosAsegurados.get(idElectronico).asegurado){
            mVista.mostrarError(Mensajes.get("I0332"));
            return false;
        }
        activosAsegurados.get(idElectronico).asegurado = true;

        return true;
    }

    public void mostrarSiguiente(){
        if (contador < asignados){
            contador++;
            activos.moveToNext();
            setDatosActivo();
        }
        else{
            if (validarAsegurados()){
                mVista.iniciarVisita(asignados, asegurados);
            }else {
                mVista.mostrarError(Mensajes.get("E1001"), 1); //VALIDAR CODIGO DEL MENSAJE
            }
        }
    }

    public boolean validarAsegurados(){
        Set<String> keys = activosAsegurados.keySet();
        for (String idElectronico : keys){
            if (activosAsegurados.get(idElectronico).asegurado)
                asegurados++;
        }
        return (asegurados == asignados);
    }

    public int getAsignados(){
        return asignados;
    }

    public int getAsegurados(){
        return asegurados;
    }

}
