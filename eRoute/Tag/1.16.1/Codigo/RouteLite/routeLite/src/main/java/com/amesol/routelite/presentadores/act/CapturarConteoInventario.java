package com.amesol.routelite.presentadores.act;

import com.amesol.routelite.datos.ConteoInventario;
import com.amesol.routelite.datos.Usuario;
import com.amesol.routelite.datos.Vendedor;
import com.amesol.routelite.datos.utilerias.Sesion;
import com.amesol.routelite.presentadores.Presentador;
import com.amesol.routelite.utilerias.Generales;
import com.amesol.routelite.utilerias.KeyGen;

public class CapturarConteoInventario extends Presentador {

    ConteoInventario conteoInventario;

    @Override
    public void iniciar() {
        generarConteoInventario();

    }

    private void generarConteoInventario(){
        conteoInventario = new ConteoInventario();
        conteoInventario.ContId = KeyGen.getId();
        conteoInventario.FechaHoraAlta = Generales.getFechaHoraActual();
        conteoInventario.AlmacenID = ((Vendedor)Sesion.get(Sesion.Campo.VendedorActual)).AlmacenID;
        conteoInventario.UsuarioId = ((Usuario)Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
        conteoInventario.MFechaHora = Generales.getFechaHoraActual();
        conteoInventario.MUsuarioID = ((Usuario)Sesion.get(Sesion.Campo.UsuarioActual)).USUId;
        conteoInventario.Enviado = false;
    }
}
