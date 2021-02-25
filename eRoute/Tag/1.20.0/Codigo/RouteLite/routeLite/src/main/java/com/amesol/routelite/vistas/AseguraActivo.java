package com.amesol.routelite.vistas;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.amesol.routelite.R;
import com.amesol.routelite.actividades.Mensajes;
import com.amesol.routelite.controles.TextBoxScanner;
import com.amesol.routelite.datos.basedatos.Consultas2;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Enumeradores;
import com.amesol.routelite.presentadores.act.AsegurarActivo;
import com.amesol.routelite.presentadores.interfaces.IAseguraActivo;
import com.amesol.routelite.presentadores.interfaces.IAutorizaMovimiento;
import com.amesol.routelite.presentadores.interfaces.ISeleccionVisita;

import java.util.HashMap;

public class AseguraActivo extends Vista implements IAseguraActivo {
    String mAccion;
    AsegurarActivo mPresenta;

    TextBoxScanner txtScanner;
    HashMap<String, Object> oParametros = null;

    //public final int MENSAJE_TOKEN = 1;

    @SuppressWarnings("unchecked")
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.asegura_activo);
        deshabilitarBarra(true);

        mAccion = getIntent().getAction();
        mPresenta = new AsegurarActivo(this, mAccion);

        //if (getIntent().getSerializableExtra("parametros") != null)
        oParametros = (HashMap<String, Object>) getIntent().getSerializableExtra("parametros");

        lblTitle.setText("Aseguramiento de Activos");

        TextView texto = (TextView) findViewById(R.id.lblClave);
        texto.setText(Mensajes.get("ACIActivoClave") + ":");

        texto = (TextView) findViewById(R.id.lblNombre);
        texto.setText(Mensajes.get("ACINombre") + ":");

        texto = (TextView) findViewById(R.id.lblTipo);
        texto.setText(Mensajes.get("ACITipo") + ":");

        texto = (TextView) findViewById(R.id.lblCodigo);
        texto.setText(Mensajes.get("XIngresarCodigoActivo"));

        Button boton = (Button) findViewById(R.id.btnOmitir);
        boton.setText(Mensajes.get("XOmitir"));
        boton.setOnClickListener(mOmitir);

        txtScanner = (TextBoxScanner) findViewById(R.id.textBoxScanner);
        txtScanner.setOnCodigoIngresado(mCodigoBarras);

        mPresenta.iniciar();
    }

    @Override
    public void iniciar()
    {

    }

    @Override
    public void respuestaMensaje(Enumeradores.RespuestaMsg respuesta, int tipoMensaje) {
        if (tipoMensaje == 1){
            //finalizar();
            iniciarActividadConResultado(IAutorizaMovimiento.class, Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA);
        }
    }

    @Override
    public void setCliente(String cliente){
        TextView texto = (TextView) findViewById(R.id.lblCliente);
        texto.setText(cliente);
    }

    @Override
    public void setRuta(String ruta){
        TextView texto = (TextView) findViewById(R.id.lblRuta);
        texto.setText(ruta);
    }

    @Override
    public void setDia(String dia){
        TextView texto = (TextView) findViewById(R.id.lblDia);
        texto.setText(dia);
    }

    @Override
    public void setActivoClave(String activoClave){
        TextView texto = (TextView) findViewById(R.id.txtClave);
        texto.setText(activoClave);
    }

    @Override
    public void setNombre(String nombre){
        TextView texto = (TextView) findViewById(R.id.txtNombre);
        texto.setText(nombre);
    }

    @Override
    public void setTipo(String tipo){
        TextView texto = (TextView) findViewById(R.id.txtTipo);
        texto.setText(tipo);
    }

    @Override
    public void setContador(String contador){
        TextView texto = (TextView) findViewById(R.id.lblContador);
        texto.setText(Mensajes.get("XActivo") + " " + contador);
    }

    private View.OnClickListener mOmitir = new View.OnClickListener() {
        public void onClick(View v) {
            mPresenta.mostrarSiguiente();
        }
    };

    @Override
    public void resultadoActividad(int requestCode, int resultCode, Intent data)
    {
        if (requestCode == Enumeradores.Solicitudes.SOLICITUD_AUTORIZARMOVIMIENTO) {
            if (resultCode == Enumeradores.Resultados.RESULTADO_BIEN) {
                if (Sesion.get(Sesion.Campo.ResultadoActividad) != null)
                    oParametros.put("Token", Sesion.get(Sesion.Campo.ResultadoActividad));
                iniciarVisita(mPresenta.getAsignados(), mPresenta.getAsegurados());
            }
            else {
                finalizar();
            }
        }
    }

    private TextBoxScanner.OnCodigoIngresadoListener mCodigoBarras = new TextBoxScanner.OnCodigoIngresadoListener() {

        public void OnCodigoIngresado(String Codigo, int codigoLeido) {
            if (Codigo.length() == 0)
                return;

            HabilitarPantalla(false);
            if (!Codigo.equals("")){
                if (mPresenta.validarActivo(Codigo)){
                    mPresenta.mostrarSiguiente();
                }
            }
            HabilitarPantalla(true);
        }

    };

    public void HabilitarPantalla(Boolean Habilitado) {
        txtScanner.setClickable(Habilitado);
        txtScanner.setEnabled(Habilitado);
        if (Habilitado)
            txtScanner.BorrarTexto();

        this.doevents();
    }

    public void iniciarVisita(int asignados, int asegurados){
        oParametros.put("ActivosAsignados", asignados);
        oParametros.put("ActivosAsegurados", asegurados);
        finalizar();
        iniciarActividad(ISeleccionVisita.class, Enumeradores.Acciones.ACCION_VISITAR_CLIENTE_VISITA, null, false, oParametros);
    }
}
