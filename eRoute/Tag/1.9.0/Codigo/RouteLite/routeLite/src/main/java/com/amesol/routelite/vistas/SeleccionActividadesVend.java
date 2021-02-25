package com.amesol.routelite.vistas;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.DialogInterface.OnKeyListener;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ListView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.actividades.ModuloMovDetalle;
import com.amesol.routelite.actividades.ValorReferencia;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.ArchivoConfiguracion.CampoConfiguracion;
import com.amesol.routelite.datos.utilerias.CONHist;
import com.amesol.routelite.datos.utilerias.ConfiguracionLocal;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.ACTROL;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.TiposModuloMovDetalle;
import com.amesol.routelite.presentadores.act.SeleccionarActividadesVend;
import com.amesol.routelite.presentadores.interfaces.IAccesoSistema;
import com.amesol.routelite.presentadores.interfaces.ISeleccionActividadesVend;
import com.amesol.routelite.utilerias.EncriptaDesencripta;
import com.amesol.routelite.vistas.generico.ValorReferenciaAdapter;

public class SeleccionActividadesVend extends Vista implements ISeleccionActividadesVend
{
	SeleccionarActividadesVend mPresenta;
	ValorReferencia val;
	HashMap<Integer,String> aModuloMovDetalleClave;
	HashMap<Integer,Integer> aTipoIndiceModuloMovDetalleClave;
	private boolean vali = false; // esta variable se utiliza para regresar el booleano desde el dialogo para validar los permisos
    private int solicitarContrasenaDescarga = 0;
    private int solicitarContrasenaDevoAlmacen = 0;
    
	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		// super.onSaveInstanceState(savedInstanceState);
		setContentView(R.layout.seleccion_actividades_vend);
		deshabilitarBarra(true);
		mPresenta = new SeleccionarActividadesVend(this);
		mPresenta.iniciar();
		
		if (Sesion.get(Campo.SolicitarContrasenaDescarga) == null || Sesion.get(Campo.SolicitarContrasenaDescarga).equals(""))
		{
			Sesion.set(Campo.SolicitarContrasenaDescarga, "1");
		}
		if (Sesion.get(Campo.SolicitarContrasenaDevolucionAlmacen) == null || Sesion.get(Campo.SolicitarContrasenaDevolucionAlmacen).equals(""))
		{
			Sesion.set(Campo.SolicitarContrasenaDevolucionAlmacen, "1");
		}

        if (Sesion.get(Sesion.Campo.MensajeEntrePantalla) != null && !Sesion.get(Sesion.Campo.MensajeEntrePantalla).toString().equals("")){
            mostrarAdvertencia(Sesion.get(Sesion.Campo.MensajeEntrePantalla).toString());
            Sesion.set(Sesion.Campo.MensajeEntrePantalla,"");
        }
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_AGENDA) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)){
			Usuario usu = (Usuario) Sesion.get(Campo.UsuarioActual);
			ConfiguracionLocal conf = (ConfiguracionLocal) Sesion.get(Campo.ConfiguracionLocal);
			if(!usu.Clave.equals(conf.get(CampoConfiguracion.USUARIO)))
			{
				if(data != null && data.getStringExtra("mensajeIniciar").equals("NuevaAgenda")){ 
					iniciarActividad(IAccesoSistema.class, true);
				}
			}else{
				atras();
			}
		}else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_RECIBIR) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			atras();
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			atras();
		/*else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL) && (resultCode == Enumeradores.Resultados.RESULTADO_BIEN))
			//si el envio parcial fue correcto, sincronizar el inventario
			mPresenta.obtenerInventarioEnLinea();*/
		//else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES || requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES_ENVIO_PARCIAL) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		else if ((requestCode == Enumeradores.Solicitudes.SOLICITUD_SERVIDOR_COMUNICACIONES) && (resultCode == Enumeradores.Resultados.RESULTADO_MAL))
		{
			if (data != null)
			{
				String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
				if (mensajeError != null)
				{
					iniciarActividad(ISeleccionActividadesVend.class, mensajeError);
					return;
				}
			}
			iniciarActividad(ISeleccionActividadesVend.class);
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub

	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				atras();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private void atras()
	{
		ListView lista = (ListView) findViewById(android.R.id.list);
		mPresenta.atras(lista.getTag().toString());
	}

	public void iniciar()
	{
		// TODO Auto-generated method stub
	}

	public void mostrarActividades(ValorReferencia[] valores, String grupo)
	{
		aModuloMovDetalleClave = new HashMap<Integer,String>();
		aTipoIndiceModuloMovDetalleClave = new HashMap<Integer,Integer>();
		Arrays.sort(valores);
		//if (valores[0].getVavclave().equals("13"))
		if (valores[0].getVavclave().equals("1"))
			setTitulo(Mensajes.get("XActividadesVendedor"));
		else if (valores[0].getVavclave().equals("14"))
			setTitulo(Mensajes.get("XInventario"));
		else
			setTitulo(Mensajes.get("XActualizar"));

		ArrayList<ValorReferencia> Valores = new ArrayList<ValorReferencia>();
		for (int i = 0; i < valores.length; i++)
		{
			Valores.add(valores[i]);
		}

		for (int i = 0; i < Valores.size(); i++)
		{
			if (!((Vendedor) Sesion.get(Campo.VendedorActual)).JornadaTrabajo && Valores.get(i).getVavclave().equals("28"))
			{
				Valores.remove(i);
				if (i == 0)
					i = 0;
				else
					i--;
			}
			if (!((Vendedor) Sesion.get(Campo.VendedorActual)).Kilometraje && Valores.get(i).getVavclave().equals("27"))
			{
				Valores.remove(i);
				if (i == 0)
					i = 0;
				else
					i--;
			}
			//if (Boolean.parseBoolean(((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").toString()) && Valores.get(i).getVavclave().equals("22"))
            if (((CONHist) Sesion.get(Campo.CONHist)).get("Preliquidacion").equals("0") && Valores.get(i).getVavclave().equals("22"))
			{
				Valores.remove(i);
				if (i == 0)
					i = 0;
				else
					i--;
			}
		}

		if (grupo.equals("Inventario"))
		{
			for (int i = 0; i < Valores.size(); i++)
			{
				if (Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.CONSULTA_INVENTARIO)) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA)
				{
					try
					{
						ISetDatos idataRuta = Consultas.ConsultasRuta.obtenerRutas();
						boolean inventario = false;
						while(idataRuta.moveToNext()){
							if(idataRuta.getInt("Inventario") == 1)
								inventario = true;
						}
						if(!inventario){
							Valores.remove(i);
							/*if (i == 0)
								i = 0;
							else{
								if(i > 0)
									i--;	
							}*/
							i--;
						}
					}
					catch (Exception e)
					{
						e.printStackTrace();
					}
				} else
				if(Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.TRASPASO_INVENTARIO)) && Integer.parseInt(Sesion.get(Campo.TipoModulo).toString()) == Enumeradores.TiposModulos.PREVENTA){
					//quitar la actividad de traspasos si el modulo es preventa
					Valores.remove(i);
					//if(i > 0)
						i--;
					//continue;
				}else
				if (Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.MOV_SIN_INV_SIN_VISITA)) && !obtenerActividadesInventario(TiposModuloMovDetalle.MOV_SIN_INV_SIN_VISITA, ACTROL.MOV_SIN_INV_SIN_VISITA ))
				{
					Valores.remove(i);
					/*if (i == 0)
						i = 0;
					else{
						if(i > 0)
							i--;
					}*/
					i--;
					//continue;
				}else

				if (Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.AJUSTES)) && !obtenerActividadesInventario(TiposModuloMovDetalle.AJUSTES, ACTROL.AJUSTES) )
				{
					Valores.remove(i);
					/*if (i == 0)
						i = 0;
					else{
						if(i > 0)
							i--;
					}*/
					i--;
					//continue;
				}else

				if (Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.DESCARGAS)) && !obtenerActividadesInventario(TiposModuloMovDetalle.DESCARGAS, ACTROL.DESCARGAS))
				{
					Valores.remove(i);
					/*if (i == 0)
						i = 0;
					else{
						if(i > 0)
							i--;
					}*/
					i--;
					//continue;
				}else

				if (Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.DEVOLUCIONESALMACEN)) && !obtenerActividadesInventario(TiposModuloMovDetalle.DEVOLUCIONMANUALES, ACTROL.DEVOLUCIONESALMACEN) )
				{
					Valores.remove(i);
					/*if (i == 0)
						i = 0;
					else{
						if(i > 0)
							i--;
					}*/
					i--;
					//continue;
				}else

				if (Valores.size() > 0 && Valores.get(i).getVavclave().equals(String.valueOf(ACTROL.CARGAS)) && !obtenerActividadesInventario(TiposModuloMovDetalle.CARGAS, ACTROL.CARGAS ))
				{
					Valores.remove(i);
					/*if (i == 0)
						i = 0;
					else{
						if(i > 0)
							i--;
					}*/
					i--;
					//continue;
				}
			}
			

		}

		ListView lista = (ListView) findViewById(android.R.id.list);
		lista.setTag(grupo);
		if(Valores.size() > 0){
			ValorReferenciaAdapter adapter = new ValorReferenciaAdapter(this, R.layout.elemento_imagen_texto, Valores);
			lista.setAdapter(adapter);
			lista.setOnItemClickListener(mSeleccionar);	
		}else{
			lista.setAdapter(null);
			lista.setOnItemClickListener(null);
		}
	}

	private OnItemClickListener mSeleccionar = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			val = (ValorReferencia) parent.getItemAtPosition(position);
			if(aModuloMovDetalleClave != null && aTipoIndiceModuloMovDetalleClave != null){
				if(aModuloMovDetalleClave.containsKey(Integer.parseInt(val.getVavclave())) && aTipoIndiceModuloMovDetalleClave.containsKey(Integer.parseInt(val.getVavclave()))){
					Sesion.set(Campo.ModuloMovDetalleClave, aModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));
					Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, aTipoIndiceModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));	
				}
			}
			
			String tipoIndice = String.valueOf(aTipoIndiceModuloMovDetalleClave.get(Integer.parseInt(val.getVavclave())));
			//Log.i(null, "val: "+ tipoIndice);
			if (tipoIndice.equals("8") || tipoIndice.equals("15"))
			{
				validarPermisoAcceso(tipoIndice, Enumeradores.TipoPermiso.ACCESAR);
			}
			else
			{
				
				mPresenta.seleccionar(val);
			}
		}
	};

	@Override
	public Context getContext()
	{
		// TODO Auto-generated method stub E0487		
		return this;
	} 

	public boolean obtenerActividadesInventario(int TipoIndice, int indiceACTROL)
	{

		ModuloMovDetalle[] mModuloMovDetalle;
		try
		{
			mModuloMovDetalle = Consultas.ConsultasActividades.obtenerActividadesInventario((Vendedor) Sesion.get(Campo.VendedorActual), TipoIndice);
			for(ModuloMovDetalle oMMD : mModuloMovDetalle){
				if(!aModuloMovDetalleClave.containsKey(indiceACTROL))
					aModuloMovDetalleClave.put(indiceACTROL, oMMD.getModuloMovDetalleClave());
				if(!aTipoIndiceModuloMovDetalleClave.containsKey(indiceACTROL))
					aTipoIndiceModuloMovDetalleClave.put(indiceACTROL,oMMD.getTipoIndice());
			}

			if (mModuloMovDetalle.length > 0)
			{
				Sesion.set(Campo.ModuloMovDetalleClave, mModuloMovDetalle[0].getModuloMovDetalleClave());
				Sesion.set(Campo.TipoIndiceModuloMovDetalleClave, mModuloMovDetalle[0].getTipoIndice());
				return true;
			}
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage());
		}
		return false;
	}

	private void validarPermisoAcceso(String tipoIndice, int tipoPermiso)//Metodo que valida permisos ldelatorre
	{
		boolean validar = true;
		try
		{
			solicitarContrasenaDescarga = Integer.parseInt(String.valueOf(Sesion.get(Campo.SolicitarContrasenaDescarga)));
			solicitarContrasenaDevoAlmacen = Integer.parseInt(String.valueOf(Sesion.get(Campo.SolicitarContrasenaDevolucionAlmacen)));
			String id = "TINDMMD" + tipoIndice;
			String permiso = Consultas.ConsultasPermisos.validarPermisos(id);
			String contrasenaPara = ValoresReferencia.getDescripcion("TINDMMD", String.valueOf(tipoIndice));
            
			if (permiso.equals("1"))
			{
				validar = true;
			}
			else
			{
				Log.i(null, "Descarga: "+solicitarContrasenaDescarga+" Almacen: "+solicitarContrasenaDevoAlmacen);
				if(tipoPermiso == Enumeradores.TipoPermiso.ACCESAR && permiso.equals("") && solicitarContrasenaDescarga == 1 || solicitarContrasenaDevoAlmacen == 1)
				{
					showAlertDialog(contrasenaPara, tipoIndice);
					validar = false;
				}
			}
            if(validar)
            {
                mPresenta.seleccionar(val);
            }
			
		}
		catch (Exception e)
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	} 
 
	public void showAlertDialog(String contrasenaPara, final String tipoIndice)//Metodo que valida permisos ldelatorre
	{
    	
    	
		LayoutInflater factory = LayoutInflater.from(this);

		// text_entry is an Layout XML file containing two text field to display
		// in alert dialog
		
		
		final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

		final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
		lblLogin.setText(Mensajes.get("XUsuario"));

		final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
		lblPass.setText(Mensajes.get("XContraseña"));

		final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
		final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);

		final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
		alert.setTitle(contrasenaPara).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
				String clave = txtUser.getText().toString();
				String pass = txtPass.getText().toString();
				if (validarInformacion(clave, pass))
				{
					Usuario usuario = null;
					try
					{
						usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
					}
					catch (Exception e)
					{
						e.printStackTrace();
						mostrarError(e.getMessage());
					}

					if ((usuario == null) || (!EncriptaDesencripta.encripta(pass).equals(usuario.ClaveAcceso)))
					{
					   mostrarAdvertencia(Mensajes.get("MDB050601"));
						
					}
					else
					{
						if (!usuario.PERClave.equals("Admin"))
						{
							mostrarAdvertencia(Mensajes.get("I0271"));
						}
						else
						{
							if(tipoIndice.equals("8"))
							{
								Sesion.set(Campo.SolicitarContrasenaDescarga, "0");
							}
							
							if(tipoIndice.equals("8"))
							{
								Sesion.set(Campo.SolicitarContrasenaDevolucionAlmacen, "0");
							}
							
							mPresenta.seleccionar(val);
						}
					}
				}
			}
		}).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{
                // regresar();
			}
		}).setOnKeyListener(new OnKeyListener()
		{
			
			@Override
			public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event)
			{
				switch (keyCode)
				{
					case KeyEvent.KEYCODE_BACK:
						//regresar();
						break;
				}
				return false;
			}
		});
		alert.show();
		
		//return vali;
	}
    
	private boolean validarInformacion(String id, String pass)//Metodo que valida permisos ldelatorre
	{
		if (id.length() == 0)
		{
			mostrarAdvertencia(Mensajes.get("BE0001", Mensajes.get("XUsuario")));
			return false;
		}
		if (pass.length() == 0)
		{
			mostrarAdvertencia(Mensajes.get("BE0001", Mensajes.get("XContraseña")));
			return false;
		}
		return true;
	}

	
}
