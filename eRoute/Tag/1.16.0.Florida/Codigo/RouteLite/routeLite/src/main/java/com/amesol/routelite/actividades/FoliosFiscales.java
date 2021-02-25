package com.amesol.routelite.actividades;

import java.util.List;

import com.amesol.routelite.datos.FolioFiscal;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.utilerias.Log;
import com.amesol.routelite.vistas.Vista;

/**
 * Administrar folios fiscales, metódos genericos para la validacion, generacion y
 * actualizacion de los folios para la facturación electrónica
 * @author agonzalez bioxor
 *
 */
public class FoliosFiscales
{
	public static boolean validarExistencia() throws FoliosFiscalesException{
		try{
			return Consultas.ConsultasFoliosFiscales.existenFoliosFiscales();
		}catch(Exception ex){
			Log.e(ex);
			throw new FoliosFiscalesException("Error al consultar la existencia de folios");
		}
	}
	
	public static List<FolioFiscal> obtenerFolioFiscal(String subEmpresaID, Vista vista) throws FoliosFiscalesException{
		List<FolioFiscal> listFolios = null;
		try{
			listFolios = Consultas.ConsultasFoliosFiscales.obtieneFoliosFiscalesPorCentroExp(subEmpresaID, vista);
		}catch(Exception ex){
			Log.e(ex);
			throw new FoliosFiscalesException("Ocurrio un error al obtener folio fiscal");
		}
		if(listFolios.isEmpty()){
			throw new FoliosFiscalesException(Mensajes.get("E0855"));
		}else{
			Sesion.set(Campo.FoliosFiscales, listFolios);
		}
		return listFolios;
	}
	
	public static void actualizarFolioFiscal(String folioId, String fosId) throws FoliosFiscalesException{
		FolioFiscal folio = new FolioFiscal();
		folio.FolioId = folioId;
		folio.FOSId = fosId;
		try
		{
			BDVend.recuperar(folio);
		}
		catch (Exception e)
		{
			Log.e(e);
			throw new FoliosFiscalesException("No se pudo recuperar el folio a actualizar");
		}
		folio.Usados++;
		folio.Enviado = Boolean.FALSE;
		try
		{
			BDVend.guardarInsertar(folio);
		}
		catch (Exception e)
		{
			Log.e(e);
			throw new FoliosFiscalesException("Error al actualizar el folio");
		}
	}
	
	
	/**
	 * Excepcion especial para las operaciones en la administracion de 
	 * folios fiscales.
	 * @author agonzalez bioxor
	 *
	 */
	public static final class FoliosFiscalesException extends Exception{
		
		public FoliosFiscalesException(String mensaje){
			super(mensaje);
		}
		
		public void muestraError(Vista vista){
			vista.mostrarError(getMessage());
		}
	}
	
}
