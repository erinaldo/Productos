package com.amesol.routelite.vistas.generico;

import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Promocion;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.utilerias.Generales;

public class PromocionesAdapter extends ArrayAdapter<Promocion> {

	
	int textViewResourceId; 
	Context context;
	LayoutInflater inflater ;
	static class ViewHolder {
		TextView textoclave ;
		TextView textodes;
		TextView textoTipoPromocion ;
		TextView textoRangoPromocion;
		
		TextView textoFinaliza;
		TextView textoValFinaliza;
		
		TextView textoSeleccionarProducto;
		
		TextView textoCapturaCantidad;
		
		TextView textoPromocionAplicada;
		TextView textoEsquemas;
		
		TextView textoEnProductos;
		//TextView textoEnProductosVal1;
		//TextView textoEnProductosVal2;
		
		TextView textoRango1;
		TextView textoRango2;
		TextView textoRango3;
		
		TextView textoRangoVal1;
		TextView textoRangoVal2;
		TextView textoRangoVal3;
		
		
		int position;
		
	}



	
	ISetDatos Reglas; 
	ISetDatos Aplicaciones;
	List<Promocion> objectos;
	Promocion[] TodasPromociones;
	/*
	  sClave = vcMensaje.RecuperarDescripcion("XClave")
		        sPromocion = vcMensaje.RecuperarDescripcion("XPromocion")
		        sTipo = vcMensaje.RecuperarDescripcion("XTipo")
		        sFinaliza = vcMensaje.RecuperarDescripcion("XFinaliza")
		        sSeleccionaProducto = vcMensaje.RecuperarDescripcion("XSeleccionarProducto")
		        sCapturaCantidad = vcMensaje.RecuperarDescripcion("XCapturarCantidad")
		        sPromocionAplicadaA = vcMensaje.RecuperarDescripcion("XPromocionAplicadaA")
		        sPrecioProducto = vcMensaje.RecuperarDescripcion("NCRPrecioT")
		        sEnProductos = vcMensaje.RecuperarDescripcion("XEnProductos")
		        sRangoVentas = vcMensaje.RecuperarDescripcion("XRangoVentas")
		        sDe = vcMensaje.RecuperarDescripcion("XDe")
		        sA = vcMensaje.RecuperarDescripcion("XA")
		        sPorCada = vcMensaje.RecuperarDescripcion("XPorCada")
		        sDescuento = vcMensaje.RecuperarDescripcion("XDescuento")
		        sDescAplicado = vcMensaje.RecuperarDescripcion("XPrecioDesc")
		        sImporte = vcMensaje.RecuperarDescripcion("XImporte")
		        sPrecio = vcMensaje.RecuperarDescripcion("XPrecio")
		        sPuntos = vcMensaje.RecuperarDescripcion("XPuntos")
		        sMaxRegalo = vcMensaje.RecuperarDescripcion("XMaxRegalo")*/
	
	public PromocionesAdapter(Context context, int textViewResourceId, List<Promocion> objects, Promocion[] aTodasPromociones,ISetDatos Reglas, ISetDatos Aplicaciones) {		
		super(context, textViewResourceId, objects);
		
		this.textViewResourceId = textViewResourceId;
		this.context = context;
		objectos=objects;
		TodasPromociones=aTodasPromociones;
		 inflater = ((Activity)context).getLayoutInflater();
		 this.Reglas=Reglas;
		 this.Aplicaciones=Aplicaciones;
		 
	}
	
	@Override
	public int getViewTypeCount() {
	    return objectos.size() ;
	}
	
	@Override
	public int getItemViewType(int position) {
	    return position;
	}
	
	@Override
	public View getView(int position, View convertView,ViewGroup parent){
		View fila = convertView;
		ViewHolder holder;
		if(convertView == null){
			
			fila = 	inflater.inflate(textViewResourceId, null);
			 holder = new ViewHolder();
			 
			 holder.textoclave =  (TextView) fila.findViewById(R.id.lblvalClavepromocion);
			 holder.textodes =  (TextView) fila.findViewById(R.id.lblvalNombrePromocion);
			 holder.textoTipoPromocion =  (TextView) fila.findViewById(R.id.lblvalTipoPromocion);
			 holder.textoRangoPromocion =  (TextView) fila.findViewById(R.id.lblvalRangoPromocion);
			
			 holder.textoFinaliza =  (TextView) fila.findViewById(R.id.lblFinaliza);
			 holder.textoValFinaliza =  (TextView) fila.findViewById(R.id.lblvalFinaliza);
			 		 
			 holder.textoSeleccionarProducto =  (TextView) fila.findViewById(R.id.lblSeleccionarProducto);

			 holder.textoCapturaCantidad =  (TextView) fila.findViewById(R.id.lblCapturaCantidad);

			 holder.textoPromocionAplicada=  (TextView) fila.findViewById(R.id.lblPromocionAplicada);
			 holder.textoEsquemas=  (TextView) fila.findViewById(R.id.lblEsquemas);
			 
			 holder.textoEnProductos=  (TextView) fila.findViewById(R.id.lblEnProductos);
			 //holder.textoEnProductosVal1=  (TextView) fila.findViewById(R.id.lblEnProductosVal1);
			 //holder.textoEnProductosVal2=  (TextView) fila.findViewById(R.id.lblEnProductosVal2);
			
			 holder.textoRango1=  (TextView) fila.findViewById(R.id.lblRango1);
			 holder.textoRango2=  (TextView) fila.findViewById(R.id.lblRango2);
			 holder.textoRango3=  (TextView) fila.findViewById(R.id.lblRango3);
			
			 
			 holder.textoRangoVal1=  (TextView) fila.findViewById(R.id.lblRangoVal1);
			 holder.textoRangoVal2=  (TextView) fila.findViewById(R.id.lblRangoVal2);
			 holder.textoRangoVal3=  (TextView) fila.findViewById(R.id.lblRangoVal3);
			
			 
		
			 Promocion vr = getItem(position);
				holder.textoclave.setText(vr.PromocionClave);
				holder.textodes.setText(vr.Nombre);
				
				holder.textoTipoPromocion.setText(	 ValoresReferencia.getDescripcion("TAPPROM", String.valueOf(vr.TipoAplicacion)));
				holder.textoRangoPromocion.setText(ValoresReferencia.getDescripcion("PRMRAN", String.valueOf(vr.TipoRango)));
				
				holder.textoValFinaliza.setText(Generales.getFormatoFecha(vr.FechaFinal, "dd/MM/yyyy") );
				
				if(vr.Tipo==4 && vr.CapturaCantidad)
				{
					
					holder.textoCapturaCantidad.setVisibility(View.VISIBLE);
				}
				else
				{
					holder.textoCapturaCantidad.setVisibility(View.GONE);
				}
				
				if(vr.Tipo==4 && vr.SeleccionProducto)
				{
					
					holder.textoSeleccionarProducto.setVisibility(View.VISIBLE);
				}
				else
				{
					holder.textoSeleccionarProducto.setVisibility(View.GONE);
				}
				
				if(vr.Tipo!=1)//Aplica a
				{
					ISetDatos datos = Consultas.ConsultasPromocion.obtenerPromocionProductosEsquema(vr.PromocionClave);
					String sEsquemas="";
					while(datos.moveToNext())
					{
						sEsquemas+=datos.getString("Nombre")+"\n";
					}
					datos.close();
					holder.textoEsquemas.setText(sEsquemas);
				}
				else
				{
					holder.textoPromocionAplicada.setVisibility(View.GONE);
				}
				
				
				//se cambio para que agregue dinamicamente TextViews en lugar de generar la cadena como estaba
				LinearLayout llv = (LinearLayout) fila.findViewById(R.id.layProductos); //crear una vista vertical para agregar los productos
				
				//String sProductosCol1="";
				//String sProductosCol2="";
				
					
					for(int i=0;i<TodasPromociones.length;i++)
					{
						if(TodasPromociones[i].PromocionClave.equals(vr.PromocionClave))
						{
							LinearLayout llh = new LinearLayout(getContext()); //crear una vista horizontal para agregar las etiquetas
							llh.setOrientation(LinearLayout.HORIZONTAL);
							TextView txtnombre = new TextView(getContext());
							TextView txtdato = new TextView(getContext());
							txtnombre.setText(TodasPromociones[i].ProductoNombre.trim());
							
							//sProductosCol1+=TodasPromociones[i].ProductoNombre;
							if(vr.TipoAplicacion==1)
							{
								txtdato.setText(Generales.getFormatoDecimal(TodasPromociones[i].Precio, "#,##0.00"));
								//sProductosCol1+= "\t\t" + Generales.getFormatoDecimal(TodasPromociones[i].Precio, "#,##0.00")  +"\n";
							}
							else
							{
								txtdato.setText("");
								//sProductosCol1+="\n";
							}
							
							LinearLayout.LayoutParams param=new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT,LayoutParams.WRAP_CONTENT);
							LinearLayout.LayoutParams param2=new LinearLayout.LayoutParams(LayoutParams.MATCH_PARENT,LayoutParams.WRAP_CONTENT);
							param.weight = (float) 7.5;
							param.rightMargin = 5;
							param2.weight = 3;
							txtdato.setMaxLines(1);
							txtdato.setLayoutParams(param);
							//txtdato.setGravity(Gravity.RIGHT);
							txtnombre.setLayoutParams(param2);
							txtnombre.setMaxLines(1);
							txtdato.requestLayout();
							txtnombre.requestLayout();
							
							llh.addView(txtnombre); //agregar el nombre a la vista horizontal
							llh.addView(txtdato); //agregar el dato a la vista horizontal
							llv.addView(llh); //agregar la vista horizontal con los datos a la vertical
						}
					
					}
					//agregar un espacio al final de los productos
					LinearLayout llh = new LinearLayout(getContext());
					llh.setOrientation(LinearLayout.HORIZONTAL);
					TextView txtespacio = new TextView(getContext());
					txtespacio.setText(" ");
					txtespacio.setMaxLines(1);
					llh.addView(txtespacio);
					llv.addView(llh);
					
					//holder.textoEnProductosVal1.setText(sProductosCol1);
					//holder.textoEnProductosVal2.setText(sProductosCol2);
	
					
				
				
			 fila.setTag(holder);
			 
			 if(vr.TipoAplicacion==1)
				{
					if(vr.TipoRegla == 2)
					{
						
						 holder.textoRango1.setText(Mensajes.get("XPorCada"));
						 holder.textoRango2.setText(Mensajes.get("XDescuento"));
						 holder.textoRango3.setText(Mensajes.get("XPrecioDesc"));
					}
					else
					{
						holder.textoRango1.setText(Mensajes.get("XRangoVentas"));
						 holder.textoRango2.setText(Mensajes.get("XDescuento"));
						 holder.textoRango3.setText(Mensajes.get("XPrecioDesc"));

					}
				}
				else if(vr.TipoAplicacion==2)
				{
					if(vr.TipoRegla == 2)
					{
						holder.textoRango1.setText(Mensajes.get("XPorCada"));
						 holder.textoRango2.setText(Mensajes.get("XImporte"));
	
					}
					else
					{
						holder.textoRango1.setText(Mensajes.get("XRangoVentas"));
						 holder.textoRango2.setText(Mensajes.get("XImporte"));
			
	
					}
				}
				else if(vr.TipoAplicacion==3)
				{
					if(vr.TipoRegla == 2)
					{
						holder.textoRango1.setText(Mensajes.get("XPorCada"));
						 holder.textoRango2.setText(Mensajes.get("XPrecio"));
		
					}
					else
					{
						holder.textoRango1.setText(Mensajes.get("XRangoVentas"));
						 holder.textoRango2.setText(Mensajes.get("XPrecio"));

					}
				}
				else if(vr.TipoAplicacion==4)
				{}
				else if(vr.TipoAplicacion==5)
				{
					if(vr.TipoRegla == 2)
					{
						holder.textoRango1.setText(Mensajes.get("XPorCada"));
						 holder.textoRango2.setText(Mensajes.get("XPuntos"));
						 
					}
					else
					{
						holder.textoRango1.setText(Mensajes.get("XRangoVentas"));
						 holder.textoRango2.setText(Mensajes.get("XPuntos"));
						
					}
				}
			
				
				if(Reglas.getCount()>0)
				{
					String Col1="";
					String Col2="";
					String Col3="";
				
					Reglas.moveToFirst();
					do
					{
						if(vr.PromocionClave.equals(Reglas.getString("PromocionClave")))
						{
							
							 
							 String sRangoVta = "";
							 
							 if(vr.TipoRegla==2)
							 {
								 sRangoVta=Reglas.getString("Minimo")  + " (" + Mensajes.get("PMRMinimo") +  " " + Reglas.getInt("AplicacionMinima") + ")";
							 }
							 else
							 {
								 sRangoVta=Reglas.getString("Minimo") +" A "+Reglas.getString("Maximo");;
							 }
							 
							 
							 if(vr.TipoAplicacion==1)
								{
								 Col1+=sRangoVta+"\n";
								 
								
									float Porcentaje =Reglas.getFloat("Porcentaje");
									 Col2+=Porcentaje +"\n";
									 Col3+=Generales.getFormatoDecimal(vr.Precio-(( vr.Precio)*(Porcentaje/100)), "#,##0.00") +"\n";
								}
								else if(vr.TipoAplicacion==2)
								{
									 Col1+=sRangoVta+"\n";
									 Col2+=Generales.getFormatoDecimal(Reglas.getFloat("Importe"), "#,##0.00")+"\n";
									 Col3+="\n";
								}
								else if(vr.TipoAplicacion==3)
								{
									 Col1+=sRangoVta+"\n";
									 Col2+=Generales.getFormatoDecimal(Reglas.getFloat("Precio"), "#,##0.00") +"\n";
									 Col3+=""+"\n";
								}
								else if(vr.TipoAplicacion==4)
								{
									if(vr.TipoRegla==2)
									{
										 Col1+="Rango Venta"+"\n";
										 Col2+="Por Cada" + "(" + Mensajes.get("PMRMinimo") + Reglas.getString("AplicacionMinima") + ") "  + Reglas.getInt("Minimo")  +"\n";
										 //Col3+="Cantidad "+ Reglas.getInt("Cantidad") + "\n";
									}
									else
									{
										 Col1+="Rango Venta"+"\n";
										 Col2+=Reglas.getInt("Minimo") + " a " + Reglas.getInt("Maximo")  +"\n";
										 Col3+="Cantidad "+ Reglas.getInt("Cantidad") + "\n";
									}
									 Col1+="\n";
									 Col2+="\n";
									 Col3+= "\n";
									if(Aplicaciones.getCount()>0)
									{
										Aplicaciones.moveToFirst();
										do
										{
											if(vr.PromocionClave.equals(Aplicaciones.getString("PromocionClave")) &&  Reglas.getString("PromocionReglaID").equals(Aplicaciones.getString("PromocionReglaID")))
											{
											 Col1+=Aplicaciones.getString("Nombre")+"\n";
											 Col2+= ValoresReferencia.getDescripcion("UNIDADV", Aplicaciones.getString("PRUTipoUnidad"))+"\n";
											 Col3+=Aplicaciones.getString("Cantidad")+"\n";
									
											}
										}
										while(Aplicaciones.moveToNext());
										 Col1+="\n";
										 Col2+="\n";
										 Col3+= "\n";
									}
								}
								else if(vr.TipoAplicacion==5)
								{		
									Col1+=sRangoVta+"\n";
									Col2+=Reglas.getFloat("Cantidad")+"\n";
									Col3+=""+"\n";
								}
						}
					}
					while(Reglas.moveToNext());
					holder.textoRangoVal1.setText(Col1);
					holder.textoRangoVal2.setText(Col2);
					holder.textoRangoVal3.setText(Col3);
				}
			 
		}
		else
		{
			holder= (ViewHolder) fila.getTag();
		}
	

		return fila;
	}
	
	
	 /*

     For Each subFila As DataRow In oPromociones.RecuperarPromocionRegla(drPromocion("PromocionClave")).Rows
         Dim sMinimo As String = subFila("Minimo")
         Dim sMaximo As String = subFila("Maximo")

         Dim sRangoVta As String = ""
         If drPromocion("TipoRegla") = "2" Then
             sRangoVta = sMinimo
         Else
             sRangoVta = sMinimo + " " + sA + " " + sMaximo
         End If

         Select Case CType(drPromocion("TipoAplicacion"), Integer)
             Case 1 'Descuento
                 htmlRangoDeVenta += "<tr ><td style=""padding-left: 20px"">$RangoDeVenta$</td> <td>$Descuento$</td> <td>$DescAplicado$</td></tr>"
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$RangoDeVenta$", sRangoVta)
                 Dim dPorc As Double = subFila("Porcentaje")
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Descuento$", dPorc.ToString() + "%")
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$DescAplicado$", dPrecio - (dPrecio * (dPorc / 100)))
             Case 2 'Bonificacion
                 htmlRangoDeVenta += "<tr ><td style=""padding-left: 10px"">$RangoDeVenta$</td> <td>$Importe$</td></tr>"
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$RangoDeVenta$", sRangoVta)
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Importe$", "$" + subFila("Importe").ToString())
             Case 3 'Precio
                 htmlRangoDeVenta += "<tr ><td style=""padding-left: 10px"">$RangoDeVenta$</td> <td>$Precio$</td></tr>"
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$RangoDeVenta$", sRangoVta)
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Precio$", subFila("Precio"))
             Case 4 'Producto
                 If drPromocion("TipoRegla") = "2" Then
                     htmlRangoDeVenta += "<tr><td><br></td></tr><tr ><td><b>$RangoDeVenta$</b></td> <td><b>$PorCada$</b> $Cant$</td> <td><b>$Cantidad$:</b> $CantMax$ </td></tr>"
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$RangoDeVenta$", sRangoVentas)
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$PorCada$", sPorCada)
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Cant$", subFila("Minimo"))
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Cantidad$", sMaxRegalo)
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$CantMax$", subFila("Cantidad"))
                 Else
                     htmlRangoDeVenta += "<tr><td><br></td></tr><tr ><td><b>$RangoDeVenta$:</b> $Minima$ $A$ $Maxima$</td> <td><b>$Cantidad$:</b> $CantMax$ </td></tr>"
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$RangoDeVenta$", sRangoVentas)
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Minima$", subFila("Minimo"))
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Maxima$", subFila("Maximo"))
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$A$", sA)
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Cantidad$", sMaxRegalo)
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$CantMax$", subFila("Cantidad"))
                 End If

                 For Each subSubFila As DataRow In oPromociones.RecuperarPromocionAplicacion(drPromocion("PromocionClave"), subFila("PromocionReglaID")).Rows
                     htmlRangoDeVenta += "<tr ><td style=""padding-left: 10px"">$Producto$</td> <td>$Unidad$</td><td> $Cant$</td></tr>"
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Producto$", subSubFila("Nombre").ToString().Replace("<", "").Replace(">", ""))
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Unidad$", lbGeneral.ClaveDescripcionVARValor("UNIDADV", subSubFila("PRUTipoUnidad")))
                     htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Cant$", subSubFila("Cantidad"))
                 Next
             Case 5 'Puntos
                 htmlRangoDeVenta += "<tr ><td style=""padding-left: 10px"">$RangoDeVenta$</td> <td>$Puntos$</td></tr>"
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$RangoDeVenta$", sRangoVta)
                 htmlRangoDeVenta = htmlRangoDeVenta.Replace("$Puntos$", subFila("Cantidad"))
         End Select

     Next
     Return htmlRangoDeVenta
 End Function*/
	
	
}
