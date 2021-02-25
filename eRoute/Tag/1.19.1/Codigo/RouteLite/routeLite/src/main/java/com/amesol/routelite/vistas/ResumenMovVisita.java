package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.HashMap;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.os.Handler;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.ClienteDomicilio;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ResumirMovVisita;
import com.amesol.routelite.presentadores.interfaces.IAtencionClientes;
import com.amesol.routelite.presentadores.interfaces.IResumenMovVisita;
import com.amesol.routelite.utilerias.Generales;

public class ResumenMovVisita extends Vista implements IResumenMovVisita
{

	ResumirMovVisita mPresenta;
	String mAccion;
	HashMap<String, String> parametros;

	Cliente cliente;
	Dia dia;
	Visita visita;
	ISetDatos unidades;
	ListView listaPrincipal;
	Handler hnadler = new Handler();
	int tipoTransProdActual = -1;
	int tipoTransProdAnterior = -1;

	@SuppressWarnings(
	{ "unchecked", "deprecation" })
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			//requestWindowFeature(Window.FEATURE_NO_TITLE);
			//getWindow().clearFlags(Window.FEATURE_NO_TITLE);
			//getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN,WindowManager.LayoutParams.FLAG_FULLSCREEN);

			setContentView(R.layout.resumen_mov_visita);
			deshabilitarBarra(true);

			if (getIntent().getSerializableExtra("parametros") != null)
			{
				parametros = (HashMap<String, String>) getIntent().getSerializableExtra("parametros");
				setTitulo(Mensajes.get("XResumenMov") + " - " + parametros.get("visita"));
			}
			else
				setTitulo(Mensajes.get("XResumenMov"));

			Cliente cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			BDVend.recuperar(cliente, ClienteDomicilio.class);

			TextView texto = (TextView) findViewById(R.id.lblInfo);
			texto.setText("Información del Cliente");

			texto = (TextView) findViewById(R.id.lblClaveRazonSocial);
			texto.setText(cliente.Clave + " - " + cliente.RazonSocial);

			texto = (TextView) findViewById(R.id.lblNombreCliente);
			texto.setText(cliente.NombreContacto);

			texto = (TextView) findViewById(R.id.lblDireccion);
			for (int i = 0; i < cliente.ClienteDomicilio.size(); i++)
			{
				if (cliente.ClienteDomicilio.get(i).Tipo == 2)
				{ //punto de entrega
					String numInt = cliente.ClienteDomicilio.get(i).NumInt == null ? "" : "-" + cliente.ClienteDomicilio.get(i).NumInt;
					texto.setText(cliente.ClienteDomicilio.get(i).Calle + " " + cliente.ClienteDomicilio.get(i).Numero + numInt);
					break;
				}
			}

			unidades = Consultas.ConsultasValorReferencia.obtenerValoresReferencia("UNIDADV", "");
			startManagingCursor((Cursor) unidades.getOriginal());

			listaPrincipal = (ListView) findViewById(R.id.lstResumenMov);

			mPresenta = new ResumirMovVisita(this, mAccion);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mostrarError(e.getMessage());
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
                iniciarActividad(IAtencionClientes.class,true);
                //this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
        /*Se quitan las opciones del menu porque no sirven.*/
        /*Descomentar cuando se implementen*/
		/*MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.menu_resumen_mov_visita, menu);
		menu.getItem(0).setTitle(Mensajes.get("XImpresion") + " " + Mensajes.get("XDetalle"));
		menu.getItem(1).setTitle(Mensajes.get("XImpresion") + " " + Mensajes.get("XGeneral"));*/
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item)
	{
		switch (item.getItemId())
		{
			case R.id.impresion_detalle:
				//TODO: agregar metodo para imprimir ticket
				mostrarAdvertencia("Impresion detallada");
				return true;
			case R.id.impresion_general:
				//TODO: agregar metodo para imprimir ticket
				mostrarAdvertencia("Impresion general");
				return true;
			default:
				return super.onOptionsItemSelected(item);
		}
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

	@SuppressWarnings("deprecation")
	public void mostrarTransacciones()
	{

		try
		{
			cliente = (Cliente) Sesion.get(Campo.ClienteActual);

			dia = (Dia) Sesion.get(Campo.DiaActual);
			visita = (Visita) Sesion.get(Campo.VisitaActual);

			ListView detalle = (ListView) findViewById(R.id.lstResumenMov);
			ISetDatos movs = Consultas.ConsultasTransProd.obtenerMovimientosResumen(dia, cliente, visita, "1,3,8,9,10,20,21,24");
			//startManagingCursor((Cursor) movs.getOriginal());

			ArrayList<rowView> movimientos = new ArrayList<ResumenMovVisita.rowView>();
			while (movs.moveToNext())
			{
				if (tipoTransProdActual == -1 || tipoTransProdActual != movs.getInt(4))
				{ //movs.getInt("Tipo")){
					//agregar un elemento cuando cambie de transprod, este es el que se va a mostrar con el titulo
					rowView titulo = new rowView();
					titulo.Tipo = movs.getInt(4);//movs.getInt("Tipo");
					movimientos.add(titulo);
					tipoTransProdActual = movs.getInt(4); //movs.getInt("Tipo");
				}
				rowView mov = new rowView();
				mov.TransProdId = movs.getString(0); //movs.getString("_id");
				mov.Folio = movs.getString(1); //movs.getString("Folio");
				mov.TipoMotivo = movs.getInt(2); //movs.getInt("TipoMotivo");
				mov.Total = movs.getFloat(3); //movs.getFloat("Total");
				mov.Tipo = movs.getInt(4); //movs.getInt("Tipo");
				mov.Subtotal = movs.getFloat(5); //movs.getFloat("Subtotal");
				mov.Impuestos = movs.getFloat(6); //movs.getFloat("Impuesto");
				mov.DesctoVendCli = movs.getFloat(7); //movs.getFloat("Descuento");
				mov.FacturaID = movs.getString(8);
				movimientos.add(mov);
			}

			if (movs.getCount() <= 0)
				return;
            movs.close();
			tipoTransProdActual = -1;

			resumenMovsAdapter adapter = new resumenMovsAdapter(this, R.layout.elemento_detalle_resumen, movimientos.toArray(new rowView[movimientos.size()]));
			detalle.setAdapter(adapter);

		}
		catch (Exception ex)
		{
			mostrarError(ex.getMessage());
		}
	}

	private class rowView
	{
		String TransProdId;
		String Folio;
		int TipoMotivo;
		float Total;
		float Subtotal;
		float Impuestos;
		float DesctoVendCli;
		int Tipo;
		String FacturaID;
	}

	private class resumenMovsAdapter extends ArrayAdapter<rowView>
	{
		int textViewResourceId;
		LayoutInflater inflater;

		rowView[] objetos;
		View fila;

		public resumenMovsAdapter(Context context, int textViewResourceId, rowView[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			inflater = LayoutInflater.from(context);
			objetos = objects;
		}

		@Override
		public int getViewTypeCount()
		{
			return objetos.length;
		}

		@Override
		public int getItemViewType(int position)
		{
			return position;
		}

		@SuppressWarnings("deprecation")
		@Override
		public View getView(int position, View convertView, ViewGroup parent)
		{
			try
			{
				fila = convertView;
				Object holder;

				if (convertView == null)
				{
					if (tipoTransProdActual == -1 || tipoTransProdActual != ((rowView) getItem(position)).Tipo)
					{

						tipoTransProdActual = ((rowView) getItem(position)).Tipo;

						fila = inflater.inflate(R.layout.elemento_encabezado_resmov, null);
						holder = new holderEncabezado();
						((holderEncabezado) holder).NombreMov = (TextView) fila.findViewById(R.id.txtNombreMov);
						((holderEncabezado) holder).Titulo1 = (TextView) fila.findViewById(R.id.txtTitulo1);
						((holderEncabezado) holder).Titulo2 = (TextView) fila.findViewById(R.id.txtTitulo2);
						((holderEncabezado) holder).Titulo3 = (TextView) fila.findViewById(R.id.txtTitulo3);

						ISetDatos mov = Consultas.ConsultasTransProd.obtenerEncabezadosResumen(dia, cliente, visita, tipoTransProdActual);
						startManagingCursor((Cursor) mov.getOriginal());
						if (mov.getCount() > 0)
						{
							mov.moveToNext();
							((holderEncabezado) holder).NombreMov.setText(mov.getString(1));
						}

						if (((rowView) getItem(position)).Tipo == 3)
						{
							((holderEncabezado) holder).Titulo1.setText(Mensajes.get("XFolio"));
							((holderEncabezado) holder).Titulo2.setText(Mensajes.get("XMotivo"));
							((holderEncabezado) holder).Titulo3.setText(Mensajes.get("XTotal"));
						}
						else if (((rowView) getItem(position)).Tipo == 20)
						{
							((holderEncabezado) holder).Titulo1.setText("Clave de Promocion");
							((holderEncabezado) holder).Titulo2.setVisibility(View.GONE);
							((holderEncabezado) holder).Titulo3.setVisibility(View.GONE);
						}
						else if (((rowView) getItem(position)).Tipo == 11)
						{
							((holderEncabezado) holder).Titulo1.setVisibility(View.GONE);
							((holderEncabezado) holder).Titulo2.setVisibility(View.GONE);
							((holderEncabezado) holder).Titulo3.setVisibility(View.GONE);
						}
						else
						{
							((holderEncabezado) holder).Titulo1.setText(Mensajes.get("XFolio"));
							((holderEncabezado) holder).Titulo2.setVisibility(View.GONE);
						}
						((holderEncabezado) holder).Titulo3.setText(Mensajes.get("XTotal"));

					}
					else
					{

						rowView datos = getItem(position);
						holder = new holderMovimientos();

						if (datos.Tipo != 9) //cargar el layout para los movimientos
							fila = inflater.inflate(textViewResourceId, null);
						else if (datos.Tipo == 9) //cargar el layout para los cambios
							fila = inflater.inflate(R.layout.elemento_detalle_resumen_cambios, null);

						((holderMovimientos) holder).Columna1 = (TextView) fila.findViewById(R.id.txtColumna1);
						((holderMovimientos) holder).Columna2 = (TextView) fila.findViewById(R.id.txtColumna2);
						((holderMovimientos) holder).Columna3 = (TextView) fila.findViewById(R.id.txtColumna3);

						((holderMovimientos) holder).Titulo1 = (TextView) fila.findViewById(R.id.txtTitulo1);
						((holderMovimientos) holder).Titulo2 = (TextView) fila.findViewById(R.id.txtTitulo2);
						((holderMovimientos) holder).Titulo3 = (TextView) fila.findViewById(R.id.txtTitulo3);
						((holderMovimientos) holder).Titulo4 = (TextView) fila.findViewById(R.id.txtTitulo4);
						((holderMovimientos) holder).Titulo5 = (TextView) fila.findViewById(R.id.txtTitulo5);
						((holderMovimientos) holder).Titulo6 = (TextView) fila.findViewById(R.id.txtTitulo6);

						((holderMovimientos) holder).Boton = (ImageButton) fila.findViewById(R.id.btnMasMenos);

						((holderMovimientos) holder).lblSubtotal = (TextView) fila.findViewById(R.id.lblSubt);
						((holderMovimientos) holder).txtSubtotal = (TextView) fila.findViewById(R.id.txtSubt);
						((holderMovimientos) holder).lblDescto = (TextView) fila.findViewById(R.id.lblDescto);
						((holderMovimientos) holder).txtDescto = (TextView) fila.findViewById(R.id.txtDescto);
						((holderMovimientos) holder).lblImpuesto = (TextView) fila.findViewById(R.id.lblImpuesto);
						((holderMovimientos) holder).txtImpuesto = (TextView) fila.findViewById(R.id.txtImpuesto);
						((holderMovimientos) holder).lblTotal = (TextView) fila.findViewById(R.id.lblTotal);
						((holderMovimientos) holder).txtTotal = (TextView) fila.findViewById(R.id.txtTotal);

						((holderMovimientos) holder).lblRecibe = (TextView) fila.findViewById(R.id.lblRecibe);
						((holderMovimientos) holder).lblEntrega = (TextView) fila.findViewById(R.id.lblEntrega);

						((holderMovimientos) holder).Titulo11 = (TextView) fila.findViewById(R.id.txtTit1);
						((holderMovimientos) holder).Titulo22 = (TextView) fila.findViewById(R.id.txtTit2);
						((holderMovimientos) holder).Titulo33 = (TextView) fila.findViewById(R.id.txtTit3);
						((holderMovimientos) holder).Titulo44 = (TextView) fila.findViewById(R.id.txtTit4);
						((holderMovimientos) holder).Titulo55 = (TextView) fila.findViewById(R.id.txtTit5);
						((holderMovimientos) holder).Titulo66 = (TextView) fila.findViewById(R.id.txtTit6);

						if (datos.Tipo == 3)
						{
							//TODO: Devoluciones de cliente
							((holderMovimientos) holder).Titulo1.setText(Mensajes.get("XClave"));
							((holderMovimientos) holder).Titulo2.setText(Mensajes.get("XDesc"));
							((holderMovimientos) holder).Titulo3.setText(Mensajes.get("XCant."));
							((holderMovimientos) holder).Titulo4.setText(Mensajes.get("XUnidad"));
							((holderMovimientos) holder).Titulo5.setText(Mensajes.get("XPrecio"));
							((holderMovimientos) holder).Titulo6.setText(Mensajes.get("XSubtotal"));

							ListView detalle = (ListView) fila.findViewById(R.id.lstDetalleMov);
							ISetDatos movs = Consultas.ConsultasTransProd.obtenerDetalleMovResumen(datos.TransProdId);
							Cursor c = (Cursor) movs.getOriginal();
							startManagingCursor(c);
							SimpleCursorAdapter adapter = new SimpleCursorAdapter(getApplicationContext(), R.layout.lista_simple_hor6, c,
									new String[]
									{ "ProductoClave", "Nombre", "Cantidad", "TipoUnidad", "Precio", "Total" },
									new int[]
									{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5, R.id.txtCol6 });
							adapter.setViewBinder(new vistaDetalleMov());
							detalle.setAdapter(adapter);

							((holderMovimientos) holder).Boton.setOnClickListener(new OnClickListener()
							{

								@Override
								public void onClick(View v)
								{
									View parent = (View) v.getParent().getParent();
									ListView lst = (ListView) parent.findViewById(R.id.lstDetalleMov);
									LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layDetalle);

									if (lay.getVisibility() == View.GONE)
									{
										lay.setVisibility(View.VISIBLE);
										((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
										if (lst.getTag() == null)
										{
											setListViewHeightBasedOnChildren(lst);
										}
									}
									else
									{
										lay.setVisibility(View.GONE);
										((ImageButton) v).setImageResource(android.R.drawable.ic_menu_more);
									}
								}
							});

							LinearLayout totales = (LinearLayout) fila.findViewById(R.id.layTotales);
							totales.setVisibility(View.GONE);

							((holderMovimientos) holder).Columna1.setText(datos.Folio);
							((holderMovimientos) holder).Columna2.setText(ValoresReferencia.getDescripcion("TRPMOT", String.valueOf(datos.TipoMotivo)));
							((holderMovimientos) holder).Columna3.setText(Generales.getFormatoDecimal(obtenerTotales("'" + datos.TransProdId + "'"), "$ #,##0.00"));
						}
						else if (datos.Tipo == 9)
						{
							// Cambios de producto
							((holderMovimientos) holder).Titulo1.setText(Mensajes.get("XClave"));
							((holderMovimientos) holder).Titulo2.setText(Mensajes.get("XDesc"));
							((holderMovimientos) holder).Titulo3.setText(Mensajes.get("XCant."));
							((holderMovimientos) holder).Titulo4.setText(Mensajes.get("XUnidad"));
							((holderMovimientos) holder).Titulo5.setText(Mensajes.get("XPrecio"));
							((holderMovimientos) holder).Titulo6.setText(Mensajes.get("XSubtotal"));

							((holderMovimientos) holder).lblRecibe.setText(Mensajes.get("XRecibe") + ":");
							((holderMovimientos) holder).lblEntrega.setText(Mensajes.get("XEntrega") + ":");

							((holderMovimientos) holder).Titulo11.setText(Mensajes.get("XClave"));
							((holderMovimientos) holder).Titulo22.setText(Mensajes.get("XDesc"));
							((holderMovimientos) holder).Titulo33.setText(Mensajes.get("XCant."));
							((holderMovimientos) holder).Titulo44.setText(Mensajes.get("XUnidad"));
							((holderMovimientos) holder).Titulo55.setText(Mensajes.get("XPrecio"));
							((holderMovimientos) holder).Titulo66.setText(Mensajes.get("XSubtotal"));

							ListView detalle = (ListView) fila.findViewById(R.id.lstDetalleMov);
							ISetDatos movs = Consultas.ConsultasTransProd.obtenerDetalleMovResumen(datos.TransProdId);
							Cursor c = (Cursor) movs.getOriginal();
							startManagingCursor(c);
							SimpleCursorAdapter adapter = new SimpleCursorAdapter(getApplicationContext(), R.layout.lista_simple_hor6, c,
									new String[]
									{ "ProductoClave", "Nombre", "Cantidad", "TipoUnidad", "Precio", "Total" },
									new int[]
									{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5, R.id.txtCol6 });
							adapter.setViewBinder(new vistaDetalleMov());
							detalle.setAdapter(adapter);

							ListView detalle2 = (ListView) fila.findViewById(R.id.lstDetalleEntrega);
							ISetDatos movs2 = Consultas.ConsultasTransProd.obtenerDetalleMovResumen(datos.FacturaID);
							Cursor c2 = (Cursor) movs2.getOriginal();
							startManagingCursor(c2);
							SimpleCursorAdapter adapter2 = new SimpleCursorAdapter(getApplicationContext(), R.layout.lista_simple_hor6, c2,
									new String[]
									{ "ProductoClave", "Nombre", "Cantidad", "TipoUnidad", "Precio", "Total" },
									new int[]
									{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5, R.id.txtCol6 });
							adapter2.setViewBinder(new vistaDetalleMov());
							detalle2.setAdapter(adapter2);

							((holderMovimientos) holder).Boton.setOnClickListener(new OnClickListener()
							{

								@Override
								public void onClick(View v)
								{
									View parent = (View) v.getParent().getParent();
									ListView lst = (ListView) parent.findViewById(R.id.lstDetalleMov);
									ListView lst1 = (ListView) parent.findViewById(R.id.lstDetalleEntrega);
									LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layDetalle);

									if (lay.getVisibility() == View.GONE)
									{
										lay.setVisibility(View.VISIBLE);
										((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
										if (lst.getTag() == null)
										{
											setListViewHeightBasedOnChildren(lst);
											setListViewHeightBasedOnChildren(lst1);
										}
									}
									else
									{
										lay.setVisibility(View.GONE);
										((ImageButton) v).setImageResource(android.R.drawable.ic_menu_more);
									}
								}
							});

							((holderMovimientos) holder).Columna1.setText(datos.Folio);
							((holderMovimientos) holder).Columna2.setVisibility(View.GONE);
							((holderMovimientos) holder).Columna3.setText(Generales.getFormatoDecimal(obtenerTotales("'" + datos.TransProdId + "'"), "$ #,##0.00"));
						}
						else if (datos.Tipo == 11)
						{
							//Cuentas por Cobrar (cobranza)
							((holderMovimientos) holder).Columna3.setVisibility(View.GONE);

							((holderMovimientos) holder).Titulo1.setVisibility(View.GONE);
							((holderMovimientos) holder).Titulo2.setVisibility(View.GONE);
							((holderMovimientos) holder).Titulo3.setVisibility(View.GONE);
							((holderMovimientos) holder).Titulo4.setVisibility(View.GONE);
							((holderMovimientos) holder).Titulo5.setVisibility(View.GONE);
							((holderMovimientos) holder).Titulo6.setVisibility(View.GONE);

							((holderMovimientos) holder).Boton.setVisibility(View.GONE);

							((holderMovimientos) holder).Columna1.setText(Consultas.ConsultasValorReferencia.obtenerDescripcion("PAGO", String.valueOf(datos.TipoMotivo)));
							((holderMovimientos) holder).Columna2.setText(Generales.getFormatoDecimal(datos.Total, "$ #,##0.00"));
						}
						else if (datos.Tipo == 20)
						{
							//TODO: Surtir productos de promociones
							((holderMovimientos) holder).Columna2.setVisibility(View.GONE);
							((holderMovimientos) holder).Columna3.setVisibility(View.GONE);
						}
						else
						{ //pedidos, facturas, consignacion						
							((holderMovimientos) holder).Titulo1.setText(Mensajes.get("XClave"));
							((holderMovimientos) holder).Titulo2.setText(Mensajes.get("XDesc"));
							((holderMovimientos) holder).Titulo3.setText(Mensajes.get("XCant."));
							((holderMovimientos) holder).Titulo4.setText(Mensajes.get("XUnidad"));
							((holderMovimientos) holder).Titulo5.setText(Mensajes.get("XPrecio"));
							((holderMovimientos) holder).Titulo6.setText(Mensajes.get("XSubtotal"));

							((holderMovimientos) holder).lblSubtotal.setText(Mensajes.get("XSubtotal"));
							((holderMovimientos) holder).lblDescto.setText(Mensajes.get("XDescuento"));
							((holderMovimientos) holder).lblImpuesto.setText(Mensajes.get("XImpuesto"));
							((holderMovimientos) holder).lblTotal.setText(Mensajes.get("XTotal"));

							((holderMovimientos) holder).txtSubtotal.setText(Generales.getFormatoDecimal(datos.Subtotal, "$ #,##0.00"));
							float descProducto = Consultas.ConsultasTransProdDetalle.obtenerDescuentoProducto(datos.TransProdId);
							((holderMovimientos) holder).txtDescto.setText(Generales.getFormatoDecimal((datos.DesctoVendCli + descProducto), "$ #,##0.00"));
							((holderMovimientos) holder).txtImpuesto.setText(Generales.getFormatoDecimal(datos.Impuestos, "$ #,##0.00"));
							((holderMovimientos) holder).txtTotal.setText(Generales.getFormatoDecimal(datos.Total, "$ #,##0.00"));

							ListView detalle = (ListView) fila.findViewById(R.id.lstDetalleMov);
							ISetDatos movs = Consultas.ConsultasTransProd.obtenerDetalleMovResumen(datos.TransProdId);
							Cursor c = (Cursor) movs.getOriginal();
							startManagingCursor(c);
							SimpleCursorAdapter adapter = new SimpleCursorAdapter(getApplicationContext(), R.layout.lista_simple_hor6, c,
									new String[]
									{ "ProductoClave", "Nombre", "Cantidad", "TipoUnidad", "Precio", "Subtotal" },
									new int[]
									{ R.id.txtCol1, R.id.txtCol2, R.id.txtCol3, R.id.txtCol4, R.id.txtCol5, R.id.txtCol6 });
							adapter.setViewBinder(new vistaDetalleMov());
							detalle.setAdapter(adapter);

							((holderMovimientos) holder).Boton.setOnClickListener(new OnClickListener()
							{

								@Override
								public void onClick(View v)
								{
									View parent = (View) v.getParent().getParent();
									ListView lst = (ListView) parent.findViewById(R.id.lstDetalleMov);
									LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layDetalle);

									if (lay.getVisibility() == View.GONE)
									{
										lay.setVisibility(View.VISIBLE);
										((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
										if (lst.getTag() == null)
										{
											setListViewHeightBasedOnChildren(lst);
										}
									}
									else
									{
										lay.setVisibility(View.GONE);
										((ImageButton) v).setImageResource(android.R.drawable.ic_menu_more);
									}
								}
							});

							((holderMovimientos) holder).Columna1.setText(datos.Folio);
							((holderMovimientos) holder).Columna2.setVisibility(View.GONE);
							((holderMovimientos) holder).Columna3.setText(Generales.getFormatoDecimal(datos.Total, "$ #,##0.00"));
						}
					}

					fila.setTag(holder);
				}

				return fila;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public void setListViewHeightBasedOnChildren(ListView listView)
		{
			ListAdapter listAdapter = listView.getAdapter();
			if (listAdapter == null)
			{
				// pre-condition
				return;
			}

			int totalHeight = 0;
			//int desiredWidth = MeasureSpec.makeMeasureSpec(listView.getWidth(), MeasureSpec.AT_MOST);
			for (int i = 0; i < listAdapter.getCount(); i++)
			{
				View listItem = listAdapter.getView(i, null, listView);
				//listItem.measure(desiredWidth, MeasureSpec.UNSPECIFIED);
				listItem.measure(View.MeasureSpec.makeMeasureSpec(0, View.MeasureSpec.UNSPECIFIED), View.MeasureSpec.makeMeasureSpec(0, View.MeasureSpec.UNSPECIFIED));
				totalHeight += listItem.getMeasuredHeight();
			}

			/*
			 * if(listView.getTag() == null) totalHeight /= 4;
			 */

			ViewGroup.LayoutParams params = listView.getLayoutParams();
			params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));

			listView.setLayoutParams(params);
			listView.requestLayout();
			listView.setTag(true);
		}

		public double obtenerTotales(String TransProdID)
		{
			try
			{
				String res = "0";
				ISetDatos setDatos = Consultas.ConsultasTransProdDetalle.obtenerTotales(TransProdID);
				if (setDatos.moveToNext())
				{
					res = setDatos.getString(1);
				}
				setDatos.close();
				return res == null ? 0 : Double.parseDouble(res);
			}
			catch (Exception e)
			{
				return 0;
			}
		}
	}

	private static class holderEncabezado
	{
		TextView NombreMov;
		TextView Titulo1;
		TextView Titulo2;
		TextView Titulo3;
		//ListView Detalle;
	}

	private static class holderMovimientos
	{
		TextView Columna1;
		TextView Columna2;
		TextView Columna3;
		ImageButton Boton;
		TextView Titulo1;
		TextView Titulo2;
		TextView Titulo3;
		TextView Titulo4;
		TextView Titulo5;
		TextView Titulo6;
		//ListView Detalle;
		TextView lblSubtotal;
		TextView txtSubtotal;
		TextView lblDescto;
		TextView txtDescto;
		TextView lblImpuesto;
		TextView txtImpuesto;
		TextView lblTotal;
		TextView txtTotal;

		TextView lblRecibe;
		TextView lblEntrega;

		TextView Titulo11;
		TextView Titulo22;
		TextView Titulo33;
		TextView Titulo44;
		TextView Titulo55;
		TextView Titulo66;
	}

	private class vistaDetalleMov implements ViewBinder
	{

		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.txtCol4:
					unidades.moveToPosition(cursor.getInt(columnIndex) - 1);
					TextView unidad = (TextView) view;
					unidad.setText(unidades.getString(2));
					break;
				case R.id.txtCol3: //cantidad
				case R.id.txtCol5: //precio
					view.setVisibility(View.VISIBLE);
				case R.id.txtCol6: //subtotal
					TextView subtotal = (TextView) view;
					view.setVisibility(View.VISIBLE);
					subtotal.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "#,##0.00"));
					break;
				default:
					TextView text = (TextView) view;
					text.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}

	}

}
