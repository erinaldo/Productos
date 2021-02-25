using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace eRoute.Models
{
    public class ProfileModel
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

        public List<cModulo> GetModules(String sPERClave, String sUSUId) {
            string sQuery = "select MODId, MENClave as Clave, MENDetalle.Descripcion as Nombre, Secuencia, Imagen, null ";
            sQuery += "from Modulo ";
            sQuery += "inner join MENDetalle on Modulo.MENNombreClave = MENDetalle.MENClave and MEDTipoLenguaje = 'EM' ";
            sQuery += "where MODId in ( ";
            sQuery += "select distinct MODId ";
            sQuery += "from IntPer ";
            sQuery += "where PERClave = '" + sPERClave + "' and INTTipoInterfaz in (1,3) ";
            sQuery += "union ";
            sQuery += "select distinct MODId ";
            sQuery += "from IntUsu ";
            sQuery += "where USUId = '" + sUSUId +"' and INTTipoInterfaz in (1,3)) ";
            sQuery += "order by TipoInterfaz, Secuencia ";

            List<cModulo> lstModulos = Connection.Query<cModulo>(sQuery).ToList();
            foreach (cModulo oModulo in lstModulos) {
                oModulo.SetImagenBase64();
                GetActivities(oModulo, sPERClave, sUSUId);
            }
            return lstModulos;
        }

        public void GetActivities(cModulo oModulo, string sPERClave, string sUSUId)
        {
            string sQuery = "select ACTId, Nombre, Permiso, Secuencia, TipoActividad from (";
            sQuery += "select T.Valor as ACTId, case when(T.ACTId like 'ReporteW%' or T.ACTId like 'MapaW%') then V.Descripcion else M.Descripcion end as Nombre, T.Permiso, T.Secuencia, A.TipoActividad, VV.Estado ";
            sQuery += "from( ";
            sQuery += "select ACTId, Permiso, Secuencia, case when(ACTId like 'ReporteW%') then replace(ACTId, 'ReporteW', '') else replace(ACTId, 'MapaW', '') end as Valor ";
            sQuery += "from IntPer ";
            sQuery += "where PERClave = '" + sPERClave + "' and INTTipoInterfaz in (1, 3) ";
            sQuery += "and ACTId not in (select ACTId from IntUsu where USUId = '" + sUSUId + "' and INTTipoInterfaz in (1,3)) ";
            sQuery += "and MODId = '" + oModulo.MODId + "' ";
            sQuery += "union ";
            sQuery += "select ACTId, Permiso, Secuencia, case when(ACTId like 'ReporteW%') then replace(ACTId, 'ReporteW', '') else replace(ACTId, 'MapaW', '') end as Valor ";
            sQuery += "from IntUsu ";
            sQuery += "where USUId = '" + sUSUId + "' and INTTipoInterfaz in (1,3) ";
            sQuery += "and MODId = '" + oModulo.MODId + "') as T ";
            sQuery += "inner join Actividad A on T.ACTId = A.ACTId ";
            sQuery += "left join MENDetalle M on A.MENNombreClave = M.MENClave and M.MEDTipoLenguaje = 'EM' ";
            sQuery += "left join VAVDescripcion V on T.Valor = V.VAVClave and((t.ACTId like 'ReporteW%' and V.VARCodigo = 'REPORTEW') or(t.ACTId like 'MapaW%' and V.VARCodigo = 'MAPAW')) and V.VADTipoLenguaje = 'EM' ";
            sQuery += "left join VARValor VV on V.VARCodigo = VV.VARCodigo and V.VAVClave = VV.VAVClave ";
            sQuery += ") as T2 ";
            sQuery += "where Estado is null or Estado = 1 ";
            sQuery += "order by Secuencia ";

            oModulo.Actividades = Connection.Query<cActividad>(sQuery).ToList();
        }
    }

    public class cModulo {
        public string MODId { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int Secuencia { get; set; }
        public byte[] Imagen { get; set; }
        public string ImagenBase64 { get; set; }
        public int TipoInterfaz { get; set; }
        public List<cActividad> Actividades { get; set; }

        public void SetImagenBase64()
        {
            ImagenBase64 = Convert.ToBase64String(Imagen);
        }
    }

    public class cActividad {
        public string ACTId { get; set; }
        public string Nombre { get; set; }
        public string Permiso { get; set; }
        public string PermisoA { get; set; }
        public int Secuencia { get; set; }
        public int TipoActividad { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Execute { get; set; }
        public bool Others { get; set; }
        public bool Print { get; set; }
        public bool Sign { get; set; }
        public bool PERAct { get; set; }
        public bool Asignada { get; set; }
    }
}