package com.amesol.routelite.vistas;

import java.util.HashMap;

import android.content.Intent;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Enumeradores.Inventario.TiposValidacionInventario;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.PromocionDetalle;
import com.amesol.routelite.actividades.TransaccionesDetalle;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.TransProdDetalle;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.act.AplicarPromocion;
import com.amesol.routelite.presentadores.interfaces.IAplicacionPromocion;
import com.amesol.routelite.vistas.generico.AplicaPromoDetalleAdapter;
import com.amesol.routelite.vistas.generico.AplicaPromoDetalleAdapter.onCambioCantidadListener;
import com.amesol.routelite.vistas.generico.AplicaPromocionesAdapter;

public class AplicacionPromocion extends Vista implements IAplicacionPromocion
{

	AplicarPromocion mPresenta;
	String mAccion;
	Integer cantidadGrupo;
	Integer cantidadMax;
	Promocion oPromocion;
    String productoDisparador;
	boolean bIniciando = false;
	boolean bValidarExistencia = false;
	int tipoValidarExistencia = TiposValidacionInventario.NoValidar;
	HashMap<String, TransProdDetalle> seleccionRegalos = new HashMap<String, TransProdDetalle>();
	boolean errorInventario = false;
    boolean bEsVisible = false;

	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();
			setContentView(R.layout.aplicar_promociones);
			deshabilitarBarra(true);

			setTitulo(Mensajes.get("XPromociones"));

			//windowSoftInputMode
			mPresenta = new AplicarPromocion(this, mAccion);

			HashMap<String, Object> oParametros = null;
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
				oPromocion = new Promocion();
				oPromocion.PromocionClave = (String) oParametros.get("PromocionClave");
				BDVend.recuperar(oPromocion);
				
				cantidadGrupo = (Integer) oParametros.get("CantidadGrupo");
				cantidadMax =(Integer) oParametros.get("CantidadMax");
				tipoValidarExistencia = (Integer) oParametros.get("TipoValidarExistencia");
                if (oParametros.containsKey("ProductoDisparador")) {
                    productoDisparador = (String) oParametros.get("ProductoDisparador");
                }
				mPresenta.setParametros(oParametros);
			}

			TextView texto = (TextView) findViewById(R.id.lblPrmDescripcion);
			texto.setText(oPromocion.Nombre);
			
			if (oPromocion.SeleccionProducto){
				texto = (TextView) findViewById(R.id.lblTotal);
				texto.setText(Mensajes.get("XTotal"));
			}else{
				texto = (TextView) findViewById(R.id.lblTotal);
				texto.setVisibility(View.GONE);
			}
			
			if (oPromocion.CapturaCantidad){
				texto = (TextView) findViewById(R.id.lblMaximo);
				texto.setText(Mensajes.get("PMRMaximo"));
				
				texto = (TextView) findViewById(R.id.txtMaximo);
				texto.setText(String.valueOf(cantidadMax * cantidadGrupo));
			}else{
				texto = (TextView) findViewById(R.id.lblMaximo);
				texto.setVisibility(View.GONE);
				texto = (TextView) findViewById(R.id.txtMaximo);
				texto.setVisibility(View.GONE);
			}
        
            if ((Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA && ((Ruta)Sesion.get(Campo.RutaActual)).Inventario ) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.VENTA && Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) != TiposModuloMovDetalle.MOV_SIN_INV_CON_VISITA) || (Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.REPARTO  && Integer.parseInt(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString()) == TiposModuloMovDetalle.PEDIDO)) {
            	bValidarExistencia = true;
            }
			
			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("BtContinuar"));
			btn.setOnClickListener(mContinuar);

			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}

    @Override
    public void onWindowFocusChanged(boolean hasFocus)
    {

        super.onWindowFocusChanged(hasFocus);

        if (hasFocus)
            if (!bEsVisible)
            {
                ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
                listaPromo.requestFocusFromTouch();
                listaPromo.setSelection(0);
                listaPromo.clearFocus();
                if(listaPromo.getAdapter() != null) {
                    ((AplicaPromoDetalleAdapter) listaPromo.getAdapter()).seleccionarPrimero();
                    //getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
                }
                //if(!bBusquedaSimple) {
                //eCantidades.get(0).requestFocus();
                //}
                bEsVisible = true;
            }
    }

	public void mostrarProductosPromocion()
	{
		ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
		listaPromo.setDescendantFocusability(ViewGroup.FOCUS_AFTER_DESCENDANTS);
		listaPromo.setChoiceMode(1);
		listaPromo.setClickable(false);
		getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);

		try
		{
			bIniciando = true;
			AplicaPromoDetalleAdapter adapter;
			PromocionDetalle promocionDetalle[] = Consultas.ConsultasPromocion.obtenerVistaDetalle(oPromocion, cantidadGrupo);
			adapter = new AplicaPromoDetalleAdapter(this, R.layout.elemento_promocion_detalle, promocionDetalle,tipoValidarExistencia);

			listaPromo.setAdapter(adapter);

			bIniciando = false;
			
			adapter.setOnCambioCantidadListener(new onCambioCantidadListener()
			{
				
				@Override
				public void onCambioCantidad()
				{
					ListView listaPromo = (ListView) findViewById(R.id.lstPromo);								
					setTotalCantidades(((AplicaPromoDetalleAdapter)listaPromo.getAdapter()).getDetalles());		
				}
			});
			
			setTotalCantidades(promocionDetalle);

            listaPromo.requestFocusFromTouch();
            listaPromo.setSelection(0);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
	}


	
	private void setTotalCantidades(PromocionDetalle promocionDetalle[]){
		if (bIniciando) return;
		int total = 0;
		for (int i = 0;  i < promocionDetalle.length; i++ ){
			if (promocionDetalle[i].isChecked()){
				total += promocionDetalle[i].getCantidad() * promocionDetalle[i].getFactor();
			}
		}
		TextView texto = (TextView) findViewById(R.id.txtTotal);
		texto.setText(String.valueOf(total));
	}
	
	public void setFolioRazonSocial(Cliente oCliente, TransProd oTRP)
	{
		TextView texto = (TextView) findViewById(R.id.lblFolioCliente);
		texto.setText(oTRP.Folio + " - " + oCliente.RazonSocial);
	}

	public void setErrorInventario(boolean ErrorInventario)
	{
		errorInventario = ErrorInventario;
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{

		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
                //No se puede regresar de una promocion de regalo
				/*try
				{
					mPresenta.getPromociones().Preparar(); //eliminar las promociones
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage());
				}
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
				return true;*/
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		
	}

	@Override
	public void iniciar()
	{

	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			if (oPromocion.CapturaCantidad){
				ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
				listaPromo.clearFocus();
				TextView txtTotal = (TextView) findViewById(R.id.txtTotal);
				TextView txtMaximo = (TextView) findViewById(R.id.txtMaximo);				
				if(Float.parseFloat(txtTotal.getText().toString()) > Float.parseFloat(txtMaximo.getText().toString())){
					mostrarAdvertencia(Mensajes.get("E0503",oPromocion.Nombre));
					return;
				}
			}
            if(oPromocion.NoDisminuirProducto){
                ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
                listaPromo.clearFocus();
                TextView txtTotal = (TextView) findViewById(R.id.txtTotal);
                TextView txtMaximo = (TextView) findViewById(R.id.txtMaximo);
                if(Float.parseFloat(txtTotal.getText().toString()) < Float.parseFloat(txtMaximo.getText().toString())){
                    mostrarAdvertencia(Mensajes.get("E0902", "Total de productos que se entregarán en la promoción", "a la cantidad Máxima a regalar").replace(" o igual",""));
                    return;
                }
            }

            //Si hay error de inventario y no hay backorder se supone que quedan las cantidades en 0
			/*if (errorInventario ) {
				errorInventario = false;
				return;
			}*/
			boolean bAlMenosUnRegalo = false;
			ListView listaPromo = (ListView) findViewById(R.id.lstPromo);
			AplicaPromoDetalleAdapter adapter;
			adapter = (AplicaPromoDetalleAdapter) listaPromo.getAdapter();
			listaPromo.clearFocus();
			try
			{
				for (int i = 0; i < adapter.getCount(); i++)
				{
					PromocionDetalle promocionDetalle = (PromocionDetalle) adapter.getItem(i);
					if (!promocionDetalle.isSeleccionProducto())
					{
						TransProdDetalle tpd = TransaccionesDetalle.Pedidos.GuardarDetalleRegalados(mPresenta.getTransProd(), promocionDetalle.getProductoClave(), promocionDetalle.getPRUTipoUnidad(), promocionDetalle.getCantidad(), promocionDetalle.getPromocionClave(), tipoValidarExistencia, oPromocion.PendienteEntrega, productoDisparador);
                        if (tpd!= null) {
                            mPresenta.getTransProd().TransProdDetalle.add(tpd);
                        }
						bAlMenosUnRegalo = true;
					}
					else
					{
						if (promocionDetalle.isChecked())
						{
							if (promocionDetalle.getCantidad()>0){
								TransProdDetalle tpd = TransaccionesDetalle.Pedidos.GuardarDetalleRegalados(mPresenta.getTransProd(), promocionDetalle.getProductoClave(), promocionDetalle.getPRUTipoUnidad(), promocionDetalle.getCantidad(), promocionDetalle.getPromocionClave(), tipoValidarExistencia, oPromocion.PendienteEntrega, productoDisparador);
                                if (tpd != null){
								mPresenta.getTransProd().TransProdDetalle.add(tpd);
                                }
								bAlMenosUnRegalo = true;		
							}					
						}
					}
				}

			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
			}
			Sesion.set(Campo.ResultadoActividad, bAlMenosUnRegalo);
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}
	};
}
