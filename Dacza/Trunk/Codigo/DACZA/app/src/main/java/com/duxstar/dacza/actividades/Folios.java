package com.duxstar.dacza.actividades;

import com.duxstar.dacza.datos.Folio;
import com.duxstar.dacza.datos.Usuario;
import com.duxstar.dacza.datos.basedatos.BDTerm;
import com.duxstar.dacza.datos.basedatos.Consultas;
import com.duxstar.dacza.datos.generales.ISetDatos;
import com.duxstar.dacza.datos.utilerias.Sesion;
import com.duxstar.dacza.datos.utilerias.Sesion.Campo;
import com.duxstar.dacza.presentadores.Enumeradores;
import com.duxstar.dacza.utilerias.Generales;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Formatter;

/**
 * Created by Adriana on 29/04/2016.
 */
public class Folios {

    public static String obtener(int tipoMovimiento, final StringBuilder byRefMensaje) throws Exception
    {
        String sFolio = "";

        Folio folio = Consultas.ConsultasFolio.obtenerFolio(tipoMovimiento);
        int consecutivo = 1;
        if (folio != null) {
            int tipoContenido;
            String formato;
            consecutivo = folio.ValorInicial + folio.Usados;
            ISetDatos detalles = Consultas.ConsultasFolio.obtenerDetalles(folio.FolioId);
            if (detalles != null) {
                while (detalles.moveToNext()) {
                    tipoContenido = detalles.getInt("TipoContenido");
                    formato = detalles.getString("Formato");

                    switch (tipoContenido) {
                        case Enumeradores.TipoContenidoFolio.ROTULO_FIJO:
                            sFolio += formato;
                            break;
                        case Enumeradores.TipoContenidoFolio.INCREMENTAL_NUMERICO:
                            Formatter fmt = new Formatter();
                            sFolio += fmt.format("%0" + formato.length() + "d", consecutivo);
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("No está definido el formato del folio para el tipo de movimiento");
            }
            detalles.close();
        }

        if (sFolio.length()<=0){
            byRefMensaje.append("No se pudo obtener un folio para el movimiento, se usará uno temporal") ;

            SimpleDateFormat sdf = new SimpleDateFormat("HHmmss");
            String currentDateTimeString = sdf.format(new Date());

            sFolio = currentDateTimeString;
        }
        return sFolio;
    }

    public static void confirmar(int tipoMovimiento) throws Exception{
        Folio folio = Consultas.ConsultasFolio.obtenerFolio(tipoMovimiento);
        folio.Usados ++;
        folio.MFechaHora = Generales.getFechaHoraActual();
        folio.MUsuarioId = ((Usuario) Sesion.get(Campo.UsuarioActual)).UsuarioId;
        folio.Enviado = false;
        BDTerm.guardarInsertar(folio);
    }
}
