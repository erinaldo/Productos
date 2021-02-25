package com.amesol.routelite.presentadores.act;

import java.util.Date;
import java.util.HashMap;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Clientes;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.ICapturaLiquidacionConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;

/**
 * Clase controlador para la actividad de seleccion de consignaciones.
 * @author agonzalez bioxor
 *
 */

public class SeleccionarConsignacion extends Presentador
{

	/**
	 * Clase interna para empaquetar los datos de TransProd utiles para
	 * la actividad
	 * @author agonzalez bioxor
	 *
	 */

	public static String TransprodConsig;
	public static boolean ConsigFact;

	public static class VistaConsignacion{
		public String TransProdId;
		public String VisitaClave;
		public String Folio;
		public String DiaClave;
		public String Fase;
		public int Tipo;
		public int Tipofase;
		public boolean Enviado;
		public Date FechaCreacion;
		public float Total;
		public float Saldo;
		
		public VistaConsignacion()
		{}
		
	}
	
	private String mAccion;
	private ISeleccionConsignacion mVista;
	private boolean consignacionActivo;
	
	public SeleccionarConsignacion(ISeleccionConsignacion vista, String accion)
	{
		mAccion = accion;
		mVista = vista;
	}
	
	@Override
	public void iniciar()
	{
		ValorReferencia valor = ValoresReferencia.getValor("TRPMOT", "12");
		if(valor != null){
			if("Consignacion".equalsIgnoreCase(valor.getGrupo())){
				consignacionActivo = true;
			}
		}
		mVista.iniciar();
	}

	/**
	 * Obtiene un arreglo con las TransProd de tipo consignacion para el cliente especificado.
	 * @param cliente referencia del cliente al que pertenecen las consignaciones a
	 * retornar
	 * @return Arreglo de VistaConsignacion con las consignaciones del cliente
	 */
	public SeleccionarConsignacion.VistaConsignacion [] obtenerConsignaciones(Cliente cliente)
	{
		SeleccionarConsignacion.VistaConsignacion [] consignaciones = null;
		try{
			consignaciones = Consultas.ConsultasTransProd.obtenerConsignacionesPorCliente(cliente);
			return consignaciones;
		}catch(Exception e){
			//TODO Aqui que se procede
			return new SeleccionarConsignacion.VistaConsignacion[]{};
		}
		
	}
	
	/**
	 * Valida las acciones del context menu que aparece en el long click a las consignaciones.
	 * @param idAccion accion a realizar, puede ser eliminar, modificar y liquidar
	 * @throws Exception lanza la excepcion en el caso de que la accion no pueda ser
	 * efectuada.
	 */
	public void validarAccion(int idAccion) throws Exception{
		VistaConsignacion vistaConsignacion = (VistaConsignacion) Sesion.get(Campo.VistaConsignacion);
		boolean modificar = idAccion == R.id.modificar;
		boolean liquidar = idAccion == R.id.cancelar;
		boolean exit = true;
		float sumTotalTrpTpd = 0f;
		if(!liquidar){
			try{
				sumTotalTrpTpd = Consultas.ConsultasTrpTpd.obtenerSumatoriaTotalPorTransProdId(vistaConsignacion.TransProdId, "TransProdID1");
				sumTotalTrpTpd = sumTotalTrpTpd + vistaConsignacion.Saldo;
			}catch (Exception e) {
				
			}
		}
		boolean estaLiquidada = vistaConsignacion.Tipofase == Enumeradores.TiposFasesDocto.LIQUIDADO || 
				vistaConsignacion.Tipofase == Enumeradores.TiposFasesDocto.CANCELADA_LIQUIDACION;
		
		if(estaLiquidada)
		{
			if(liquidar)
			{
				throw new ControlError("E0689", Mensajes.get("XLiquidar"));
			}
			else if(modificar)
			{
				if(1 == Integer.parseInt((String)((CONHist)Sesion.get(Campo.CONHist)).get("CancConsigLiqui")))
				{
					throw new ControlError("E0689", Mensajes.get("XModificar"));
				}else
				{
					ejecutaModificacionLiquidacion();
					exit = false;
				}
			}else
			{
				throw new ControlError("E0689", Mensajes.get("XEliminar"));
			}
		}else if(!liquidar)
		{
			if(Float.valueOf(Generales.getRound(vistaConsignacion.Total, 2)).compareTo(Generales.getRound(sumTotalTrpTpd, 2)) != 0)
			{
				throw new ControlError("E0688", Mensajes.get("XConsignacion"));
			}
			if(!vistaConsignacion.VisitaClave.equals(((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave))
			{
				if(modificar)
				{
					throw new ControlError(Mensajes.get("E0747", Mensajes.get(estaLiquidada ? "XLiquidada" : "XCreada")));
				}else
				{
					throw new ControlError("E0731", Mensajes.get("XConsignacion"));
				}
			}
			if(vistaConsignacion.Enviado)
			{
				throw new ControlError("E0596" , Mensajes.get(modificar ? "XModificar" : "XEliminar"));
			}
		}
		if(exit)
			ejecutaAccionMenuContext(idAccion);
	}
	
	private void ejecutaModificacionLiquidacion(){
		mVista.iniciarActividadConResultado(ICapturaLiquidacionConsignacion.class, Enumeradores.Solicitudes.SOLICITUD_LIQUIDAR_CONSIGNACION, Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION);
	}
	
	/**
	 * Evalua o filtra la accion y determina el metodo y/o parametros a utilizar 
	 * @param idAccion especifica si la accion es eliminacion, modificacion o liquidacion
	 */
	private void ejecutaAccionMenuContext(int idAccion){
		VistaConsignacion vistaConsignacion = (VistaConsignacion) Sesion.get(Campo.VistaConsignacion);
		TransprodConsig = vistaConsignacion.TransProdId;
		switch(idAccion){
			case R.id.modificar:
				modificaConsignacion(Enumeradores.Acciones.ACCION_CAPTURAR_CONSIGNACIONES);
				break;
			case R.id.surtir:
				modificaConsignacion(Enumeradores.Acciones.ACCION_ELIMINAR_CONSIGNACIONES);
				break;
			default:
				//Aquí comienza la liquidacion
				ConsigFact = false;
				mVista.iniciarActividadConResultado(ICapturaLiquidacionConsignacion.class, Enumeradores.Solicitudes.SOLICITUD_LIQUIDAR_CONSIGNACION, Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION);
		}
	}
	
	/**
	 * Se ejecutara la modificacion o eliminacion de la consigna.
	 * Reduce el saldo al cliente.
	 * @param accion determina la accion para la actividad a lanzar
	 */
	private void modificaConsignacion(String accion){
		VistaConsignacion vistaConsignacion = (VistaConsignacion) Sesion.get(Campo.VistaConsignacion);
		Sesion.set(Campo.TotalInicialCredito, vistaConsignacion.Total);
		
		boolean actualizoSaldo = Clientes.actualizarSaldoCteActual(vistaConsignacion.Total*-1);
		if(actualizoSaldo){
			HashMap<String, String> parametros = new HashMap<String, String>();
			if(accion.equals(Enumeradores.Acciones.ACCION_ELIMINAR_CONSIGNACIONES))
			{
				parametros.put("Reparto", "true");
			}
			parametros.put("TransProdId", vistaConsignacion.TransProdId);
			mVista.iniciarActividadConResultado(ICapturaPedido.class, 0, accion, parametros);
		}
	}
	
	/**
	 * Recupera el saldo al cliente actual, despues de no completar el proceso
	 * de modificacion o eliminacion de la consignacion
	 * @param resultCode 
	 * @throws Exception 
	 */
	public void actualizaSaldo(int resultCode) throws Exception{
		if(resultCode == Enumeradores.Resultados.RESULTADO_BIEN){
			VistaConsignacion vistaConsignacion = (VistaConsignacion) Sesion.get(Campo.VistaConsignacion);
			Clientes.actualizarSaldoCteActual(vistaConsignacion.Total);
			BDVend.commit();
		}else{
			mVista.iniciar();
		}
	}
	
	public boolean isConsignacionActivo()
	{
		return consignacionActivo;
	}

    public int validarLimiteConsignas(){
        int result = 0;
        try{

            Vendedor oVendedor = (Vendedor)Sesion.get(Campo.VendedorActual);
            if (oVendedor.ValidaLimiteConsignas == 1){
                if (oVendedor.LimiteConsignas > 0)
                {
                    if (oVendedor.LimiteConsignas <= Consultas.ConsultasVendedor.ObtenerClientesConConsignaAb(oVendedor))
                    {
                        if (!Consultas.ConsultasVendedor.ExisteClienteConConsignaAb(oVendedor, (Cliente) Sesion.get(Campo.ClienteActual)))
                        {
                            //sMENClave = "I0339";
                            result = 2;
                        }
                    }
                }
                else {
                    //sMENClave = "I0338";
                    result = 1;
                }
            }
        }catch (Exception e){
            result = 1;
        }
        return result;
    }
}
