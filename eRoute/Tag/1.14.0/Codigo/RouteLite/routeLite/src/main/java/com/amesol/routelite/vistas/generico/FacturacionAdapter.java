package com.amesol.routelite.vistas.generico;

import android.app.Activity;
import android.content.Context;
import android.text.Html;
import android.text.format.DateFormat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion;
import com.amesol.routelite.presentadores.act.SeleccionarFacturacion.TransProdFactura;
import com.amesol.routelite.presentadores.act.SeleccionarPedido;
import com.amesol.routelite.presentadores.act.SeleccionarConsignacion.VistaConsignacion;
import com.amesol.routelite.utilerias.Generales;

public class FacturacionAdapter extends ArrayAdapter<TransProdFactura>
{

	int textViewResourceId;
	private Context context;
	private TransProdFactura[] facturas;
	
	public FacturacionAdapter(Context context, int textViewResourceId, TransProdFactura[] objects)
	{
		super(context, textViewResourceId, objects);
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		facturas = objects;
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
		TransProdFactura factura = getItem(position);

		TextView texto = (TextView) fila.findViewById(R.id.texto1);
		if (texto != null)
			texto.setText(Html.fromHtml("<b>" + factura.Folio + "</b>"));
		
		texto = (TextView) fila.findViewById(R.id.texto2);
		if (texto != null)
			texto.setText(Html.fromHtml(Mensajes.get("TRPFechaCaptura") + ": <b>" + DateFormat.format("dd/MM/yyyy", factura.FechaCaptura) + "</b>"));

		texto = (TextView) fila.findViewById(R.id.texto3);
		if (texto != null)
			try {
				if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("TimbradoCFDIMovil") && ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("TimbradoCFDIMovil").toString().equals("1")) {
					if (factura.UUID != null && factura.UUID.length() > 0) {
						texto.setText(Html.fromHtml(Mensajes.get("XFase") + ": <b>" + "Timbrada" + "</b>"));
					} else {
						if (factura.Enviado) {
							texto.setText(Html.fromHtml(Mensajes.get("XFase") + ": <b>" + "Pendiente de timbrado" + "</b>"));
						} else {
							texto.setText(Html.fromHtml(Mensajes.get("XFase") + ": <b>" + factura.Fase + "</b>"));
						}
					}
				}else {
					texto.setText(Html.fromHtml(Mensajes.get("XFase") + ": <b>" + factura.Fase + "</b>"));
				}
			}catch (Exception ex){

			}
		
		texto = (TextView) fila.findViewById(R.id.texto4);
		if (texto != null)
			texto.setText(Html.fromHtml(Mensajes.get("XSUBEMPRESA") + ": <b>" + factura.NombreCorto + "</b>"));
		
		fila.findViewById(R.id.texto5).setVisibility(View.INVISIBLE);

		return fila;
	}
	
}
