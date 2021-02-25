package com.amesol.routelite.vistas;

import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.ContextMenu.ContextMenuInfo;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.AdapterContextMenuInfo;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Cobranza;
import com.amesol.routelite.actividades.Recibos;
import com.amesol.routelite.actividades.ValoresReferencia;
import com.amesol.routelite.actividades.Cobranza.VistaCobranza;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Cliente;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Visita;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.utilerias.ConfigParametro;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.Enumeradores.Resultados;
import com.amesol.routelite.presentadores.act.SeleccionarCobranza;
import com.amesol.routelite.presentadores.interfaces.ICapturaCobranzaDocs;
import com.amesol.routelite.presentadores.interfaces.ISeleccionCobranza;
import com.amesol.routelite.utilerias.EncriptaDesencripta;
import com.amesol.routelite.vistas.generico.CobranzaAdapter;

public class SeleccionCobranza extends Vista implements ISeleccionCobranza
{

	SeleccionarCobranza mPresenta;
	String mAccion;

	boolean iniciarActividad;
    private int solicitarContrasena;
    private int posicionEliminar;
    String contrasenaPara = "";
    int tipoPermiso;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		try
		{
			super.onCreate(savedInstanceState);
			mAccion = getIntent().getAction();

			setContentView(R.layout.seleccion_transaccion);
			deshabilitarBarra(true);

			lblTitle.setText(Mensajes.get("XCobranza"));
			Button btn = (Button) findViewById(R.id.btnContinuar);
			btn.setText(Mensajes.get("XContinuar"));
			btn.setOnClickListener(mContinuar);

			ListView lista = (ListView) findViewById(R.id.lstTransaccion);
			lista.setOnItemClickListener(mSeleccion);
			registerForContextMenu(lista);

            solicitarContrasena = Integer.parseInt(String.valueOf(Sesion.get(Campo.SolicitarContrasenaCobranza)));

			mPresenta = new SeleccionarCobranza(this, mAccion);
			mPresenta.iniciar();
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				setResult(Resultados.RESULTADO_BIEN);
				this.finish();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	@Override
	public void onCreateContextMenu(ContextMenu menu, View v, ContextMenuInfo menuInfo)
	{
		super.onCreateContextMenu(menu, v, menuInfo);
		MenuInflater inflater = getMenuInflater();
		inflater.inflate(R.menu.context_lista_abonos, menu);

		menu.getItem(0).setTitle(Mensajes.get("XEliminar"));
	}

	@Override
	public boolean onContextItemSelected(MenuItem item)
	{
		AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
        posicionEliminar = (int)info.position;
        validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.ELIMINAR);
		/*ListView lista = (ListView) findViewById(R.id.lstTransaccion);

		CobranzaAdapter adapter = (CobranzaAdapter) lista.getAdapter();
		VistaCobranza abono = (VistaCobranza) lista.getItemAtPosition((int) info.position);

		if (!abono.getVisitaclave().equals(((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave) && !abono.getDiaclave().equals(((Visita)Sesion.get(Campo.VisitaActual)).DiaClave)){
			if (mPresenta.quitarAsociacionAbono(abono.getABNId())) {
				adapter.remove(abono);
				adapter.notifyDataSetChanged();
			}
		}else {
			if (mPresenta.eliminarCobranza(abono.getABNId())) {
				adapter.remove(abono);
				adapter.notifyDataSetChanged();
			}
		}*/

		return true;
	}

    private boolean eliminarCobranza(){
        //AdapterContextMenuInfo info = (AdapterContextMenuInfo) item.getMenuInfo();
        ListView lista = (ListView) findViewById(R.id.lstTransaccion);

        CobranzaAdapter adapter = (CobranzaAdapter) lista.getAdapter();
        VistaCobranza abono = (VistaCobranza) lista.getItemAtPosition(posicionEliminar);

        try{
            if(Consultas.ConsultasAbono.obtenerAbonosTarjeta(abono.getABNId()) > 0) {
                mostrarError(Mensajes.get("E1013"));
                return false;
            }
        }catch (Exception ex){
            mostrarError(ex.getMessage());
        }

        if (!abono.getVisitaclave().equals(((Visita)Sesion.get(Campo.VisitaActual)).VisitaClave) && !abono.getDiaclave().equals(((Visita)Sesion.get(Campo.VisitaActual)).DiaClave)){
            if (mPresenta.quitarAsociacionAbono(abono.getABNId())) {
                adapter.remove(abono);
                adapter.notifyDataSetChanged();
            }
        }else {
            if (mPresenta.eliminarCobranza(abono.getABNId())) {
                adapter.remove(abono);
                adapter.notifyDataSetChanged();
            }
        }

        return true;
    }

    public void validarPermisos(String tipoIndice, int tipoPermiso) //Metodo que valida permisos ldelatorre
    {
        boolean solicitar = false;
        try
        {

            String id = "TINDMMD" + tipoIndice;
            String permiso = Consultas.ConsultasPermisos.validarPermisos(id);
            this.contrasenaPara = ValoresReferencia.getDescripcion("TINDMMD", String.valueOf(tipoIndice));
            this.tipoPermiso = tipoPermiso;

            if (permiso.equals("1"))
                solicitar = false;
            else
            {
                switch(tipoPermiso)
                {
                    case Enumeradores.TipoPermiso.CREAR:
                        if(!lineaPermiso('C',permiso) && solicitarContrasena == 1)
                            solicitar = true;
                        break;

                    case Enumeradores.TipoPermiso.MODIFICAR:
                        if(!lineaPermiso('U',permiso) && solicitarContrasena == 1)
                            solicitar = true;
                        break;

                    case Enumeradores.TipoPermiso.ELIMINAR:
                        if(!lineaPermiso('D',permiso) && solicitarContrasena == 1)
                            solicitar = true;
                        break;
                }
            }

            if (solicitar)
                solicitarAcceso(contrasenaPara, tipoPermiso);
            else {
                if (tipoPermiso == Enumeradores.TipoPermiso.ELIMINAR)
                    eliminarCobranza();
                else if (tipoPermiso == Enumeradores.TipoPermiso.CREAR)
                    generarCobranza();
            }

        }
        catch (Exception e)
        {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }

        //return validar;
    }

    public void solicitarAcceso(String contrasenaPara, final int tipoPermiso)
    {

        LayoutInflater factory = LayoutInflater.from(this);

        final View textEntryView = factory.inflate(R.layout.acceso_dia_diferente, null);

        final TextView lblLogin = (TextView) textEntryView.findViewById(R.id.lblAlertUser);
        lblLogin.setText(Mensajes.get("XUsuario"));

        final TextView lblPass = (TextView) textEntryView.findViewById(R.id.lblAlertPass);
        lblPass.setText(Mensajes.get("XContraseña"));

        final EditText txtUser = (EditText) textEntryView.findViewById(R.id.txtAlertUser);
        final EditText txtPass = (EditText) textEntryView.findViewById(R.id.txtAlertPass);

        final AlertDialog.Builder alert = new AlertDialog.Builder(this, R.style.MisClientes_CustomDialog);
        alert.setCancelable(false);
        alert.setTitle(contrasenaPara).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                String clave = txtUser.getText().toString();
                String pass = txtPass.getText().toString();
                boolean continuar = false;

                if (validarInformacion(clave, pass)) {
                    Usuario usuario = null;
                    try {
                        usuario = Consultas.ConsultasUsuario.obtenerUsuarioPorClave(clave);
                    } catch (Exception e) {
                        e.printStackTrace();
                        //continuar = false;
                        mostrarError(e.getMessage(), 4);
                    }

                    if ((usuario == null) || (!EncriptaDesencripta.encripta(pass).equals(usuario.ClaveAcceso))) {
                        // = false;
                        mostrarMensaje(Mensajes.get("MDB050601"), 0, 4);
                    } else {
                        String[] perfiles;
                        List<String> listaPerfiles = new ArrayList();
                        String perfilesAutorizados = "";
                        try {
                            if (((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).existeParametro("PerfilContraseñaUsuario", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString())) {
                                perfiles = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("PerfilContraseñaUsuario", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString().toUpperCase().split("\\|");
                                listaPerfiles = Arrays.asList(perfiles);
                                perfilesAutorizados = ((ConfigParametro) Sesion.get(Sesion.Campo.ConfigParametro)).get("PerfilContraseñaUsuario", Sesion.get(Sesion.Campo.ModuloMovDetalleClave).toString()).toString().toUpperCase();
                            }
                        } catch (Exception ex) {
                            //continuar = false;
                            if (ex != null && ex.getMessage() != null) {
                                mostrarError(ex.getMessage(), 4);
                            } else {
                                mostrarError("Error al recuperar parámetro PerfilContraseñaUsuario", 4);
                            }

                        }

                        if (listaPerfiles != null && listaPerfiles.size() > 0) {
                            if (!listaPerfiles.contains(usuario.PERClave.toUpperCase())) {
                                //continuar = false;
                                mostrarMensaje(Mensajes.get("I0328", perfilesAutorizados.replace("|", ",")), 0, 4);
                            }
                            else
                                continuar = true;
                        } else {
                            if (!usuario.PERClave.equals("Admin")) {
                                //continuar = false;
                                mostrarMensaje(Mensajes.get("I0271"), 0, 4);
                            }
                            else
                                continuar = true;
                        }
                    }
                }

                if (continuar) {
                    if (tipoPermiso == Enumeradores.TipoPermiso.ELIMINAR)
                        eliminarCobranza();
                    else if (tipoPermiso == Enumeradores.TipoPermiso.CREAR)
                        generarCobranza();
                }
            }
        }).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                //setResult(Resultados.RESULTADO_BIEN);
                //finalizar();
            }
        }).setOnKeyListener(new DialogInterface.OnKeyListener() {
            @Override
            public boolean onKey(DialogInterface dialog, int keyCode, KeyEvent event) {
                /*switch (keyCode)
                {
                    case KeyEvent.KEYCODE_BACK:
                        setResult(Resultados.RESULTADO_BIEN);
                        finalizar();
                        break;
                }*/
                return false;
            }
        });
        alert.show();

        //return vali;
    }

    private boolean validarInformacion(String id, String pass)
    {
        if (id.length() == 0)
        {
            mostrarMensaje(Mensajes.get("BE0001", Mensajes.get("XUsuario")),0,4);
            return false;
        }
        if (pass.length() == 0)
        {
            mostrarMensaje(Mensajes.get("BE0001", Mensajes.get("XContraseña")),0,4);
            return false;
        }
        return true;
    }

    private boolean lineaPermiso(char per, String permisos)//Metodo que valida permisos ldelatorre
    {
        for(int x = 0; x < permisos.length(); x++)
        {
            char caracter = permisos.charAt(x);

            if(caracter == per)
            {
                return true;
            }
        }
        return false;
    }

	private OnItemClickListener mSeleccion = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			VistaCobranza abono = (VistaCobranza) parent.getItemAtPosition(position);
			consultarCobranza(abono);
		}
	};

	private OnClickListener mContinuar = new OnClickListener()
	{
		public void onClick(View v)
		{
            validarPermisos(Sesion.get(Campo.TipoIndiceModuloMovDetalleClave).toString(), Enumeradores.TipoPermiso.CREAR);
		}
	};

	@Override
	public void iniciar()
	{
		// TODO Auto-generated method stub
	}

	@Override
	public void mostrarCobranzaCliente(ArrayList<Cobranza.VistaCobranza> oAbonos)
	{
		// TODO Auto-generated method stub
		ListView lista = (ListView) findViewById(R.id.lstTransaccion);
		CobranzaAdapter adapter = new CobranzaAdapter(this, R.layout.lista_dividida2, oAbonos);
		lista.setAdapter(adapter);
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN)
		{
			//			mPresenta.actualizarCobranza();
			//TODO se cambio el actualizar por finalizar, verificar que no efecte en otra cosa.
			setResultado(Resultados.RESULTADO_BIEN);
			finalizar();
		}
		else if (resultCode == Enumeradores.Resultados.RESULTADO_MAL)
		{
			String mensajeError = (String) data.getExtras().getString("mensajeIniciar");
			if (mPresenta.existenAbonos())
				mostrarError(mensajeError);
			else
			{
				setResultado(Resultados.RESULTADO_MAL, mensajeError);
				finalizar();
			}
		}
		else if (resultCode == Enumeradores.Resultados.RESULTADO_TERMINAR)
		{
			if (!mPresenta.existenAbonos())
			{
				setResultado(Resultados.RESULTADO_BIEN);
				finalizar();
			}
		}
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
        /*if (tipoMensaje == 4){
            solicitarAcceso(this.contrasenaPara, this.tipoPermiso);
        }*/
	}

	private void consultarCobranza(VistaCobranza abono)
	{
		try
		{
			HashMap<String, Cobranza.VistaCobranza> oParametros = new HashMap<String, Cobranza.VistaCobranza>();
			oParametros.put("Abono", abono);
			iniciarActividadConResultado(ICapturaCobranzaDocs.class, 0, Enumeradores.Acciones.ACCION_CONSULTAR_COBRANZA, oParametros);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}
	}

	private void generarCobranza()
	{
		try
		{
            HashMap<String, Object> oParametros = new HashMap<String, Object>();
            oParametros.put("PermisoValidado", "1");
            if (mAccion.equals(Enumeradores.Acciones.ACCION_SELECCIONAR_COBRANZA_SIMPLE))
                iniciarActividadConResultado(ICapturaCobranzaDocs.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA_SIMPLE, oParametros);
            else
			    iniciarActividadConResultado(ICapturaCobranzaDocs.class, 0, Enumeradores.Acciones.ACCION_GENERAR_COBRANZA,oParametros);
		}
		catch (Exception e)
		{
			mostrarError(e.getMessage() + ". " + e.getCause().getMessage());
			e.printStackTrace();
		}

	}

	@Override
	public void setCliente(String cliente)
	{
		TextView texto = (TextView) findViewById(R.id.lblCliente);
		texto.setText(cliente);
	}

	@Override
	public void setRuta(String ruta)
	{
		TextView texto = (TextView) findViewById(R.id.lblRuta);
		texto.setText(Mensajes.get("XRuta") + ": " + ruta);
	}

	@Override
	public void setDia(String dia)
	{
		TextView texto = (TextView) findViewById(R.id.lblDia);
		texto.setText(Mensajes.get("XDiaTrabajo") + ": " + dia);
	}

}
