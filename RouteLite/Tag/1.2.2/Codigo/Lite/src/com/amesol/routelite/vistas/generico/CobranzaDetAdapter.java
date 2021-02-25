package com.amesol.routelite.vistas.generico;

import java.util.ArrayList;
import java.util.LinkedList;

import android.app.Activity;
import android.content.Context;
import android.text.Editable;
import android.text.TextWatcher;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.View.OnFocusChangeListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Spinner;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Cobranza.VistaDetalle;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.presentadores.act.CapturarCobranzaDet;
import com.amesol.routelite.utilerias.Generales;

public class CobranzaDetAdapter extends ArrayAdapter<Cobranza.VistaDetalle>
{
	int textViewResourceId;
	Context context;
	ArrayList<Cobranza.VistaDetalle> data;
	LinkedList<Cobranza.VistaSpinner> pagos;
	LinkedList<Cobranza.VistaSpinner> monedas;
	LinkedList<Cobranza.VistaSpinner> bancos;
	boolean habilitar;
	static final int DATE_DIALOG_ID = 1;
	Cobranza.VistaDetalle detalleSel;
	ArrayList<Integer> tiposCP;
	CapturarCobranzaDet mPresenta;
	private LayoutInflater inflater = null;

	static class ViewHolder
	{
		TextView lblFormaPago;
		TextView lblImporte;
		TextView lblFormaPagoDet;
		EditText txtFormaPago;
		Spinner spnFormaPago;
		TextView lblMoneda;
		EditText txtMoneda;
		Spinner spnMoneda;
		TextView lblImporteDet;
		EditText txtImporte;
		TextView lblBanco;
		EditText txtBanco;
		Spinner spnBanco;
		TextView lblReferencia;
		EditText txtReferencia;
		TextView lblFechaCheque;
		TextView txtFechaCheque;

		View layDetalle;
		View layLista;
		ImageButton btnExpandir;
		ImageButton btnContraer;
		int posicion;

		// Cobranza.VistaDetalle detalle;

	}

	public CobranzaDetAdapter(Context context, int textViewResourceId, CapturarCobranzaDet mPresenta, ArrayList<Cobranza.VistaDetalle> objects, LinkedList<Cobranza.VistaSpinner> pagos, LinkedList<Cobranza.VistaSpinner> monedas, LinkedList<Cobranza.VistaSpinner> bancos, ArrayList<Integer> tiposCP, boolean habilitar)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		this.data = objects;
		this.pagos = pagos;
		this.monedas = monedas;
		this.bancos = bancos;
		this.tiposCP = tiposCP;
		this.habilitar = habilitar;
		this.mPresenta = mPresenta;
		// inflater = LayoutInflater.from(context);
	}

	/*
	 * @Override public int getViewTypeCount() { return objects.size(); }
	 * 
	 * @Override public int getItemViewType(int position) { return position; }
	 */

	@Override
	public View getView(int position, View convertView, ViewGroup parent)
	{
		View fila = convertView;
		// this.posicion = position;

		final ViewHolder holder;
		if (convertView == null)
		{
			LayoutInflater inflater = ((Activity) context).getLayoutInflater();
			fila = inflater.inflate(textViewResourceId, null);
			// convertView = inflater.inflate(R.layout.list_row_posts, null);

			holder = new ViewHolder();
			holder.lblFormaPago = (TextView) fila.findViewById(R.id.lblFormaPago);
			holder.lblImporte = (TextView) fila.findViewById(R.id.lblImporte);

			holder.lblFormaPagoDet = (TextView) fila.findViewById(R.id.lblFormaPagoDet);
			holder.lblFormaPagoDet.setText(Mensajes.get("XFormaPago"));
			holder.txtFormaPago = (EditText) fila.findViewById(R.id.txtFormaPago);
			holder.spnFormaPago = (Spinner) fila.findViewById(R.id.spnFormaPago);
			if (!habilitar)
			{
				holder.txtFormaPago.setEnabled(false);
				holder.spnFormaPago.setVisibility(View.GONE);
			}
			else
			{
				holder.txtFormaPago.setVisibility(View.GONE);
				poblarSpinner(holder.spnFormaPago, pagos);
				holder.spnFormaPago.setEnabled(false);
			}

			holder.lblMoneda = (TextView) fila.findViewById(R.id.lblMoneda);
			holder.lblMoneda.setText(Mensajes.get("XMoneda"));
			holder.txtMoneda = (EditText) fila.findViewById(R.id.txtMoneda);
			holder.spnMoneda = (Spinner) fila.findViewById(R.id.spnMoneda);
			holder.spnMoneda.setTag(position);
			if (!habilitar)
			{
				holder.txtMoneda.setEnabled(false);
				holder.spnMoneda.setVisibility(View.GONE);
			}
			else
			{
				holder.txtMoneda.setVisibility(View.GONE);
				poblarSpinner(holder.spnMoneda, monedas);
				holder.spnMoneda.setOnItemSelectedListener(new OnItemSelectedListener()
				{

					@Override
					public void onItemSelected(AdapterView<?> parent, View view, int pos, long id)
					{
						VistaDetalle oDet = data.get(holder.posicion);

						if (!oDet.getMonedaId().equals(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId()))
						{
							if (mPresenta.validarDetalleInexistente(oDet.getTipoPago(), ((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId(), oDet.getTipoBanco(), oDet.getReferencia()))
							{
								oDet.setMonedaId(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId());
								oDet.setMoneda(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).toString());
							}
							else
							{
								for (int i = 0; i < monedas.size(); i++)
								{
									if (oDet.getMonedaId() == ((Cobranza.VistaSpinner) monedas.get(i)).getId())
									{
										holder.spnMoneda.setSelection(i);
										break;
									}
								}
							}
						}
					}

					@Override
					public void onNothingSelected(AdapterView<?> parent)
					{
						// Do nothing.
					}
				});
			}

			holder.lblImporteDet = (TextView) fila.findViewById(R.id.lblImporteDet);
			holder.lblImporteDet.setText(Mensajes.get("XImporte"));
			holder.txtImporte = (EditText) fila.findViewById(R.id.txtImporte);
			holder.txtImporte.setTag(position);
			if (!habilitar)
			{
				holder.txtImporte.setEnabled(false);
			}
			else
			{
				/*
				 * holder.txtImporte.setOnFocusChangeListener(new
				 * OnFocusChangeListener() {
				 * 
				 * @Override public void onFocusChange(View v, boolean hasFocus)
				 * { if (!hasFocus){
				 * 
				 * String sImporte = ((EditText)v).getText().toString(); if
				 * (sImporte.equals("")) sImporte = "0";
				 * 
				 * VistaDetalle oDet = data.get(holder.posicion); float
				 * importeInicial = oDet.getImporte();
				 * //getItem(holder.posicion).getImporte();
				 * 
				 * oDet.setImporte(Generales.getFloat(sImporte.toString(), 2));
				 * mPresenta.actualizarImporte(importeInicial,
				 * oDet.getImporte());
				 * 
				 * holder.lblImporte.setText(String.format("$ %.2f",
				 * oDet.getImporte()));
				 * 
				 * //((EditText)v).setText(String.format("$ %.2f",
				 * oDet.getImporte())); } }
				 * 
				 * });
				 */

				holder.txtImporte.addTextChangedListener(new TextWatcher()
				{

					@Override
					public void onTextChanged(CharSequence s, int start, int before, int count)
					{
						// TODO Auto-generated method stub
					}

					@Override
					public void beforeTextChanged(CharSequence s, int start, int count, int after)
					{
						// TODO Auto-generated method stub

					}

					@Override
					public void afterTextChanged(Editable s)
					{

						String sImporte = s.toString();
						if (sImporte.equals(""))
							sImporte = "0";

						VistaDetalle oDet = data.get(holder.posicion);
						float importeInicial = oDet.getImporte(); // getItem(holder.posicion).getImporte();

						oDet.setImporte(Generales.getRound(Float.parseFloat(sImporte.toString()), 2));
						mPresenta.actualizarImporte(importeInicial, oDet.getImporte());

						holder.lblImporte.setText(String.format("$ %.2f", oDet.getImporte()));

					}
				});
			}

			holder.lblBanco = (TextView) fila.findViewById(R.id.lblBanco);
			holder.lblBanco.setText(Mensajes.get("XBanco"));
			holder.txtBanco = (EditText) fila.findViewById(R.id.txtBanco);
			holder.spnBanco = (Spinner) fila.findViewById(R.id.spnBanco);
			holder.spnBanco.setTag(position);
			if (!habilitar)
			{
				holder.txtBanco.setEnabled(false);
				holder.spnBanco.setVisibility(View.GONE);
			}
			else
			{
				holder.txtBanco.setVisibility(View.GONE);
				poblarSpinner(holder.spnBanco, bancos);
				holder.spnBanco.setOnItemSelectedListener(new OnItemSelectedListener()
				{

					@Override
					public void onItemSelected(AdapterView<?> parent, View view, int pos, long id)
					{
						VistaDetalle oDet = data.get(holder.posicion);

						if (!Integer.toString(oDet.getTipoBanco()).equals(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId()))
						{
							if (mPresenta.validarDetalleInexistente(oDet.getTipoPago(), oDet.getMonedaId(), Integer.parseInt(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId()), oDet.getReferencia()))
							{
								oDet.setTipoBanco(Integer.parseInt(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).getId()));
								oDet.setBanco(((Cobranza.VistaSpinner) parent.getItemAtPosition(pos)).toString());
							}
							else
							{
								for (int i = 0; i < bancos.size(); i++)
								{
									if (Integer.toString(oDet.getTipoBanco()).equals(((Cobranza.VistaSpinner) bancos.get(i)).getId()))
									{
										holder.spnBanco.setSelection(i);
										break;
									}
								}
							}
						}
					}

					@Override
					public void onNothingSelected(AdapterView<?> parent)
					{
						// Do nothing.
					}
				});
			}

			holder.lblReferencia = (TextView) fila.findViewById(R.id.lblReferencia);
			holder.lblReferencia.setText(Mensajes.get("XReferencia"));
			holder.txtReferencia = (EditText) fila.findViewById(R.id.txtReferencia);
			holder.txtReferencia.setTag(position);
			if (!habilitar)
				holder.txtReferencia.setEnabled(false);
			else
			{
				holder.txtReferencia.setOnFocusChangeListener(new OnFocusChangeListener()
				{

					@Override
					public void onFocusChange(View v, boolean hasFocus)
					{
						if (!hasFocus)
						{
							VistaDetalle oDet = data.get(holder.posicion);

							if (!oDet.getReferencia().equals(((EditText) v).getText().toString()))
							{
								if (mPresenta.validarDetalleInexistente(oDet.getTipoPago(), oDet.getMonedaId(), oDet.getTipoBanco(), ((EditText) v).getText().toString()))
								{
									oDet.setReferencia(((EditText) v).getText().toString());
								}
								else
								{
									holder.txtReferencia.setText(oDet.getReferencia());
								}
							}
						}
					}
				});

				/*
				 * holder.txtReferencia.addTextChangedListener(new TextWatcher()
				 * {
				 * 
				 * @Override public void onTextChanged(CharSequence s, int
				 * start, int before, int count) { // TODO Auto-generated method
				 * stub }
				 * 
				 * @Override public void beforeTextChanged(CharSequence s, int
				 * start, int count, int after) { // TODO Auto-generated method
				 * stub
				 * 
				 * }
				 * 
				 * @Override public void afterTextChanged(Editable s) {
				 * VistaDetalle oDet = data.get(holder.posicion);
				 * 
				 * if (!oDet.getReferencia().equals(s.toString())){ if
				 * (mPresenta.validarDetalleInexistente(oDet.getTipoPago(),
				 * oDet.getMonedaId(), oDet.getTipoBanco(), s.toString())){
				 * oDet.setReferencia(s.toString()); } } } });
				 */
			}

			holder.lblFechaCheque = (TextView) fila.findViewById(R.id.lblFechaCheque);
			holder.lblFechaCheque.setText(Mensajes.get("XFecha"));
			holder.txtFechaCheque = (TextView) fila.findViewById(R.id.txtFechaCheque);
			holder.txtFechaCheque.setTag(position);
			if (habilitar)
			{
				holder.txtFechaCheque.setOnClickListener(new OnClickListener()
				{

					@Override
					public void onClick(View v)
					{
						VistaDetalle oDet = data.get(holder.posicion);

						if (tiposCP.contains(oDet.getTipoPago()))
						{
							detalleSel = oDet;
							((Activity) context).showDialog(DATE_DIALOG_ID);
						}
					}

				});

			}

			holder.layDetalle = fila.findViewById(R.id.layDetalle);
			holder.layLista = fila.findViewById(R.id.layLista);

			holder.btnExpandir = (ImageButton) fila.findViewById(R.id.btnExpandirPago);
			holder.btnExpandir.setFocusable(false);
			holder.btnExpandir.setOnClickListener(new OnClickListener()
			{
				@Override
				public void onClick(View v)
				{
					View vParent = (View) v.getParent().getParent();

					View layDetalle = vParent.findViewById(R.id.layDetalle);
					if (layDetalle.getVisibility() == View.GONE)
						layDetalle.setVisibility(View.VISIBLE);

					View layLista = vParent.findViewById(R.id.layLista);
					if (layLista.getVisibility() == View.VISIBLE)
						layLista.setVisibility(View.GONE);
				}
			});

			holder.btnContraer = (ImageButton) fila.findViewById(R.id.btnContraerPago);
			holder.btnContraer.setFocusable(false);
			holder.btnContraer.setOnClickListener(new OnClickListener()
			{
				@Override
				public void onClick(View v)
				{
					View vParent = (View) v.getParent().getParent().getParent();

					View layLista = vParent.findViewById(R.id.layLista);
					if (layLista.getVisibility() == View.GONE)
						layLista.setVisibility(View.VISIBLE);

					View layDetalle = vParent.findViewById(R.id.layDetalle);
					if (layDetalle.getVisibility() == View.VISIBLE)
						layDetalle.setVisibility(View.GONE);
				}
			});

			// holder.detalle = getItem(position);
			// holder.posicion = position;

			fila.setTag(holder);
		}
		else
			holder = (ViewHolder) fila.getTag();

		// fila.setTag(position, holder);
		// fila.setFocusable(true);

		holder.posicion = position;

		try
		{

			Cobranza.VistaDetalle detalle = getItem(position);
			// detalle = holder.detalle;

			holder.lblFormaPago.setText(detalle.getPago());
			holder.lblImporte.setText(String.format("$ %.2f", detalle.getImporte()));

			if (!habilitar)
			{
				holder.txtFormaPago.setText(detalle.getPago());
			}
			else
			{
				for (int i = 0; i < pagos.size(); i++)
				{
					if (Integer.toString(detalle.getTipoPago()).equals(((Cobranza.VistaSpinner) pagos.get(i)).getId()))
					{
						holder.spnFormaPago.setSelection(i);
						break;
					}
				}
			}

			if (!habilitar)
			{
				holder.txtMoneda.setText(detalle.getMoneda());
			}
			else
			{
				for (int i = 0; i < monedas.size(); i++)
				{
					if (detalle.getMonedaId() == ((Cobranza.VistaSpinner) monedas.get(i)).getId())
					{
						holder.spnMoneda.setSelection(i);
						break;
					}
				}
			}

			if (!habilitar)
			{
				holder.txtImporte.setText(String.format("$ %.2f", detalle.getImporte()));
			}
			else
			{

				holder.txtImporte.setText(Float.toString(detalle.getImporte()));
			}

			if (!habilitar)
			{
				holder.txtBanco.setText(detalle.getBanco());
			}
			else
			{
				for (int i = 0; i < bancos.size(); i++)
				{
					if (Integer.toString(detalle.getTipoBanco()).equals(((Cobranza.VistaSpinner) bancos.get(i)).getId()))
					{
						holder.spnBanco.setSelection(i);
						break;
					}
				}

				if (detalle.getTipoPago() == 1)
					holder.spnBanco.setEnabled(false);
				else
					holder.spnBanco.setEnabled(true);

			}

			holder.txtReferencia.setText(detalle.getReferencia());
			if (habilitar)
			{
				if (detalle.getTipoPago() != 1)
				{
					holder.txtReferencia.setEnabled(true);
				}
				else
					holder.txtReferencia.setEnabled(false);
			}

			if (detalle.getFechaCheque() != null)
				holder.txtFechaCheque.setText(DateFormat.format("dd/MM/yyyy", detalle.getFechaCheque()));
			else
				holder.txtFechaCheque.setText("");

			if (holder.layDetalle.getVisibility() == View.VISIBLE && holder.layLista.getVisibility() == View.VISIBLE)
				holder.layDetalle.setVisibility(View.GONE);

			return fila;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			return fila;
		}
	}

	public Cobranza.VistaDetalle getDetalle()
	{
		return detalleSel;
	}

	private void poblarSpinner(Spinner control, LinkedList<Cobranza.VistaSpinner> oValores)
	{
		ArrayAdapter<Cobranza.VistaSpinner> adapter = new ArrayAdapter<Cobranza.VistaSpinner>(context, android.R.layout.simple_spinner_item, oValores);
		adapter.setDropDownViewResource(android.R.layout.simple_spinner_item);
		control.setAdapter(adapter);
	}

}
