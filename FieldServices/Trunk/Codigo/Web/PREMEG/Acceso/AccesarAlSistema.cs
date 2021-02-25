using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public class AccesarAlSistema
    {
        private IAccesoSistema _boundary;
        public AccesarAlSistema(IAccesoSistema boundary)
        {
            _boundary = boundary;
        }
        public Usuario ValidarAccesoUsuario()
        {
            MegaCableEntities contexto = new MegaCableEntities();
            Usuario usuario = contexto.Usuario.FirstOrDefault(u => u.ClaveUsuario == _boundary.Usuario);
            Usuario res= null;
            if (usuario == null)
                _boundary.MensajeError(UtilMensaje.ObtenerMensaje("#MI0002"));
            else if (usuario.Contrasenia != _boundary.Contrasenia)
                _boundary.MensajeError(UtilMensaje.ObtenerMensaje("#MI0003"));
            else if (usuario.Perfil.Actividad.Count() == 0)
                _boundary.MensajeError(UtilMensaje.ObtenerMensaje("#ME0001"));
            else if (!usuario.Estado)
                _boundary.MensajeError(UtilMensaje.ObtenerMensaje("#ME0002"));
            else if (!usuario.Perfil.Estado)
                _boundary.MensajeError(UtilMensaje.ObtenerMensaje("#ME0003"));
            else
                res = usuario;

            return res;
        }
    }
}
