package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Descuentos;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Promociones2;
import com.amesol.routelite.controles.NumberPicker;
import com.amesol.routelite.controles.NumberPicker.OnChangedListener;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.ModuloMovDetalle;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CapturarTotalesConsignacion;
import com.amesol.routelite.presentadores.interfaces.ICapturaTotalesConsignacion;
import com.amesol.routelite.utilerias.ControlError;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.vistas.generico.DialogoAlerta;
 
@SuppressLint(
{ "SimpleDateFormat", "CutPasteId", "DefaultLocale" })
public class CapturaTotalesConsignacion extends Vista implements ICapturaTotalesConsignacion
{

	CapturarTotalesConsignacion mPresenta;
	String mAccion;
	HashMap<String, Object> oParametros = null;
	ArrayList<String> aTransProdIds;
	short trueType;

	ISetDatos tiposFase;
	ISetDatos tiposCodigoMoneda;
	ISetDatos formaVenta;

	static final int ELIMINACION_CONSIGNACION = 997;
	private Date fechaCobranza;
	private Date fechaEntrega;
	private CONHist oConHist;
	private int formaVentaInicial = -1;
	boolean soloLectura = true;
	boolean esNuevo;
	float nTotalInicial;
	boolean surtir = false;
	boolean modificando = false;
	boolean mensajeValidaCredito = false;
    boolean mensajeLimiteEnvase = false;

	float maxDesctoVendedor = 0;
	float maxImporteDesctoVendedor = 0;
	boolean imprimiendo;

	ModuloMovDetalle moduloMovDetalle = new ModuloMovDetalle();

	@SuppressLint("CutPasteId")
	@SuppressWarnings("unchecked")
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		float abonosAnteriores = 0;
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			imprimiendo = false;

			setContentView(R.layout.captura_totales_consignacion);
			deshabilitarBarra(true);
			setTitulo(Mensajes.get("XGeneral"));

			EditText edit = (EditText) findViewById(R.id.txtFolio);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);
			edit = (EditText) findViewById(R.id.txtFase);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);
			edit = (EditText) findViewById(R.id.txtFechaEntrega);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);
			edit = (EditText) findViewById(R.id.txtListaPrecios);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);
			edit = (EditText) findViewById(R.id.txtSubtotal);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);
			edit = (EditText) findViewById(R.id.txtImpuesto);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);
			edit = (EditText) findViewById(R.id.txtTotal);
			edit.setEnabled(false);
			edit.setSelectAllOnFocus(true);

			TextView texto = (TextView) findViewById(R.id.lblFolio);
			texto.setText(Mensajes.get("XFolio"));

			texto = (TextView) findViewById(R.id.lblFechaEntrega);
			texto.setText(Mensajes.get("XFecha"));

			texto = (TextView) findViewById(R.id.lblSubtotal);
			texto.setText(Mensajes.get("XSubtotal"));
			
			texto = (TextView) findViewById(R.id.lblFase);
			texto.setText(Mensajes.get("XFase"));
			
			texto = (TextView) findViewById(R.id.lblListaPrecios);
			texto.setText(Mensajes.get("XListaPrecio"));

			texto = (TextView) findViewById(R.id.lblImpuesto);
			texto.setText(Mensajes.get("XImpuesto"));

			texto = (TextView) findViewById(R.id.lblTotal);
			texto.setText(Mensajes.get("XTotal"));

			texto = (TextView) findViewById(R.id.lblNotas);
			texto.setText(Mensajes.get("XComentarios"));

			Button btn = (Button) findViewById(R.id.btnImpuestos);
			btn.setText(Mensajes.get("XRecalcular"));
			btn.setOnClickListener(mImpuestos);

			
			btn = (Button) findViewById(R.id.btnTerminar);
			btn.setText(Mensajes.get(mAccion.equals(Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION) ? "XImprimir":"XTerminar"));
			btn.setOnClickListener(mTerminar);

			obtenerValoresPorReferencia();

			// obtener el parametro
			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");
			}

			if (oParametros != null)
			{
				aTransProdIds = (ArrayList<String>) oParametros.get("TransProdId");
				ArrayList<String> nuevo = (ArrayList<String>) oParametros.get("esNuevo");
				esNuevo = Boolean.parseBoolean(nuevo.get(0));
				moduloMovDetalle = (ModuloMovDetalle) oParametros.get("ModuloMovDetalle");
				nTotalInicial = Float.parseFloat(oParametros.get("TotalInicial").toString());
				surtir = Boolean.parseBoolean(oParametros.get("Surtir").toString());
				modificando = Boolean.parseBoolean(oParametros.get("Modificando").toString());
				if(mAccion.equals(Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION))
				{
					abonosAnteriores = (Float) oParametros.get("abonosAnteriores");
				}
			}

			if (aTransProdIds != null && aTransProdIds.size() > 0)
			{
				oConHist = (CONHist) Sesion.get(Campo.CONHist);

				mPresenta = new CapturarTotalesConsignacion(this, mAccion, aTransProdIds, abonosAnteriores);
				mPresenta.iniciar();
			}

			if (soloLectura || !esNuevo)
			{
				HabilitarControles(false);
				((Button)findViewById(R.id.btnImpuestos)).setText(Mensajes.get(mAccion.equals(Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION) ? "XRecalcular" :"BTRegresar"));
				getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
			}

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}

	}
	
	public void enableTipoPedido(boolean habilitar){
		Spinner spTipoPedido = (Spinner) findViewById(R.id.spTipoPedido);
		spTipoPedido.setEnabled(habilitar);
	}

	private OnClickListener mImpuestos = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			if(mAccion.equals(Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION))
			{
				/* Recalcular la liquidacion de la consignación */
				try{
					mPresenta.recalcular();
				}catch(Exception ex){
					mostrarError(ex.getMessage());
				}
			}else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
			}
		}
	};

	public boolean getEsNuevo()
	{
		return esNuevo;
	}

	public boolean getSurtir()
	{
		return surtir;
	}
	
	public boolean getModificando(){
		return modificando;
	}

	public float getTotalInicial()
	{
		return nTotalInicial;
	}

	private void HabilitarControles(boolean habilitar)
	{
		if(!mAccion.equals(Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION)){
			EditText edit = (EditText) findViewById(R.id.txtNotas);
			edit.setEnabled(habilitar);
		}
	}

	public void validarDesctoVendedor(float subTDetalle, float descuentoImp) throws Exception
	{
		boolean habilitar = Descuentos.ValidarAplicacion("AplicaVendedor");
		/*
		 * EditText texto = (EditText) findViewById(R.id.txtDescVendedor);
		 * texto.setEnabled(habilitar);
		 */
		NumberPicker npImp = (NumberPicker) findViewById(R.id.npDescVendedor);
		npImp.setEnabled(habilitar);
		/*
		 * texto = (EditText) findViewById(R.id.txtPorVendedor);
		 * texto.setEnabled(habilitar);
		 */
		NumberPicker npPor = (NumberPicker) findViewById(R.id.npPorVendedor);
		npPor.setEnabled(habilitar);

		if (habilitar)
		{
			Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
			maxDesctoVendedor = vendedor.LimiteDescuento;
			maxImporteDesctoVendedor = (subTDetalle - descuentoImp) * (vendedor.LimiteDescuento <= 0 ? 0 : (vendedor.LimiteDescuento / 100));

			npImp.setDecimal(2);
			// npImp.setStep(100);
			npImp.setStep(1);
			npImp.setWrap(false);
			// npImp.setRange(0, (int) (maxImporteDesctoVendedor * 100));
			npImp.setRangeDecimal(0, Generales.getRound(maxImporteDesctoVendedor, 2));
//			npImp.setOnChangeListener(mImporte);

			npPor.setDecimal(4);
			// npPor.setStep(10000);
			npPor.setStep(1);
			npPor.setWrap(false);
			// npPor.setRange(0, (int) (maxDesctoVendedor * 10000));
			npPor.setRangeDecimal(0, Generales.getRound(maxDesctoVendedor, 4));
//			npPor.setOnChangeListener(mPorcentaje);
		}
	}


	private OnChangedListener mDiasCredito = new OnChangedListener()
	{

		@Override
		public void onChanged(NumberPicker picker, int oldVal, int newVal)
		{
			Calendar fecha = Calendar.getInstance();
			//fecha.setTime(Generales.getFechaActual());
			fecha.setTime(((Dia) Sesion.get(Campo.DiaActual)).FechaCaptura);
			fecha.add(Calendar.DATE, Math.round(picker.getCurrent()));
			Button btnCobranza = (Button) findViewById(R.id.btnFechaCobranza);
			fechaCobranza = fecha.getTime();
			btnCobranza.setText(new SimpleDateFormat("dd/MMM/yyyy").format(fecha.getTime()));				
			
		}
	};

	public void setImpDescVendedor(float descuento)
	{
		NumberPicker npImp = (NumberPicker) findViewById(R.id.npDescVendedor);
		npImp.setCurrentDecimal(descuento);
	}

	public void setPorDescVendedor(float porcentaje)
	{
		NumberPicker npPor = (NumberPicker) findViewById(R.id.npPorVendedor);
		npPor.setCurrentDecimal(porcentaje);
	}

	public void setFolio(String Folio)
	{
		EditText text = (EditText) findViewById(R.id.txtFolio);
		text.setText(Folio);
	}

	public void setTipoPedido(int TipoPedido)
	{
		Spinner spinMoneda = (Spinner) findViewById(R.id.spTipoPedido);
		SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinMoneda.getAdapter();
		for (int i = 0; i < adapter.getCount(); i++)
		{
			Cursor c = (Cursor) adapter.getItem(i);
			if (c.getString(0).equals(String.valueOf(TipoPedido)))
			{
				Spinner spinM = (Spinner) findViewById(R.id.spTipoPedido);
				spinM.setSelection(c.getPosition());
				break;
			}
		}
		/*Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
		spin.setSelection(TipoPedido);*/
	}

	public short getTipoPedido()
	{
		Spinner spin = (Spinner) findViewById(R.id.spTipoPedido);
		return (short) spin.getSelectedItemId();
	}

	
	public void setTipoFase(int TipoFase) {
		tiposFase.moveToPosition(TipoFase); // mover el cursor del valor por //
		EditText text = (EditText) findViewById(R.id.txtFase);
		text.setText(tiposFase.getString(2)); // obtener la descripcion del //
	}
	 
	@Override
	public void setListaPrecios(String clave)
	{
		((EditText) findViewById(R.id.txtListaPrecios)).setText(clave);
	}
	
	@Override
	public void setComentarios(String comentarios)
	{
		((EditText) findViewById(R.id.txtNotas)).setText(comentarios);
	}

    public void setMensajeLimiteEnvase(boolean mostrandoMensaje){
        mensajeLimiteEnvase = mostrandoMensaje;
    }

    public boolean getMensajeLimiteEnvase(){
        return mensajeLimiteEnvase;
    }

	public void setFormaVenta(int FormaVenta)
	{
		if (FormaVenta != -1)
		{ // tiene configurada una forma de venta como inicial, seleccionarla

			Spinner spinMoneda = (Spinner) findViewById(R.id.spFormaVenta);
			SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinMoneda.getAdapter();

			for (int i = 0; i < adapter.getCount(); i++)
			{
				Cursor c = (Cursor) adapter.getItem(i);
				if (c.getString(0).equals(String.valueOf(FormaVenta)))
				{
					Spinner spinM = (Spinner) findViewById(R.id.spFormaVenta);
					spinM.setSelection(c.getPosition());
					break;
				}
			}

			/*
			 * Spinner spin = (Spinner) findViewById(R.id.spFormaVenta);
			 * spin.setSelection(FormaVenta - 1);
			 */
		}
	}

	public void setFormaPago(String FormaPago)
	{

		Spinner spinMoneda = (Spinner) findViewById(R.id.spFormaPago);
		SimpleCursorAdapter adapter = (SimpleCursorAdapter) spinMoneda.getAdapter();
		for (int i = 0; i < adapter.getCount(); i++)
		{
			Cursor c = (Cursor) adapter.getItem(i);
			if (c.getString(0).equals(FormaPago))
			{
				Spinner spinM = (Spinner) findViewById(R.id.spFormaPago);
				spinM.setSelection(c.getPosition());
				break;
			}
		}

		/*
		 * Spinner spin = (Spinner) findViewById(R.id.spFormaPago);
		 * spin.setSelection(Integer.parseInt(FormaPago));
		 */
	}

	public short getFormaVenta()
	{
		Spinner spin = (Spinner) findViewById(R.id.spFormaVenta);
		return (short) spin.getSelectedItemId();
	}

	public short getFormaVentaInicial()
	{
		return (short) formaVentaInicial;
	}

	public String getFormaPago()
	{
		Spinner spin = (Spinner) findViewById(R.id.spFormaPago);
		return String.valueOf((short) spin.getSelectedItemId());
	}

	public void setListaPrecio(String PrecioClave)
	{
		TextView text = (TextView) findViewById(R.id.txtListaPrecio);
		text.setText(PrecioClave);
	}

	public void setFechaEntrega(Date FechaEntrega)
	{
		fechaEntrega = FechaEntrega;
		EditText txtEntrega = (EditText) findViewById(R.id.txtFechaEntrega);
		txtEntrega.setText(new SimpleDateFormat("dd/MM/yyyy").format(fechaEntrega.getTime()));
	}

	public Date getFechaEntrega()
	{
		return fechaEntrega;
	}

	public void setFechaCobranza(Date FechaCobranza)
	{
		fechaCobranza = FechaCobranza;
	}

	public Date getFechaCobranza()
	{
		return fechaCobranza;
	}

	public void setSubTProducto(float subTProducto)
	{
		EditText text = (EditText) findViewById(R.id.txtSubtotalProducto);
		// text.setText(String.format("%.2f", subTDetalle));
		text.setText(Generales.getFormatoDecimal(subTProducto, "$ #,##0.00"));
	}

	public void setDescYBonif(float descYBonif)
	{
		EditText text = (EditText) findViewById(R.id.txtDescYBonif);
		// text.setText(String.format("%.2f", descCliente));
		text.setText(Generales.getFormatoDecimal(descYBonif, "$ #,##0.00"));
	}

	public void setSubTotal(float subTotal)
	{
		EditText text = (EditText) findViewById(R.id.txtSubtotal);
		// text.setText(String.format("%.2f", subTotal));
		text.setText(Generales.getFormatoDecimal(subTotal, "$ #,##0.00"));
	}

	public void setImpuesto(float impuesto)
	{
		EditText text = (EditText) findViewById(R.id.txtImpuesto);
		// text.setText(String.format("%.2f", impuesto));
		text.setText(Generales.getFormatoDecimal(impuesto, "$ #,##0.00"));
	}

	public void setTotal(float total)
	{
		EditText text = (EditText) findViewById(R.id.txtTotal);
		// text.setText(String.format("%.2f", total));
		text.setText(Generales.getFormatoDecimal(total, "$ #,##0.00"));
	}

	public void setPedidoAdicional(String pedidoAdicional)
	{
		EditText texto = (EditText) findViewById(R.id.txtPedidoAdicional);
		texto.setText(pedidoAdicional);
	}

	public String getNotas()
	{
		EditText texto = (EditText) findViewById(R.id.txtNotas);
		return texto.getText().toString().trim();
	}

	public String getPedidoAdicional()
	{
		EditText texto = (EditText) findViewById(R.id.txtPedidoAdicional);
		return texto.getText().toString().trim();
	}

	public int getDiasCredito()
	{
		NumberPicker diasCredito = (NumberPicker) findViewById(R.id.npDiasCredito);
		return Math.round(diasCredito.getCurrent());
	}

	@Override
	public String getPuntoEntrega()
	{
		Spinner spnPtoEntrega = (Spinner) findViewById(R.id.spPuntoEntrega);
		String ptoEntrega = null;
		if (spnPtoEntrega.getSelectedItem() != null)
		{
			Cursor c = (Cursor) ((SimpleCursorAdapter) spnPtoEntrega.getAdapter()).getItem(spnPtoEntrega.getSelectedItemPosition());
			ptoEntrega = c.getString(1); // ClienteDomicilioId
		}
		if (!(spnPtoEntrega.getCount() > 1))
			spnPtoEntrega.setEnabled(false);
		return ptoEntrega;
	}

	@Override
	public void setPuntoEntrega(String clienteDomicilioId)
	{
		Spinner spnPtoEntrega = (Spinner) findViewById(R.id.spPuntoEntrega);
		SimpleCursorAdapter adapter = (SimpleCursorAdapter) spnPtoEntrega.getAdapter();
		for (int i = 0; i < adapter.getCount(); i++)
		{
			Cursor c = (Cursor) adapter.getItem(i);
			if (c.getString(0).equals(clienteDomicilioId))
			{
				spnPtoEntrega.setSelection(c.getPosition());
				break;
			}
		}
	}

	@SuppressLint("DefaultLocale")
	public void setFocus(String campo)
	{
		if (campo.toLowerCase().equals("dias credito"))
		{
			NumberPicker diasCredito = (NumberPicker) findViewById(R.id.npDiasCredito);
			diasCredito.requestFocus();
		}
		else if (campo.toLowerCase().equals("fecha cobranza"))
		{
			Button btn = (Button) findViewById(R.id.btnFechaCobranza);
			btn.requestFocus();
		}
		else if (campo.toLowerCase().equals("notas"))
		{
			EditText notas = (EditText) findViewById(R.id.txtNotas);
			notas.requestFocus();
		}
		else if (campo.toLowerCase().equals("pedido adicional"))
		{
			EditText pedidoAdicional = (EditText) findViewById(R.id.txtPedidoAdicional);
			pedidoAdicional.requestFocus();
		}
		else if (campo.toLowerCase().equals("punto entrega"))
		{
			Spinner spnPtoEntrega = (Spinner) findViewById(R.id.spPuntoEntrega);
			spnPtoEntrega.requestFocus();
		}
	}

	@SuppressWarnings("deprecation")
	private void obtenerValoresPorReferencia() throws Exception
	{

		// TIPOS DE FASE
		tiposFase = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("TRPFASE", "");
		startManagingCursor((Cursor) tiposFase.getOriginal());

		// TIPOS CODIGO PARA LAS MONEDAS
		tiposCodigoMoneda = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("CDGOMON", "");
		startManagingCursor((Cursor) tiposCodigoMoneda.getOriginal());
	}

	public void recalcularTotales(TransProd oTrp) throws Exception
	{
		// float descuentoImpuestoCliente = 0;
		ISetDatos desctoCliente = Consultas.ConsultasDescuentos.obtenerDescuentosCliente(oTrp.TransProdID);
		while (desctoCliente.moveToNext())
		{
			oTrp.DescuentoImp = desctoCliente.getFloat("DesImporte");
			oTrp.DescuentoImpuestoCliente = desctoCliente.getFloat("DesImpuesto");
			// descuentoImpuestoCliente = desctoCliente.getFloat("DesImpuesto");
			// oTrp.Impuesto -= descuentoImpuestoCliente;
		}
		desctoCliente.close();

		// Hasta aqui el descuento del cliente ya esta calculado y aplicado,
		// tambien al Impuesto
		// Calcular el importe del descuento del subtotal
		oTrp.DescuentoVendedor = ((oTrp.SubTDetalle == null ? 0 : oTrp.SubTDetalle) - (oTrp.DescuentoImp == null ? 0 : oTrp.DescuentoImp)) * (oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor / 100);
		// Calcular el importe del descuento del impuesto
		// float descuentoImpuestoVendedor = (oTrp.Impuesto -
		// descuentoImpuestoCliente) * (oTrp.DescVendPor / 100);
		oTrp.DescuentoImpuestoVendedor = (oTrp.Impuesto == null ? 0 : oTrp.Impuesto - oTrp.DescuentoImpuestoCliente) * (oTrp.DescVendPor == null ? 0 : oTrp.DescVendPor / 100);

		// oTrp.Impuesto -= descuentoImpuestoVendedor;

		oTrp.Subtotal = (oTrp.SubTDetalle == null ? 0 : oTrp.SubTDetalle) - (oTrp.DescuentoImp == null ? 0 : oTrp.DescuentoImp) - (oTrp.DescuentoVendedor == null ? 0 : oTrp.DescuentoVendedor);
		if (oTrp.Subtotal < 0)
			oTrp.Subtotal = (float) 0;
		oTrp.Total = oTrp.Subtotal + (oTrp.Impuesto == null ? 0 : oTrp.Impuesto - oTrp.DescuentoImpuestoCliente - oTrp.DescuentoImpuestoVendedor);
		if (oTrp.Total < 0)
			oTrp.Total = 0;
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public void setSoloLectura(boolean bsoloLectura)
	{
		soloLectura = bsoloLectura;
	}

	private OnClickListener mTerminar = new OnClickListener()
	{
		@Override
		public void onClick(View v)
		{
			Button btn = (Button) findViewById(R.id.btnTerminar);
			if(mAccion.equals(Enumeradores.Acciones.ACCION_ELIMINAR_CONSIGNACIONES))
			{
				btn.setEnabled(false);
				mostrarPreguntaSiNo(Mensajes.get("P0001"), ELIMINACION_CONSIGNACION);
			}else if(mAccion.equals(Enumeradores.Acciones.ACCION_LIQUIDAR_CONSIGNACION)){
				try
				{
					mPresenta.validarVenta();
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
				catch (ControlError e)
				{
					mostrarError(e.getMessage());
				}catch(Exception ex)
				{
					
				}
			}
			else{
				try
				{
					if (!soloLectura)
					{ // no modificar si esta solo lectura 
						btn.setEnabled(false);
						mPresenta.asignarGuardarValores();
					}
					else
					{ // si es solo lectura, salir
						setResultado(Enumeradores.Resultados.RESULTADO_MAL);
						finalizar();
					}
					
					Runnable accion = new Runnable()
					{
						
						@Override
						public void run()
						{
							while(getMensajeLimiteCredito() || getMensajeLimiteEnvase()){
								//esperar hasta que se quite el mensaje de validacion de credito para continuar
							}
							runOnUiThread(new Runnable()
							{ //ejecutar en el thread de la ui para poder mostrar el mensaje de impresion
								@Override
								public void run()
								{
									terminar();								
								}
							});
						}
					};
					final Thread hilo = new Thread(accion);
					hilo.start();
				}
				catch (Exception ex)
				{
					mostrarError(ex.getMessage());
					btn.setEnabled(true);
				}
			}
		}
	};
	
	private void terminar(){
		MOTConfiguracion motConfig = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
		if (motConfig.get("MensajeImpresion").equals("0"))
		{
			// si no esta configurada la pregunta salir
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}else if(motConfig.get("MensajeImpresion").equals("1")){
			mostrarPreguntaSiNo(Mensajes.get("P0103"), 8);
		}else if (motConfig.get("MensajeImpresion").equals("2")){
            mostrarToast(Mensajes.get("E0934"));
            setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
            finalizar();
        }
	}

	@Override
	public void iniciar()
	{

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		try
		{
			if (requestCode == REQUEST_ENABLE_BT)
			{
				if (resultCode == RESULT_OK)
				{
					try
					{
						imprimiendo = true;
						mPresenta.imprimirTicket();
					}
					catch (Exception e)
					{
						Toast.makeText(getBaseContext(), e.getMessage(), Toast.LENGTH_LONG).show();
						setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
						finalizar();
					}
				}
				else
				{
					mostrarError("No se pudo encender el BT");
				}

				return;
			}
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if(mensajeValidaCredito) //quitar la bandera del mensaje de limite de credito para continuar
			mensajeValidaCredito = false;

		if(mensajeLimiteEnvase)
			mensajeLimiteEnvase = false;
		
		if (tipoMensaje == 8)
		{ // imprimir recibo
			if (respuesta.equals(RespuestaMsg.Si))
			{
				// Imprimir ticket
				imprimiendo = true;
				try
				{
					if (!bluetoothEncendido())
					{
						encenderBluetooth();
					}
					else
					{
						mPresenta.imprimirTicket();
					}
					// getVista().mostrarAdvertencia("Recibos generados");
				}
				catch (Exception e)
				{
					Toast.makeText(getBaseContext(), e.getMessage(), Toast.LENGTH_LONG).show();
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
			}
			else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
		else if (tipoMensaje == 0 && imprimiendo)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
			finalizar();
		}else if(tipoMensaje == ELIMINACION_CONSIGNACION)
		{
			if(RespuestaMsg.Si == respuesta)
			{
				try{
					mPresenta.eliminarConsignacion();
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}catch(Exception ex){
					mostrarError(ex.getMessage());
				}
			}else
			{
				setResultado(Enumeradores.Resultados.RESULTADO_MAL);
				finalizar();
			}
		}else if (tipoMensaje == 99)
		{ // pregunta aplicar promocion
			Promociones2 promocion = mPresenta.getPromociones();
			try
			{
				if (respuesta.equals(RespuestaMsg.Si))
				{
					if (promocion.promocionActual.Tipo == com.amesol.routelite.actividades.Enumeradores.Promocion.Tipo.ProductoAcumulado)
					{
						if (promocion.reglaAcumActual != null)
						{
							promocion.reglaAcumActual.Aplicar();
							promocion.promocionActual.SeAcepto = true;
						}
					}
					else
					{
						if (promocion.reglaActual != null)
						{
							promocion.reglaActual.Aplicar();
						}
					}
				}
				promocion.SiguientePromocion();

			}
			catch (Exception ex)
			{
				mostrarError(ex.getMessage());
			}
		}
	}
	
	public void setMensajeLimiteCredito(boolean mostrandoMensaje){
		mensajeValidaCredito = mostrandoMensaje;
	}
	
	public boolean getMensajeLimiteCredito(){
		return mensajeValidaCredito;
	}

	@Override
	public void finalizar()
	{
		if (Sesion.get(Campo.ArrayTransProd) != null)
		{
			Sesion.remove(Campo.ArrayTransProd);
		}
		super.finalizar();
	}
	

	//	// view binder para el combo de las monedas
	//	private class vista implements ViewBinder
	//	{
	//
	//		@Override
	//		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
	//		{
	//			int viewId = view.getId();
	//			switch (viewId)
	//			{
	//				case android.R.id.text1:
	//					TextView texto = (TextView) view;
	//					tiposCodigoMoneda.moveToPosition(cursor.getInt(2) - 1);
	//					texto.setText(cursor.getString(1) + " " + tiposCodigoMoneda.getString(2));
	//					break;
	//				/*
	//				 * case R.id.lblPorcentajeImp: TextView por = (TextView) view;
	//				 * por.setText(String.format("%.2f %%",
	//				 * cursor.getFloat(columnIndex))); break; case R.id.lblTotalImp:
	//				 * TextView imp = (TextView) view;
	//				 * imp.setText(String.format("$ %.2f",
	//				 * cursor.getFloat(columnIndex))); break;
	//				 */
	//				default:
	//					TextView text = (TextView) view;
	//					text.setText(cursor.getString(columnIndex));
	//					break;
	//			}
	//			return true;
	//		}
	//
	//	}

	// clase para la vista del desglose de impuestos
	public static class vistaDesgloseImp
	{
		private String abreviatura;
		private float porcentaje;
		private float importe;

		public vistaDesgloseImp(String sAbreviatura, float fPorcentaje, float fImporte)
		{
			abreviatura = sAbreviatura;
			porcentaje = fPorcentaje;
			importe = fImporte;
		}

		public String getAbreviatura()
		{
			return abreviatura;
		}

		public void setAbreviatura(String abreviatura)
		{
			this.abreviatura = abreviatura;
		}

		public float getPorcentaje()
		{
			return porcentaje;
		}

		public void setPorcentaje(float porcentaje)
		{
			this.porcentaje = porcentaje;
		}

		public float getImporte()
		{
			return importe;
		}

		public void setImporte(float importe)
		{
			this.importe = importe;
		}

	}

	public static class vistaDesgloseProm
	{
		private String ClaveProducto;
		private String NombreProducto;
		private String ClavePromocion;
		private String NombrePromocion;
		private String Descuento;
		private String ImporteDesc;
		private String Bonificacion;
		private String ProdRegalo;
		private String Cantidad;
		private String Puntos;
		private String Precio;
		private boolean isMasdeUno;
		private ArrayList<vistaDesgloseProm> mvistaDesgloseProm = new ArrayList<vistaDesgloseProm>();

		public vistaDesgloseProm(String claveProducto, String nombreProducto, String clavePromocion, String nombrePromocion, String descuento, String importeDesc, String bonificacion, String prodRegalo, String cantidad, String puntos, String precio, boolean ismasdeUno, ArrayList<vistaDesgloseProm> mVistaDesgloseProm)
		{
			ClaveProducto = claveProducto;
			NombreProducto = nombreProducto;
			ClavePromocion = clavePromocion;
			NombrePromocion = nombrePromocion;
			Descuento = descuento;
			ImporteDesc = importeDesc;
			ProdRegalo = prodRegalo;
			Bonificacion = bonificacion;
			Cantidad = cantidad;
			Puntos = puntos;
			Precio = precio;
			isMasdeUno = ismasdeUno;
			setMvistaDesgloseProm(mVistaDesgloseProm);

		}

		public boolean isMasdeUno()
		{
			return isMasdeUno;
		}

		public void setMasdeUno(boolean isMasdeUno)
		{
			this.isMasdeUno = isMasdeUno;
		}

		public String getPrecio()
		{
			return Precio;
		}

		public void setPrecio(String precio)
		{
			Precio = precio;
		}

		public String getClaveProducto()
		{
			return ClaveProducto;
		}

		public void setClaveProducto(String claveProducto)
		{
			ClaveProducto = claveProducto;
		}

		public String getNombreProducto()
		{
			return NombreProducto;
		}

		public void setNombreProducto(String nombreProducto)
		{
			NombreProducto = nombreProducto;
		}

		public String getClavePromocion()
		{
			return ClavePromocion;
		}

		public void setClavePromocion(String clavePromocion)
		{
			ClavePromocion = clavePromocion;
		}

		public String getNombrePromocion()
		{
			return NombrePromocion;
		}

		public void setNombrePromocion(String nombrePromocion)
		{
			NombrePromocion = nombrePromocion;
		}

		public String getDescuento()
		{
			return Descuento;
		}

		public void setDescuento(String descuento)
		{
			Descuento = descuento;
		}

		public String getImporteDesc()
		{
			return ImporteDesc;
		}

		public void setImporteDesc(String importeDesc)
		{
			ImporteDesc = importeDesc;
		}

		public String getBonificacion()
		{
			return Bonificacion;
		}

		public void setBonificacion(String bonificacion)
		{
			Bonificacion = bonificacion;
		}

		public String getCantidad()
		{
			return Cantidad;
		}

		public void setCantidad(String cantidad)
		{
			Cantidad = cantidad;
		}

		public String getProdRegalo()
		{
			return ProdRegalo;
		}

		public void setProdRegalo(String prodRegalo)
		{
			ProdRegalo = prodRegalo;
		}

		public String getPuntos()
		{
			return Puntos;
		}

		public void setPuntos(String puntos)
		{
			Puntos = puntos;
		}

		public ArrayList<vistaDesgloseProm> getMvistaDesgloseProm()
		{
			return mvistaDesgloseProm;
		}

		public void setMvistaDesgloseProm(ArrayList<vistaDesgloseProm> mvistaDesgloseProm)
		{
			this.mvistaDesgloseProm = mvistaDesgloseProm;
		}

	}

	// adapter para la lista del desglose de impuestos
	private class adapterDesgloseImp extends ArrayAdapter<vistaDesgloseImp>
	{

		int textViewResourceId;
		Context context;

		public adapterDesgloseImp(Context context, int textViewResourceId, vistaDesgloseImp[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);
			}
			vistaDesgloseImp impuesto = getItem(position);

			TextView texto = (TextView) fila.findViewById(R.id.lblNombreImpuesto);
			if (texto != null)
				texto.setText(impuesto.getAbreviatura());

			texto = (TextView) fila.findViewById(R.id.lblPorcentajeImp);
			if (texto != null)
				texto.setText(Generales.getFormatoDecimal(impuesto.getPorcentaje() / 100, "##0.00 %"));
			// texto.setText(String.format("%.2f %%",
			// impuesto.getPorcentaje()));

			texto = (TextView) fila.findViewById(R.id.lblTotalImp);
			if (texto != null)
				texto.setText(Generales.getFormatoDecimal(impuesto.getImporte(), "$ #,##0.00"));
			// texto.setText(String.format("$ %.2f", impuesto.getImporte()));

			return fila;
		}

	}

	private class adapterDesglosePro extends ArrayAdapter<vistaDesgloseProm>
	{

		int textViewResourceId;
		Context context;

		public adapterDesglosePro(Context context, int textViewResourceId, ArrayList<vistaDesgloseProm> objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
		}

		@SuppressWarnings("unchecked")
		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);
			}
			vistaDesgloseProm Promociones = getItem(position);
			try
			{
				TextView texto = (TextView) fila.findViewById(R.id.txtProductoClavePromociones);
				if (texto != null)
					texto.setText(Promociones.getNombreProducto());

				ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lstProductoPromociones);
				ArrayList<vistaDesgloseProm> desglosePromociones;

				desglosePromociones = mPresenta.obtenerDesglosePromocion((ArrayList<String>) oParametros.get("TransProdId"), Promociones.getClaveProducto());
				if (desglosePromociones != null)
				{
					final adapterDesgloseProDetalle adapter = new adapterDesgloseProDetalle(CapturaTotalesConsignacion.this, R.layout.lista_pedidopromocion, desglosePromociones);
					modeListlblPromociones.setAdapter(adapter);
					setListViewHeightBasedOnChildren(modeListlblPromociones);
				}
			}
			catch (Exception e)
			{
				Log.e("", "", e);
			}
			return fila;
		}
	}
	
	@SuppressWarnings("deprecation")
	public void mostrarObligatorio(String mensaje, final int tipoMensaje, String...titulo)
	{

		DialogoAlerta dialogo = new DialogoAlerta(this);
		if(titulo.length > 0)
		{
			dialogo.setTitle(titulo[0]);
		}
		dialogo.setMessage(mensaje);
		dialogo.setCancelable(false);
		String msgSi = "Si";
		String msgNo = "No";
		if (Mensajes.existe())
		{
			msgSi = Mensajes.get("XSi");
			msgNo = Mensajes.get("XNo");
		}

		dialogo.setButton(msgSi, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.Si, tipoMensaje);
				dialog.dismiss();
			}
		});
		dialogo.setButton2(msgNo, new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int id)
			{
				respuestaMensaje(RespuestaMsg.No, tipoMensaje);
				dialog.cancel();
			}
		});
		dialogo.show();
	}

	private class adapterDesgloseProDetalle extends ArrayAdapter<vistaDesgloseProm>
	{

		int textViewResourceId;
		Context context;

		public adapterDesgloseProDetalle(Context context, int textViewResourceId, ArrayList<vistaDesgloseProm> objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);
			}
			LinearLayout llayoutClaveNombre = (LinearLayout) fila.findViewById(R.id.layoutClaveNombre);
			LinearLayout llayoutNombrePromocion = (LinearLayout) fila.findViewById(R.id.layoutNombrePromocion);
			LinearLayout mLlayoutImporteDes = (LinearLayout) fila.findViewById(R.id.layoutImporteDes);
			LinearLayout mLlayoutBonificacion = (LinearLayout) fila.findViewById(R.id.layoutBonificacion);
			LinearLayout llayoutCantidad = (LinearLayout) fila.findViewById(R.id.layoutCantidadRegalo);
			LinearLayout llayoutProdRegalo = (LinearLayout) fila.findViewById(R.id.layoutProdRegalo);
			LinearLayout llayoutPuntos = (LinearLayout) fila.findViewById(R.id.layoutPunto);
			LinearLayout llayoutPrecio = (LinearLayout) fila.findViewById(R.id.layoutPrecio);
			vistaDesgloseProm Promociones = getItem(position);
			TextView texto = (TextView) fila.findViewById(R.id.lblClavePromoValue);
			if (texto != null)
				texto.setText(Promociones.getClavePromocion());
			TextView textoCantidad = (TextView) fila.findViewById(R.id.lblNombrePromocionValue);
			if (textoCantidad != null)
				textoCantidad.setText(Promociones.getNombrePromocion());
			if (Promociones.getImporteDesc() != null)
			{
				llayoutNombrePromocion.setVisibility(View.VISIBLE);
				llayoutClaveNombre.setVisibility(View.VISIBLE);
				mLlayoutBonificacion.setVisibility(View.GONE);
				llayoutCantidad.setVisibility(View.GONE);
				llayoutProdRegalo.setVisibility(View.GONE);
				mLlayoutImporteDes.setVisibility(View.VISIBLE);
				llayoutPuntos.setVisibility(View.GONE);
				llayoutPrecio.setVisibility(View.GONE);
				texto = (TextView) fila.findViewById(R.id.lblImporteDesValue);
				texto.setText("$ " + Promociones.getImporteDesc());
			}
			if (Promociones.getBonificacion() != null)
			{
				llayoutNombrePromocion.setVisibility(View.VISIBLE);
				llayoutClaveNombre.setVisibility(View.VISIBLE);
				llayoutCantidad.setVisibility(View.GONE);
				llayoutProdRegalo.setVisibility(View.GONE);
				llayoutPuntos.setVisibility(View.GONE);
				mLlayoutImporteDes.setVisibility(View.GONE);
				mLlayoutBonificacion.setVisibility(View.VISIBLE);
				llayoutPrecio.setVisibility(View.GONE);
				texto = (TextView) fila.findViewById(R.id.lblBonificacionValue);
				texto.setText("$ " + Promociones.getBonificacion());
			}

			if (Promociones.getMvistaDesgloseProm() != null)
			{

				ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lvRegalos);
				modeListlblPromociones.setVisibility(View.VISIBLE);
				final adapterDesgloseProdRegalo adapter = new adapterDesgloseProdRegalo(CapturaTotalesConsignacion.this, R.layout.lista_pedidopromocion, Promociones.getMvistaDesgloseProm());
				modeListlblPromociones.setAdapter(adapter);
				setListViewHeightBasedOnChildren(modeListlblPromociones);

			}

			if (Promociones.getPuntos() != null)
			{
				llayoutNombrePromocion.setVisibility(View.VISIBLE);
				llayoutClaveNombre.setVisibility(View.VISIBLE);
				mLlayoutImporteDes.setVisibility(View.GONE);
				mLlayoutBonificacion.setVisibility(View.GONE);
				llayoutCantidad.setVisibility(View.GONE);
				llayoutPuntos.setVisibility(View.VISIBLE);
				llayoutProdRegalo.setVisibility(View.GONE);
				llayoutPrecio.setVisibility(View.GONE);
				texto = (TextView) fila.findViewById(R.id.lblPunotsValue);
				texto.setText(Promociones.getPuntos());

			}
			if (Promociones.getPrecio() != null)
			{
				llayoutNombrePromocion.setVisibility(View.VISIBLE);
				llayoutClaveNombre.setVisibility(View.VISIBLE);
				mLlayoutImporteDes.setVisibility(View.GONE);
				mLlayoutBonificacion.setVisibility(View.GONE);
				llayoutCantidad.setVisibility(View.GONE);
				llayoutPuntos.setVisibility(View.GONE);
				llayoutProdRegalo.setVisibility(View.GONE);
				llayoutPrecio.setVisibility(View.VISIBLE);
				ListView modeListlblPromociones = (ListView) fila.findViewById(R.id.lvRegalos);
				modeListlblPromociones.setVisibility(View.GONE);
				texto = (TextView) fila.findViewById(R.id.lblPrecioValue);
				texto.setText("$ " + Promociones.getPrecio());

			}

			return fila;
		}
	}

	private class adapterDesgloseProdRegalo extends ArrayAdapter<vistaDesgloseProm>
	{

		int textViewResourceId;
		Context context;

		public adapterDesgloseProdRegalo(Context context, int textViewResourceId, ArrayList<vistaDesgloseProm> objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
		}

		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			View fila = convertView;

			if (convertView == null)
			{
				LayoutInflater inflater = ((Activity) context).getLayoutInflater();
				fila = inflater.inflate(textViewResourceId, null);
			}
			LinearLayout llayoutClaveNombre = (LinearLayout) fila.findViewById(R.id.layoutClaveNombre);
			LinearLayout llayoutNombrePromocion = (LinearLayout) fila.findViewById(R.id.layoutNombrePromocion);
			LinearLayout mLlayoutImporteDes = (LinearLayout) fila.findViewById(R.id.layoutImporteDes);
			LinearLayout mLlayoutBonificacion = (LinearLayout) fila.findViewById(R.id.layoutBonificacion);
			LinearLayout llayoutCantidad = (LinearLayout) fila.findViewById(R.id.layoutCantidadRegalo);
			LinearLayout llayoutProdRegalo = (LinearLayout) fila.findViewById(R.id.layoutProdRegalo);
			LinearLayout llayoutPuntos = (LinearLayout) fila.findViewById(R.id.layoutPunto);
			LinearLayout llayoutPrecio = (LinearLayout) fila.findViewById(R.id.layoutPrecio);
			vistaDesgloseProm Promociones = getItem(position);

			TextView texto = (TextView) fila.findViewById(R.id.lblClavePromoValue);
			if (texto != null)
				texto.setText(Promociones.getClavePromocion());
			TextView textoCantidad = (TextView) fila.findViewById(R.id.lblNombrePromocionValue);
			if (textoCantidad != null)
				textoCantidad.setText(Promociones.getNombrePromocion());

			if (position == 0)
			{
				llayoutNombrePromocion.setVisibility(View.VISIBLE);
				llayoutClaveNombre.setVisibility(View.VISIBLE);
			}
			else
			{
				llayoutNombrePromocion.setVisibility(View.GONE);
				llayoutClaveNombre.setVisibility(View.GONE);
			}

			mLlayoutImporteDes.setVisibility(View.GONE);
			mLlayoutBonificacion.setVisibility(View.GONE);
			llayoutPuntos.setVisibility(View.GONE);
			llayoutCantidad.setVisibility(View.VISIBLE);
			llayoutProdRegalo.setVisibility(View.VISIBLE);
			llayoutPrecio.setVisibility(View.GONE);
			texto = (TextView) fila.findViewById(R.id.lblCantidadRegaloValue);
			texto.setText(Promociones.getCantidad());
			texto = (TextView) fila.findViewById(R.id.lblProdRegaloValue);
			texto.setText(Promociones.getProdRegalo());
			return fila;

		}

	}

	private Vista getVista()
	{
		return this;
	}

	private void setListViewHeightBasedOnChildren(ListView listView)
	{
		ListAdapter listAdapter = listView.getAdapter();
		if (listAdapter == null)
		{
			// pre-condition
			return;
		}

		int totalHeight = 0;
		int desiredWidth = MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.AT_MOST);
		for (int i = 0; i < listAdapter.getCount(); i++)
		{
			View listItem = listAdapter.getView(i, null, listView);
			listItem.measure(MeasureSpec.makeMeasureSpec(0, MeasureSpec.UNSPECIFIED),MeasureSpec.makeMeasureSpec(0, MeasureSpec.UNSPECIFIED));
			totalHeight += listItem.getMeasuredHeight();
		}

		ViewGroup.LayoutParams params = listView.getLayoutParams();
		params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));

		listView.setLayoutParams(params);
		listView.requestLayout();
		listView.setTag(true);
	}
	
	@Override
	public void impresionFinalizada(boolean impresionExitosa,String mensajeError)
	{
		if (mensajeError.equals(""))
			setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
		else			
			setResultado(Enumeradores.Resultados.RESULTADO_MAL, mensajeError);
		
		quitarProgreso();
		finalizar();
	}
	
}

