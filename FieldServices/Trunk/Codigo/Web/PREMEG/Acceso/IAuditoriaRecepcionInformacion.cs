using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODMEG;

namespace PREMEG.Acceso
{
    public interface IAuditoriaRecepcionInformacion
    {
        int NoCuadrillas {  set; }
        int CuadrillasSalieronDeBase {set; }
        int CuadrillasRegresaronABase { set; }
        int TNNoCuadrillas { set; }
        int TNCuadrillasSalieronDeBase { set; }
        int TNCuadrillasRegresaronABase { set; }
        void PoblarAuditoria(List<AuditarRecepcionInformacion.ElementoAuditoriaRecepcion> auditoria);
    }
}
