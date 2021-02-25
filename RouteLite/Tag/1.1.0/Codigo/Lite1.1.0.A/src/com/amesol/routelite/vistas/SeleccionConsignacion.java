package com.amesol.routelite.vistas;

import java.util.List;

import android.content.Intent;
import android.os.Bundle;
import android.text.Html;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemLongClickListener;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.RelativeLayout.LayoutParams;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.CLIFormaVenta;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaPedido;
import com.amesol.routelite.presentadores.interfaces.ISeleccionConsignacion;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.ConsignacionAdapter;

/**
 * Vista para la actividad de consignaciones.
 * @author agonzalez bioxor
 *
 */
public class SeleccionConsignacion extends Vista implements ISeleccionConsignacion
{
	
	private TextView mTexto;
	private Cliente cliente;
	private SeleccionarConsignacion mPresenta;
	private String mAccion;
	private ListView mLista;
	
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.seleccion_pedido);
		
		setEtiquetas();
		mAccion = getIntent().getAction();
		mPresenta = new SeleccionarConsignacion(this, mAccion);
		mPresenta.iniciar();
	}

	/**
	 * Inicializa el listado de consignaciones, para el caso en que no existan
	 * se pasa directamente a la captura de la consigna.
	 */
	@Override
	public void iniciar()
	{
		List<CLIFormaVenta> formasVenta = cliente.CLIFormaVenta;
		boolean tieneCredito = false;
		for(CLIFormaVenta formaVenta:formasVenta){
			if(formaVenta.CFVTipo == Enumeradores.FormasDeVenta.CREDITO);
			tieneCredito = true;
			break;
		}
		SeleccionarConsignacion.VistaConsignacion [] consignaciones = obtenerConsignaciones(cliente);
		CONHist configHistorial = (CONHist) Sesion.get(Campo.CONHist);
		if(consignaciones.length == 0){
			 if(tieneCredito || Integer.parseInt((String)configHistorial.get("ConsignaContado")) == 1){
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
				iniciarActividadConResultado(ICapturaPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_CONSIGNACIONES);
			 }else{
				 findViewById(R.id.btnContinuar).setEnabled(false);
			 }
		}else{
			mLista = (ListView) findViewById(R.id.lstPedidos);
			registerForContextMenu(mLista);
			mLista.setOnItemLongClickListener(menu);
			this.actualizaListado(consignaciones);
		}
	}

	/**
	 * Resultado de la actividad se ejecuta al regresar de una modificacion
	 * o eliminacion de la consignacion. Se debe de regresar el saldo que
	 * fue actualizado al inicio de la operacion.
	 */
	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		//Si retorno aquí volver a acomodar el saldo
		try{
			mPresenta.actualizaSaldo(resultCode);
		}catch(Exception ex){
			mostrarError(ex.getMessage());
		}
	}
	
	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				this.setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				this.finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}
	
	public OnItemLongClickListener menu = new OnItemLongClickListener()
	{

		@Override
		public boolean onItemLongClick(AdapterView<?> arg0, View arg1, int position, long arg3)
		{
			openContextMenu(mLista);
			// Poner en sesion el transprod de la consignacion seleccionada
			Sesion.set(Campo.VistaConsignacion, ((ConsignacionAdapter)mLista.getAdapter()).getItem(position));
			return true;
		}
	};
	
	/**
	 * Metodo de inicializacion de los labels de la actividad Consignacion
	 */
	private void setEtiquetas()
	{
		setTitulo(Mensajes.get("XConsignacion"));
		Button btn = (Button) findViewById(R.id.btnContinuar);
		btn.setText(Mensajes.get("XContinuar"));
		btn.setOnClickListener(mContinuar);
		mTexto = (TextView) findViewById(R.id.lblCliente);
		cliente = (Cliente) Sesion.get(Campo.ClienteActual);
		mTexto.setText(cliente.Clave + " - " + cliente.RazonSocial);
		mTexto = (TextView) findViewById(R.id.lblRuta);
		mTexto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
		mTexto = (TextView) findViewById(R.id.lblDia);
		mTexto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
	}
	
	@Override
	public SeleccionarConsignacion.VistaConsignacion [] obtenerConsignaciones(Cliente cliente)
	{
		return mPresenta.obtenerConsignaciones(cliente);
	}
	
	/**
	 * Agrega las consignaciones del cliente activo en el listado.
	 * @params arrayConsignas Arreglo de consignaciones encontradas para el usuario actual
	 * @author agonzalez
	 */
	@Override
	public void actualizaListado(SeleccionarConsignacion.VistaConsignacion [] arrayConsignas)
	{
		ConsignacionAdapter adapter = new ConsignacionAdapter(this, R.layout.lista_simple4, arrayConsignas);
		mLista.setAdapter(adapter);
		this.actualizaSaldoTotal(arrayConsignas);
	}
	
	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_manto_pedidos , menu);
		 
		menu.getItem(0).setTitle(Mensajes.get("XModificar"));
		menu.getItem(1).setTitle(Mensajes.get("XLiquidar"));
		menu.getItem(2).setTitle(Mensajes.get("XEliminar"));
		
	}
	
	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		try{
			mPresenta.validarAccion(item.getItemId());
		}catch(Exception ex){
			mostrarAdvertencia(ex.getMessage());
		}
		return super.onContextItemSelected(item);
	}
	
	/**
	 * Actualiza el saldo total correspondiente a las consignas, además de mostrarlo
	 * en la etiqueta del footer de la vista
	 */
	@Override
	public void actualizaSaldoTotal(VistaConsignacion[] listadoConsignas)
	{
		float saldoTotal = 0f;
		for(VistaConsignacion consignacion : listadoConsignas)
			saldoTotal+= consignacion.Saldo;
		
		RelativeLayout footer = (RelativeLayout) ((LinearLayout)((ListView)findViewById(R.id.lstPedidos)).getParent()).getChildAt(4);
		TextView txtSaldoTotal;
		if(footer.getChildCount() > 0){
			txtSaldoTotal = (TextView) footer.getChildAt(0);
		}else{
			txtSaldoTotal = new TextView(this);
			txtSaldoTotal.setTextColor(getResources().getColor(R.color.blanco));
			LayoutParams layoutParams = new LayoutParams(LayoutParams.WRAP_CONTENT, LayoutParams.WRAP_CONTENT);
			layoutParams.leftMargin = 10;
			layoutParams.addRule(RelativeLayout.CENTER_VERTICAL);
			footer.addView(txtSaldoTotal, layoutParams);
		}
		
		txtSaldoTotal.setText(Html.fromHtml(Mensajes.get("XSaldoTotal") + ": <b>" + Generales.getFormatoDecimal(saldoTotal, "$ #,##0.00")+ "</b>"));
	}
	
	@Override
	public void ejecutaAccionMenuContext(int idAccion)
	{
		
	}
	
	@Override
	public void ejecutaModificacionLiquidacion()
	{
		
	}
	
	private OnClickListener mContinuar = new OnClickListener()
	{
		
		@Override
		public void onClick(View arg0)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
			iniciarActividadConResultado(ICapturaPedido.class, 0, Enumeradores.Acciones.ACCION_CAPTURAR_CONSIGNACIONES);
		}
	};

}
