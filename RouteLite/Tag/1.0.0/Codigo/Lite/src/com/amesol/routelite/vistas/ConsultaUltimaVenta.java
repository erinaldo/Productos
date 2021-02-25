package com.amesol.routelite.vistas;

import java.text.SimpleDateFormat;

import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.support.v4.widget.SimpleCursorAdapter;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.MeasureSpec;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.MOTConfiguracion;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ConsultarUltimaVenta;
import com.amesol.routelite.presentadores.interfaces.IConsultaUltimaVenta;
import com.amesol.routelite.utilerias.Generales;

public class ConsultaUltimaVenta extends Vista implements IConsultaUltimaVenta
{

	ConsultarUltimaVenta mPresenta;
	String mAccion;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		mAccion = getIntent().getAction();
		setContentView(R.layout.consulta_ultima_venta);
		deshabilitarBarra(true);

		setTitulo(Mensajes.get("MCNMostrarUltimaVenta"));

		TextView texto = (TextView) findViewById(R.id.lblFechaAlta);
		texto.setText(Mensajes.get("XFecha") + ": ");

		texto = (TextView) findViewById(R.id.lblFolio);
		texto.setText(Mensajes.get("XFolio") + ": ");

		texto = (TextView) findViewById(R.id.lblTotal);
		texto.setText(Mensajes.get("TRPTotal") + ": ");

		obtenerUltima();

		mPresenta = new ConsultarUltimaVenta(this, mAccion);
		mPresenta.iniciar();
	}

	@SuppressWarnings("deprecation")
	private void obtenerUltima()
	{
		try
		{
			MOTConfiguracion mot = (MOTConfiguracion) Sesion.get(Campo.MOTConfiguracion);
			ISetDatos ultimaVenta = null;
			if (mot.get("MostrarUltVta").toString().equals("1"))
			{ //ventas
				ultimaVenta = Consultas2.ConsultasTransProd.obtenerUltimaVenta();
			}
			else if (mot.get("MostrarUltVta").toString().equals("0"))
			{ //facturas
				ultimaVenta = Consultas2.ConsultasTransProd.obtenerUltimaFactura();
			}
			else if (mot.get("MostrarUltVta").toString().equals("2"))
			{ //ambas
				ultimaVenta = Consultas2.ConsultasTransProd.obtenerUltimaVentaAmbas();
			}

			Cursor cUltima = (Cursor) ultimaVenta.getOriginal();

			if (ultimaVenta.getCount() > 0)
			{
				ultimaVenta.moveToNext();
				TextView texto = (TextView) findViewById(R.id.txtFechaAlta);
				texto.setText(new SimpleDateFormat("dd/MM/yyyy").format(ultimaVenta.getDate("FechaHoraAlta")));

				texto = (TextView) findViewById(R.id.txtFolio);
				texto.setText(ultimaVenta.getString("Folio"));

				texto = (TextView) findViewById(R.id.txtTotal);
				texto.setText(Generales.getFormatoDecimal(ultimaVenta.getFloat("Total"), "$ #,##0.00"));
			}
			else
			{
				TextView texto = (TextView) findViewById(R.id.txtFechaAlta);
				texto.setText("");

				texto = (TextView) findViewById(R.id.txtFolio);
				texto.setText("");

				texto = (TextView) findViewById(R.id.txtTotal);
				texto.setText("");
			}

			startManagingCursor(cUltima);
			//se pasan todos los campos como parametro por que sino no se ve bien la vista
			SimpleCursorAdapter adapter = new SimpleCursorAdapter(this, R.layout.elemento_captura_producto, cUltima,
					new String[]
					{ "TipoUnidad", "ProductoClave", "Nombre", "Cantidad", "Precio", "DescuentoImp", "vacio", "vacio" },
					new int[]
					{ R.id.lblUnidadProductoClave, R.id.lblUnidadProductoClave, R.id.lblDescripcion, R.id.lblCantidad, R.id.lblPU, R.id.lblTotal, R.id.lblExistencia, R.id.lblCantidadOriginal });

			ListView lista = (ListView) findViewById(R.id.lstDetalle);
			adapter.setViewBinder(new vistaDetalles());
			lista.setAdapter(adapter);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
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

	}

	// viewbinder para la lista de productos
	private class vistaDetalles implements android.support.v4.widget.SimpleCursorAdapter.ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.lblUnidadProductoClave:
					TextView unidadproducto = (TextView) view;
					if (columnIndex == cursor.getColumnIndex("TipoUnidad"))
					{ // tipo unidad
						unidadproducto.setText(ValoresReferencia.getDescripcion("UNIDADV", cursor.getString(cursor.getColumnIndex("TipoUnidad"))));
					}
					else if (columnIndex == cursor.getColumnIndex("ProductoClave"))
					{ // producto clave
						unidadproducto.setText(unidadproducto.getText() + " - " + cursor.getString(columnIndex));
					}
					break;
				case R.id.lblPU:
				case R.id.lblTotal:
					TextView total = (TextView) view;
					total.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "$ #,##0.00"));
					break;
				case R.id.lblCantidad:
					TextView cantidad = (TextView) view;
					cantidad.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), cursor.getInt(cursor.getColumnIndex("DecimalProducto"))));

					break;
				case R.id.lblDescripcion:
					TextView lblDescripcion = (TextView) view;
					lblDescripcion.setText(cursor.getString(columnIndex));
					break;
				default:
					TextView texto = (TextView) view;
					texto.setText("");
					break;
			}
			return true;
		}
	}

}
