package com.amesol.routelite.vistas;

import java.util.HashMap;

import android.app.SearchManager;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.SimpleCursorAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.Transacciones;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.TransProd;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.CancelarPedido;
import com.amesol.routelite.presentadores.interfaces.ICancelaPedido;

public class CancelaPedido extends Vista implements ICancelaPedido
{

	CancelarPedido mPresenta;
	String mAccion;
	HashMap<String, String> oParametros = null;
	String sTransProdId;
	TransProd oTrp;
	Boolean manejoDobleUnidad = false;

	@SuppressWarnings(
	{ "unchecked", "deprecation" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			setContentView(R.layout.cancela_pedido);
			setTitulo(Mensajes.get("XCancelar"));

			mAccion = getIntent().getAction();
			deshabilitarBarra(true);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				oParametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
				sTransProdId = oParametros.get("TransProdId");
				oTrp = Transacciones.Pedidos.ObtenerPedido(sTransProdId);
			}

			if (((MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion)).get("ManejoDobleUnidad").toString().equals("1"))
			{
				manejoDobleUnidad = true;
			}
			ISetDatos motivos = Consultas.ConsultasValorReferencia.obtenerValoresPorGrupo("TRPMOT", "'Cancelacion'", Mensajes.get("XSeleccionar", new String[]
			{ Mensajes.get("XMotivo") }), false);
			Cursor valores = (Cursor) motivos.getOriginal();
			startManagingCursor(valores);
			Spinner spin = (Spinner) findViewById(R.id.cmbMotivoCancela);
			if (motivos.getCount() <= 1) //si no hay motivos, mostrar deshabilitado
				spin.setEnabled(false);
			else
			{
				SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, android.R.layout.simple_spinner_item, valores,
						new String[]
						{ SearchManager.SUGGEST_COLUMN_TEXT_1 },
						new int[]
						{ android.R.id.text1 });
				adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
				spin.setAdapter(adapter);
			}

			TextView texto = (TextView) findViewById(R.id.lblFolio);
			texto.setText(oTrp.Folio);
			texto = (TextView) findViewById(R.id.lblRuta);
			texto.setText(Mensajes.get("XRuta") + ": " + ((Ruta) Sesion.get(Campo.RutaActual)).Descripcion);
			texto = (TextView) findViewById(R.id.lblDia);
			texto.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
			texto = (TextView) findViewById(R.id.lblMotivoCancela);
			texto.setText(Mensajes.get("XMotivo"));

			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("XContinuar"));
			btn.setOnClickListener(mContinuar);

			mPresenta = new CancelarPedido(this, mAccion);
			mPresenta.iniciar();
		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private OnClickListener mContinuar = new OnClickListener()
	{

		@Override
		public void onClick(View v)
		{
			if (getTipoMotivo() <= 0)
			{
				mostrarError(Mensajes.get("E0161", Mensajes.get("XMotivo")));
			}
			else
			{
                Button btn = (Button) findViewById(R.id.btnContinuar);
                btn.setEnabled(false);

				int cancelaPedido = 0;
				if (manejoDobleUnidad){
					cancelaPedido = mPresenta.cancelarPedidoDobleUnidad(oTrp);
				}else {
					cancelaPedido = mPresenta.cancelarPedido(oTrp);
				}
				if (cancelaPedido == 1) { //tiene activado el parametro preliquidacion y todo salio bien
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
				else if(cancelaPedido == 2)
				{
					mostrarError(Mensajes.get("E0590"));// tiene activado el parametro preLiquidacion pero algo no esta bien
                    btn.setEnabled(true);
				}
				else if(cancelaPedido == 3)// no tiene el parametro preliquidacion activado
				{
					setResultado(Enumeradores.Resultados.RESULTADO_BIEN);
					finalizar();
				}
				else if(cancelaPedido == 0)
				{
					try
					{
						BDVend.rollback();
                        btn.setEnabled(true);
					}
					catch (Exception e)
					{
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				}


			}
			
		}
	};

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				mostrarPreguntaSiNo(Mensajes.get("BP0002"), 4);
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	public short getTipoMotivo()
	{
		Spinner spin = (Spinner) findViewById(R.id.cmbMotivoCancela);
		if (spin.isEnabled())
			return (short) spin.getSelectedItemId();
		else
			return 0;
	}

	@Override
	public void iniciar()
	{

	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{

	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		if (respuesta == RespuestaMsg.Si && tipoMensaje == 4)
		{
			setResultado(Enumeradores.Resultados.RESULTADO_MAL);
			finalizar();
		}
	}

}
