package com.amesol.routelite.vistas;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.datos.Dia;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.VendedorJornada;
import com.amesol.routelite.datos.basedatos.BDVend;
import com.amesol.routelite.datos.basedatos.Consultas;
import com.amesol.routelite.datos.generales.ISetDatos;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.datos.utilerias.Sesion.Campo;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.Enumeradores.RespuestaMsg;
import com.amesol.routelite.presentadores.act.SeleccionarAgenda;
import com.amesol.routelite.presentadores.interfaces.ISeleccionAgenda;
import com.amesol.routelite.utilerias.EncriptaDesencripta;

@SuppressLint("NewApi")
public class SeleccionAgenda extends Vista implements ISeleccionAgenda
{
	SeleccionarAgenda mPresenta;
	String mAccion;
	String sDiaClave;
	String sRUTClave;
	boolean validando;

	@Override
	public void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		mAccion = getIntent().getAction();
		setContentView(R.layout.seleccion_agenda);
		deshabilitarBarra(true);

		validando = false;
		TextView lblTitulo = (TextView) findViewById(R.id.txtTitulo);
		if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA)))
		{

			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XRuta")));
			lblTitulo.setText(Mensajes.get("XDiaTrabajo") + ": " + ((Dia) Sesion.get(Campo.DiaActual)).DiaClave);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO)))
		{
			lblTitle.setText(Mensajes.get("XSeleccionar", Mensajes.get("XDiaTrabajo")));
			lblTitulo.setVisibility(View.INVISIBLE);
		}
		//		ISeleccionPedido
		mPresenta = new SeleccionarAgenda(this, mAccion);
		mPresenta.iniciar();
	}

	public String getsDiaClave()
	{
		return sDiaClave;
	}

	public void showAlertDialog()
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
		alert.setTitle(Mensajes.get("XContrasenaCambioDiaTrabajo")).setView(textEntryView).setPositiveButton(Mensajes.get("BTContinuar"), new DialogInterface.OnClickListener()
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
						mostrarAdvertencia(Mensajes.get("MDB050601"));
					else
					{
						if (!usuario.PERClave.equals("Admin"))
							mostrarAdvertencia(Mensajes.get("I0271"));
						else
							mPresenta.Acceder();
					}
				}
			}
		}).setNegativeButton(Mensajes.get("BTRegresar"), new DialogInterface.OnClickListener()
		{
			public void onClick(DialogInterface dialog, int whichButton)
			{

			}
		});
		alert.show();
	}

	private boolean validarInformacion(String id, String pass)
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

	@Override
	public boolean onKeyDown(int keyCode, KeyEvent event)
	{
		switch (keyCode)
		{
			case KeyEvent.KEYCODE_BACK:
				mPresenta.toActividadesVed();
				finalizar();
				return true;
		}
		return super.onKeyDown(keyCode, event);
	}

	private OnItemClickListener mSeleccion = new OnItemClickListener()
	{
		public void onItemClick(AdapterView<?> parent, View v, int position, long id)
		{
			if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_VINCULADO)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_VINCULADO_RUTA)))
			{
				Cursor dia = (Cursor) parent.getItemAtPosition(position);
				dia.moveToPosition(position);
				sDiaClave = dia.getString(1);
			}
			else if ((mAccion != null) && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_RUTA) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO_RUTA))) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES_RUTA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA_RUTA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO_RUTA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION_RUTA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS_RUTA)) || (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO_RUTA)))
			{
				Cursor ruta = (Cursor) parent.getItemAtPosition(position);
				ruta.moveToPosition(position);
				sRUTClave = ruta.getString(1);
			}
			mPresenta.seleccionar();
		}
	};

	public void iniciar()
	{
		// TODO Auto-generated method stub
	}

	@SuppressWarnings("deprecation")
	public void mostrarDiasTrabajo(ISetDatos dias)
	{
		// TODO Auto-generated method stub
		ListView lista = (ListView) findViewById(R.id.lstAgenda);
		Cursor cDias = (Cursor) dias.getOriginal();
		startManagingCursor(cDias);
		ListAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple1, cDias, new String[]
		{ "DiaClave" }, new int[]
		{ R.id.texto1 });
		lista.setAdapter(adapter);
		lista.setOnItemClickListener(mSeleccion);
	}

	@SuppressWarnings("deprecation")
	public void mostrarRutasTrabajo(ISetDatos rutas)
	{
		ListView lista = (ListView) findViewById(R.id.lstAgenda);
		Cursor cRutas = (Cursor) rutas.getOriginal();
		startManagingCursor(cRutas);
		ListAdapter adapter = new SimpleCursorAdapter(this, R.layout.lista_simple1, cRutas, new String[]
		{ "Descripcion" }, new int[]
		{ R.id.texto1 });
		lista.setAdapter(adapter);
		lista.setOnItemClickListener(mSeleccion);
	}

	public String getDia()
	{
		// TODO Auto-generated method stub
		return sDiaClave;
	}

	public String getRuta()
	{
		// TODO Auto-generated method stub
		return sRUTClave;
	}

	@Override
	public void resultadoActividad(int requestCode, int resultCode, Intent data)
	{
		// TODO Auto-generated method stub
	}

	@Override
	public void respuestaMensaje(RespuestaMsg respuesta, int tipoMensaje)
	{
		// TODO Auto-generated method stub
		if (respuesta.equals(RespuestaMsg.OK) && validando && (mAccion.equals(Enumeradores.Acciones.ACCION_ATENDER_CLIENTES_DIA)
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_MOVIMIENTO_SIN_INVENTARIO))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_AJUSTES))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DESCARGA))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEPOSITO))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_DEVOLUCION))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_CARGAS))
				|| (mAccion.equals(Enumeradores.Acciones.ACCION_CAPTURAR_TRASPASO))))
		{
			//			ListView lista = (ListView) findViewById(R.id.lstAgenda);
			//			if (lista.getCount() <= 0)
			mPresenta.toActividadesVed();
		}
	}

	public boolean validarJornadaTrabajo()
	{
		try
		{
			validando = false;
			Vendedor vendedor = (Vendedor)
					Sesion.get(Campo.VendedorActual);
			if (vendedor.JornadaTrabajo)
			{
				Dia dia = (Dia) Sesion.get(Campo.DiaActual);
				VendedorJornada vendedorJornada =
						Consultas.ConsultasVendedorJornada.obtenerJornada(vendedor, dia);
				if (vendedorJornada != null)
					if (vendedorJornada.FechaFinal != null)
					{
						validando = true;
						mostrarAdvertencia(Mensajes.get("E0488"));
						return false;
					}
					else
						return true;
				else
				{
					vendedorJornada =
							Consultas.ConsultasVendedorJornada
									.obtenerJornadaActual(vendedor);
					if (vendedorJornada != null)
					{
						vendedorJornada.DiaClave = dia.DiaClave;
						vendedorJornada.Enviado = false;
						BDVend.guardarInsertar(vendedorJornada);
						BDVend.commit();
						return true;
					}
					else
					{
						validando = true;
						mostrarAdvertencia(Mensajes.get("E0487"));
						return false;
					}
				}
			}
			else
				return true;
		}
		catch (Exception e)
		{
			e.printStackTrace();
			mostrarError(e.getMessage());
			return false;
		}
	}

	public boolean getValidando()
	{
		return validando;
	}
	
	public void setValidando(boolean val)
	{
		validando = val;
	}
}

