package com.amesol.routelite.vistas;

import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.MeasureSpec;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.ProgressBar;
import android.widget.SimpleCursorAdapter;
import android.widget.SimpleCursorAdapter.ViewBinder;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.ConsultarIndicadores;
import com.amesol.routelite.presentadores.interfaces.IConsultaIndicadores;
import com.amesol.routelite.utilerias.Generales;

public class ConsultaIndicadores extends Vista implements IConsultaIndicadores
{

	ConsultarIndicadores mPresenta;
	ListView listaPrincipal;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);

		setContentView(R.layout.consultar_indicadores);
		deshabilitarBarra(true);

		this.setTitulo(Mensajes.get("XIndicadoresCuotas"));

		Vendedor vendedor = (Vendedor) Sesion.get(Campo.VendedorActual);
		TextView lblSeller = (TextView) findViewById(R.id.lblNameSeller);
		lblSeller.setText(Mensajes.get("XNombreVend") + ": " + vendedor.Nombre);

		TextView fecha = (TextView) findViewById(R.id.lblFecha);
		fecha.setText(Mensajes.get("XFecha") + ": " + Generales.getFechaHoraActualStr("dd/MM/yyyy"));

		mPresenta = new ConsultarIndicadores(this);
		mPresenta.iniciar();
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				this.finish();
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

	public void mostrarIndicadores(String[] titulos)
	{
		if (titulos.length <= 0)
			return;
		ListView lista = (ListView) findViewById(R.id.lstIndicadores);
		listaPrincipal = lista;
		titulosAdapter adapter = new titulosAdapter(this, R.layout.elemento_consulta_indicador, titulos);
		lista.setAdapter(adapter);
	}

	private class titulosAdapter extends ArrayAdapter<String>
	{

		int textViewResourceId;
		Context context;
		LayoutInflater inflater;
		String[] objetos;
		View fila;

		public titulosAdapter(Context context, int textViewResourceId, String[] objects)
		{
			super(context, textViewResourceId, objects);
			this.textViewResourceId = textViewResourceId;
			this.context = context;
			objetos = objects;
			inflater = LayoutInflater.from(context);
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

				if (convertView == null)
				{
					fila = inflater.inflate(textViewResourceId, null);

					String nombre = getItem(position);
					TextView texto = (TextView) fila.findViewById(R.id.lblNombrePromocion);
					texto.setText(nombre);

					ImageView image = (ImageView) fila.findViewById(android.R.id.icon);
					if (nombre.equals("Producto"))
						image.setImageResource(R.drawable.producto);
					else if (nombre.equals("Cliente"))
						image.setImageResource(R.drawable.cliente);
					else if (nombre.equals("Esquemas de Producto") || nombre.equals("Esquema de Producto"))
						image.setImageResource(R.drawable.esquema_producto);
					else if (nombre.equals("Esquemas de Cliente") || nombre.equals("Esquema de Cliente"))
						image.setImageResource(R.drawable.esquema_cliente);
					else if (nombre.equals("Vendedor"))
						image.setImageResource(R.drawable.vendedor);

					ListView lista = (ListView) fila.findViewById(R.id.lstDetalle);
					if (nombre.equals(Mensajes.get("XProducto")))
					{
						// indicadorAdapter adapter = new
						// indicadorAdapter(context,
						// R.layout.elemento_consulta_indicador_det,
						// mPresenta.getCuotasProducto().toArray(new
						// CUOProducto[mPresenta.getCuotasProducto().size()]));
						startManagingCursor(mPresenta.getCuotasProducto());
						SimpleCursorAdapter adapter = new SimpleCursorAdapter(context, R.layout.elemento_consulta_indicador_det, mPresenta.getCuotasProducto(), new String[]
						{ "Descripcion", "Nombre", "Minimo", "Cantidad" }, new int[]
						{ R.id.lblDescripcionQuotas, R.id.lblClaveNombreProdQuotas, R.id.lblValorQuotas, R.id.lblPorcentajeQuotas });
						adapter.setViewBinder(new vistaDetalle());
						lista.setAdapter(adapter);
					}
					else if (nombre.equals(Mensajes.get("XVendedor")))
					{
						// indicadorAdapter adapter = new
						// indicadorAdapter(context,
						// R.layout.elemento_consulta_indicador_det,
						// mPresenta.getCuotasVendedor().toArray(new
						// CUOVendedor[mPresenta.getCuotasVendedor().size()]));
						startManagingCursor(mPresenta.getCuotasVendedor());
						SimpleCursorAdapter adapter = new SimpleCursorAdapter(context, R.layout.elemento_consulta_indicador_det, mPresenta.getCuotasVendedor(), new String[]
						{ "Descripcion", "Nombre", "Minimo", "Cantidad" }, new int[]
						{ R.id.lblDescripcionQuotas, R.id.lblClaveNombreProdQuotas, R.id.lblValorQuotas, R.id.lblPorcentajeQuotas });
						adapter.setViewBinder(new vistaDetalle());
						lista.setAdapter(adapter);
					}
					else if (nombre.equals(Mensajes.get("XEsquemasCliente")))
					{
						// indicadorAdapter adapter = new
						// indicadorAdapter(context,
						// R.layout.elemento_consulta_indicador_det,
						// mPresenta.getCuotasEsquemaCli().toArray(new
						// CUOEsquema[mPresenta.getCuotasEsquemaCli().size()]));
						startManagingCursor(mPresenta.getCuotasEsquemaCli());
						SimpleCursorAdapter adapter = new SimpleCursorAdapter(context, R.layout.elemento_consulta_indicador_det, mPresenta.getCuotasEsquemaCli(), new String[]
						{ "Descripcion", "Nombre", "Minimo", "Cantidad" }, new int[]
						{ R.id.lblDescripcionQuotas, R.id.lblClaveNombreProdQuotas, R.id.lblValorQuotas, R.id.lblPorcentajeQuotas });
						adapter.setViewBinder(new vistaDetalle());
						lista.setAdapter(adapter);
					}
					else if (nombre.equals(Mensajes.get("XEsquemasProducto")))
					{
						// indicadorAdapter adapter = new
						// indicadorAdapter(context,
						// R.layout.elemento_consulta_indicador_det,
						// mPresenta.getCuotasEsquemaPro().toArray(new
						// CUOEsquema[mPresenta.getCuotasEsquemaPro().size()]));
						startManagingCursor(mPresenta.getCuotasEsquemaPro());
						SimpleCursorAdapter adapter = new SimpleCursorAdapter(context, R.layout.elemento_consulta_indicador_det, mPresenta.getCuotasEsquemaPro(), new String[]
						{ "Descripcion", "Nombre", "Minimo", "Cantidad" }, new int[]
						{ R.id.lblDescripcionQuotas, R.id.lblClaveNombreProdQuotas, R.id.lblValorQuotas, R.id.lblPorcentajeQuotas });
						adapter.setViewBinder(new vistaDetalle());
						lista.setAdapter(adapter);
					}
					else if (nombre.equals(Mensajes.get("XCliente")))
					{
						// indicadorAdapter adapter = new
						// indicadorAdapter(context,
						// R.layout.elemento_consulta_indicador_det,
						// mPresenta.getCuotasCliente().toArray(new
						// CUOCliente[mPresenta.getCuotasCliente().size()]));
						startManagingCursor(mPresenta.getCuotasCliente());
						SimpleCursorAdapter adapter = new SimpleCursorAdapter(context, R.layout.elemento_consulta_indicador_det, mPresenta.getCuotasCliente(), new String[]
						{ "Descripcion", "Nombre", "Minimo", "Cantidad" }, new int[]
						{ R.id.lblDescripcionQuotas, R.id.lblClaveNombreProdQuotas, R.id.lblValorQuotas, R.id.lblPorcentajeQuotas });
						adapter.setViewBinder(new vistaDetalle());
						lista.setAdapter(adapter);
					}

					ImageButton btn = (ImageButton) fila.findViewById(R.id.btnMasMenos);
					btn.setOnClickListener(new OnClickListener()
					{

						@Override
						public void onClick(View v)
						{
							View parent = (View) v.getParent().getParent();
							ListView lst = (ListView) parent.findViewById(R.id.lstDetalle);
							LinearLayout lay = (LinearLayout) parent.findViewById(R.id.layDetalle);

							if (lay.getVisibility() == View.GONE)
							{
								// lst.setVisibility(View.VISIBLE);
								lay.setVisibility(View.VISIBLE);
								((ImageButton) v).setImageResource(R.drawable.ic_menu_contraer);
								if (lst.getTag() == null)
									setListViewHeightBasedOnChildren(lst);
							}
							else
							{
								// lst.setVisibility(View.GONE);
								lay.setVisibility(View.GONE);
								((ImageButton) v).setImageResource(R.drawable.ic_menu_more);
							}
						}
					});
				}

				return fila;
			}
			catch (Exception ex)
			{
				return null;
			}
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
	}

	private class vistaDetalle implements ViewBinder
	{
		@Override
		public boolean setViewValue(View view, Cursor cursor, int columnIndex)
		{
			int viewId = view.getId();
			switch (viewId)
			{
				case R.id.lblValorQuotas:
					TextView text = (TextView) view;
					text.setText(Generales.getFormatoDecimal(cursor.getFloat(columnIndex), "#,##0.00"));
					break;
				case R.id.lblPorcentajeQuotas:
					float minimo = cursor.getFloat(3); // minimo
					float cantidad = cursor.getFloat(columnIndex); // cantidad
					int porcentaje = (int) ((cantidad * 100) / minimo);
					TextView lblPor = (TextView) view;
					lblPor.setText(porcentaje + " %");

					ProgressBar progress = (ProgressBar) ((LinearLayout) view.getParent()).findViewById(R.id.progressIndicador);
					progress.setProgress(porcentaje);
					break;
				default:
					ImageView imageIcon = (ImageView) ((LinearLayout) view.getParent()).findViewById(R.id.imgIcono);

					switch (cursor.getInt(4))
					{ // tipo
						case 0: // ninguno
							imageIcon.setImageDrawable(null);
							break;
						case 1: // producto
							imageIcon.setImageResource(R.drawable.indicador_producto);
							break;
						case 2: // efectivo
							imageIcon.setImageResource(R.drawable.indicador_efectivo);
							break;
						case 3: // kilos
							imageIcon.setImageResource(R.drawable.indicador_kilos);
							break;
						case 4: // cobranza?
							imageIcon.setImageResource(R.drawable.indicador_cobranza);
							break;
					}

					TextView texto = (TextView) view;
					texto.setText(cursor.getString(columnIndex));
					break;
			}
			return true;
		}
	}

}
