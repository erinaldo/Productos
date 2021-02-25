package com.amesol.routelite.presentadores.act;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;

import android.app.Activity;
import android.app.SearchManager;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Ruta;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.presentadores.interfaces.IConsultaReporte;
import com.amesol.routelite.utilerias.Generales;

public class ConsultarReporte extends Presentador
{

    public enum TiposFiltroCliente
    {
        NoUsado(0),
        SeleccionUnicaSinCheck(1),
        SeleccionUnicaConCheck(2),
        MultiSeleccion(3),
        SeleccionarDiaClave(4);

        public int value;

        TiposFiltroCliente(int v)
        {
            this.value = v;
        }
    }

	IConsultaReporte mVista;
    TiposFiltroCliente tipoFiltroCliente = TiposFiltroCliente.NoUsado;
	//Cliente clienteSeleccionado = null;
    HashMap<String,CheckBox> checkedControlCte = new HashMap<String,CheckBox>();

	public ConsultarReporte(IConsultaReporte vista){
		mVista = vista;
	}

	@Override
	public void iniciar()
	{
		
	}
	
	public void generarReporte(){
		try{
			int reporte = mVista.getReporteId();
			//Recibos recibo = new Recibos();
			//recibo.imprimirReporte(reporte, false, mVista);
            switch (reporte){
                case Enumeradores.REPORTEA.COBRANZA_GONAC:
                    if (mVista.getCliente() != null) {
                        Sesion.set(Campo.FiltroReporteCliente, mVista.getCliente());
                    }
                    break;
                case Enumeradores.REPORTEA.PEDIDOS_CONFIRMADOS_SAP:
                    if (mVista.getCliente() != null) {
                        Sesion.set(Campo.FiltroReporteCliente, mVista.getCliente());
                    }else{
                        Sesion.remove(Campo.FiltroReporteCliente);
                    }
                    Sesion.set(Campo.FiltroReporteFechas, generaCadenaFecha("TRP.FechaCaptura"));
                    Sesion.set(Campo.FiltroReporteFechaIni, mVista.getFechaIni());
                    Sesion.set(Campo.FiltroReporteFechaFin, mVista.getFechaFin());
                    break;
                case Enumeradores.REPORTEA.EFECTIVIDAD_RUTA:
                    if(mVista.getDiaClave() != null)
                        Sesion.set(Campo.FiltroReporteDiaClave,mVista.getDiaClave());
                    break;
                case Enumeradores.REPORTEA.COBRANZA_GENERICO:
                        if(mVista.getClientes() != null)
                            Sesion.set(Campo.FiltroReporteCliente,mVista.getClientes());
                    break;
                case Enumeradores.REPORTEA.RESUMEN_MOVIMIENTOS_GENERICO:
                           Sesion.set(Campo.FiltroReporteGeneralDetallado, mVista.getGeneralDetallado());

                    if(mVista.getDiaClave() != null)
                        Sesion.set(Campo.FiltroReporteDiaClave,mVista.getDiaClave());
                    break;
            }
            if (mVista.getCliente() != null){
                limpiarChecksCtes(mVista.getListaCtes(),null);
                mVista.setCliente(null);
            }

            mVista.setVieneDeImpresion(true);
            Recibos.imprimirReporte(reporte, false, mVista);
		}catch(Exception e){
			mVista.mostrarAdvertencia(e.getMessage());
			e.printStackTrace();
		}
		
		/*File file = new File(Environment.getExternalStorageDirectory().getAbsolutePath()+"/example.pdf");
		Intent intent = new Intent();
		intent.setDataAndType(Uri.fromFile(file), "application/pdf");
		intent.setClass(this, PDFViewer.class);
		intent.setAction("android.intent.action.VIEW");
		this.startActivity(intent);*/
	}

    private String generaCadenaFecha(String campo){
        switch (mVista.getBFNUMERI()){
            case Enumeradores.BFNUMERI.IGUAL:
                return campo + " between '" + Generales.getPrimerHora(mVista.getFechaIni())  + "' and '" + Generales.getUltimaHora(mVista.getFechaIni()) + "' ";
            case Enumeradores.BFNUMERI.DIFERENTE:
                return " not " + campo + " between '" + Generales.getPrimerHora(mVista.getFechaIni())  + "' and '" + Generales.getUltimaHora(mVista.getFechaIni()) + "' ";
            case Enumeradores.BFNUMERI.MAYOR_QUE:
                return campo + " > '" + Generales.getUltimaHora(mVista.getFechaIni()) + "' ";
            case Enumeradores.BFNUMERI.MENOR_QUE:
                return campo + " < '" + Generales.getPrimerHora(mVista.getFechaIni()) + "' ";
            case Enumeradores.BFNUMERI.MAYOR_IGUAL_QUE:
                return campo + " >= '" + Generales.getPrimerHora(mVista.getFechaIni()) + "' ";
            case Enumeradores.BFNUMERI.MENOR_IGUAL_QUE:
                return campo + " <= '" + Generales.getUltimaHora(mVista.getFechaIni()) + "' ";
            case Enumeradores.BFNUMERI.ENTRE:
                return campo + " between '" + Generales.getPrimerHora(mVista.getFechaIni())  + "' and '" + Generales.getUltimaHora(mVista.getFechaFin()) + "' ";
        }
        return "";
    }

   /* Public Function Operador(ByVal VAVClave As Integer, ByVal ValorIni As Object, ByVal ValorFin As Object, ByVal parTipoDato As TipoDato) As String
    Select Case VAVClave
    Case 7 'Entre
    Select Case parTipoDato
    Case TipoDato.Fecha
    Return " between " & UniFechaSQL(PrimeraHora(ValorIni)) & " and " & UniFechaSQL(UltimaHora(ValorFin))
    Case TipoDato.Numerico
    Return " between " & ValorIni & " and " & ValorFin
    End Select
    End Select
    Return String.Empty
    End Function */
	/*public void cargaClientes(ListView list)
	{
		try{
			ISetDatos setDatos = Consultas.ConsultasCliente.obtenerTodos(null, (Ruta)Sesion.get(Campo.RutaActual), null);
			Cliente[] clientes = new Cliente[setDatos.getCount()];
			int i = 0;
			Cliente cliente;
			while(setDatos.moveToNext()){
				cliente = new Cliente();
				cliente.ClienteClave = setDatos.getString(SearchManager.SUGGEST_COLUMN_INTENT_DATA);
				cliente.NombreCorto = setDatos.getString(SearchManager.SUGGEST_COLUMN_TEXT_1);
				cliente.NombreContacto = setDatos.getString(SearchManager.SUGGEST_COLUMN_TEXT_2);
				clientes[i++] = cliente;
			}
			setDatos.close();
			ArrayAdapter<Cliente> adapter = new ArrayAdapter<Cliente>((Context)mVista, R.layout.lista_simple3, clientes){
				@Override
				public View getView(int position, View convertView, ViewGroup parent)
				{
					View fila = convertView;

					if (convertView == null)
					{
						LayoutInflater inflater = ((Activity) mVista).getLayoutInflater();
						fila = inflater.inflate(R.layout.lista_simple3, null);
					}
					Cliente cliente = getItem(position);
					((TextView)fila.findViewById(R.id.texto1)).setText(cliente.NombreCorto);
					((TextView)fila.findViewById(R.id.texto2)).setText(cliente.NombreContacto);
					((TextView)fila.findViewById(R.id.texto3)).setText("");
					return fila;
				}
			};
			list.setAdapter(adapter);
		}catch(NullPointerException ex){
			mVista.mostrarError("Error al obtener los clientes");
		}catch(Exception ex){
			mVista.mostrarError(ex.getMessage());
		}
	}*/

    public void setTiposFiltroCliente(TiposFiltroCliente pTipoFiltroCliente){
        tipoFiltroCliente = pTipoFiltroCliente;
    }

    public void limpiarChecksCtes(ListView list,ArrayList<Cliente> clientes){
        if (list == null) return;
        if (tipoFiltroCliente == TiposFiltroCliente.SeleccionUnicaConCheck) {
            if (mVista.getCliente() != null) {
                ArrayAdapter<Cliente> adapter = ((ArrayAdapter) list.getAdapter());
                adapter.getItem(adapter.getPosition(mVista.getCliente())).Enviado = false;
                checkedControlCte.get(mVista.getCliente().ClienteClave).setChecked(false);
            }
           /* Iterator<Integer> it = checkedControlCte.keySet().iterator();
            while (it.hasNext()) {
                int pos = it.next();
                if (checkedControlCte.get(pos).isChecked()) {
                    adapter.getItem(adapter.getPosition(mVista.getCliente())).Enviado =false;
                    checkedControlCte.get(pos).setChecked(false);
                }
            }*/
            list.setSelectionFromTop(0, 0);
        } else if(tipoFiltroCliente == TiposFiltroCliente.MultiSeleccion){

            for(Cliente cliente : clientes){
                cliente.Enviado = false;
            }

            ((ArrayAdapter) list.getAdapter()).notifyDataSetChanged();
        }
    }

    public boolean existenDatosReporteCobranza(ArrayList<Cliente> clientes) throws Exception{

        ArrayList<Cliente> clientesSeleccionados = new ArrayList<>();
        for(Cliente cliente : clientes){
            if(cliente.Enviado)
                clientesSeleccionados.add(cliente);
        }

        ISetDatos cobranzaCliente;

        for(Cliente cliente : clientesSeleccionados){
            cobranzaCliente = Consultas.ConsultasTransProd.obtenerCobranzaPorCliente(cliente.ClienteClave);
            if(cobranzaCliente.moveToFirst())
                return true;
        }

        return false;
    }

    public boolean clienteSeleccionado(ArrayList<Cliente> clientes){

        for(Cliente c : clientes)
            if(c.Enviado)
                return true;

        return false;

    }

    public void seleccionarTodos(ListView list, ArrayList<Cliente> clientes, boolean seleccionar){

        for(Cliente cliente : clientes){
            cliente.Enviado = seleccionar;
        }

        ((ArrayAdapter) list.getAdapter()).notifyDataSetChanged();
    }

    public void cargaClientes(final ListView list, final ArrayList<Cliente> clientes)
    {
        try{

            final ArrayAdapter<Cliente> adapter = new ArrayAdapter<Cliente>((Context)mVista, R.layout.lista_simple3_chk, clientes){


                @Override
                public View getView(final int position, View convertView, ViewGroup parent)
                {
                    View fila = convertView;

                    if (convertView == null)
                    {
                        LayoutInflater inflater = ((Activity) mVista).getLayoutInflater();
                        fila = inflater.inflate(R.layout.lista_simple3_chk, null);
                    }

                    Cliente cliente = getItem(position);
                    ((CheckBox)fila.findViewById(R.id.chk1)).setChecked(cliente.Enviado);
                    ((CheckBox)fila.findViewById(R.id.chk1)).setTag(cliente);
                    ((CheckBox)fila.findViewById(R.id.chk1)).setText(cliente.NombreCorto);
                    ((TextView)fila.findViewById(R.id.texto1)).setText(cliente.NombreCorto);
                    ((TextView)fila.findViewById(R.id.texto2)).setText(cliente.NombreContacto);
                    //if (!checkedControlCte.containsKey(cliente.ClienteClave)) {
                        checkedControlCte.put(cliente.ClienteClave, ((CheckBox) fila.findViewById(R.id.chk1)));
                    //}

                    if (tipoFiltroCliente == TiposFiltroCliente.SeleccionUnicaSinCheck){
                        ((CheckBox)fila.findViewById(R.id.chk1)).setVisibility(View.GONE);
                        ((TextView)fila.findViewById(R.id.texto1)).setVisibility(View.VISIBLE);
                    }else{
                        ((CheckBox)fila.findViewById(R.id.chk1)).setVisibility(View.VISIBLE);
                        ((TextView)fila.findViewById(R.id.texto1)).setVisibility(View.GONE);
                    }

                    ((CheckBox) fila.findViewById(R.id.chk1)).setOnClickListener(new View.OnClickListener() {
                        public void onClick(View v) {
                            CheckBox cb = (CheckBox) v;
                            Cliente cliente = (Cliente) cb.getTag();
                            cliente.Enviado = cb.isChecked();
                            if (tipoFiltroCliente == TiposFiltroCliente.SeleccionUnicaConCheck) {
                                if (cliente.Enviado) {
                                    //checkedControlCte.get(cliente).setChecked(true);
                                    if (mVista.getCliente() != null && mVista.getCliente().ClienteClave != cliente.ClienteClave) {
                                        try {
                                            ArrayAdapter<Cliente> adapter = ((ArrayAdapter) ((ListView) v.getParent().getParent()).getAdapter());
                                            adapter.getItem(adapter.getPosition(mVista.getCliente())).Enviado = false;
                                            checkedControlCte.get(mVista.getCliente().ClienteClave).setChecked(false);
                                        } catch (Exception ex) {
                                            mVista.mostrarError("Error al seleccionar cliente");
                                        }
                                    }
                                    mVista.setCliente(cliente);
                                } else {
                                    try {
                                        if (cliente != null && cliente.ClienteClave == mVista.getCliente().ClienteClave) {
                                            mVista.setCliente(null);
                                        }
                                    } catch (Exception ex) {
                                        mVista.mostrarError("Error al seleccionar cliente");
                                    }
                                }
                            }
                        }
                    });

                    return fila;
                }
            };
            list.setAdapter(adapter);
        }catch(NullPointerException ex){
            mVista.mostrarError("Error al obtener los clientes");
        }catch(Exception ex){
            mVista.mostrarError(ex.getMessage());
        }
    }

}
