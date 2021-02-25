using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace eRoute.Models
{
    public class ProfileModel
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);

        public List<cModulo> GetModules(string sPERClave, string sUSUId)
        {
            string query = string.Format("SELECT [MODId], [MENClave] AS [Clave], [MEN].[Descripcion] AS [Nombre], [Secuencia], [Imagen], NULL"
                + " FROM [dbo].[Modulo] AS [MOD] (NOLOCK)"
                + " INNER JOIN [dbo].[MENDetalle] AS [MEN] ON [MOD].[MENNombreClave] = [MEN].[MENClave] AND [MEDTipoLenguaje] = 'EM'"
                + " WHERE [MODId] IN ("
                + " SELECT DISTINCT [MODId]"
                + " FROM [dbo].[IntPer] (NOLOCK)"
                + " WHERE [PERClave] = '{0}' AND [INTTipoInterfaz] IN (1,3)"
                + " UNION"
                + " SELECT DISTINCT [MODId]"
                + " FROM [dbo].[IntUsu] (NOLOCK)"
                + " WHERE [USUId] = '{1}' AND [INTTipoInterfaz] IN (1,3))"
                + " ORDER BY [TipoInterfaz], [Secuencia]",
                sPERClave, sUSUId);

            List<cModulo> lstModulos = Connection.Query<cModulo>(query).ToList();
            foreach (cModulo oModulo in lstModulos)
            {
                oModulo.SetImagenBase64();
                GetActivities(oModulo, sPERClave, sUSUId);
            }
            return lstModulos;
        }

        public void GetActivities(cModulo oModulo, string sPERClave, string sUSUId)
        {
            string query = string.Format("SELECT [T2].[ACTId], [T2].[Nombre], [T2].[Permiso], [T2].[Secuencia], [T2].[TipoActividad]"
                + " FROM ("
                + " SELECT [T].[Valor] AS [ACTId], CASE WHEN ([T].[ACTId] LIKE 'REPORTEW%' OR [T].[ACTId] LIKE 'MAPAW%' OR [T].[ACTId] LIKE 'REPORTED%') THEN [V].[Descripcion] ELSE [M].[Descripcion] END AS [Nombre], [T].[Permiso], [T].[Secuencia], [A].[TipoActividad], [VV].[Estado]"
                + " FROM ("
                + " SELECT [ACTId], [Permiso], [Secuencia], CASE WHEN ([ACTId] LIKE 'REPORTEW%') THEN REPLACE([ACTId], 'REPORTEW', '') ELSE CASE WHEN ([ACTId] LIKE 'REPORTED%') THEN REPLACE([ACTId], 'REPORTED', '') ELSE REPLACE([ACTId], 'MAPAW', '') END END AS [Valor]"
                + " FROM [dbo].[IntPer] (NOLOCK) WHERE [PERClave] = '{0}' AND [INTTipoInterfaz] IN (1, 3) AND [ACTId] NOT IN ("
                + " SELECT [ACTId] FROM [dbo].[IntUsu] (NOLOCK) WHERE [USUId] = '{1}' AND [INTTipoInterfaz] IN (1,3)"
                + " ) AND [MODId] = '{2}'"
                + " UNION"
                + " SELECT [ACTId], [Permiso], [Secuencia], CASE WHEN ([ACTId] LIKE 'REPORTEW%') THEN REPLACE([ACTId], 'REPORTEW', '') ELSE CASE WHEN ([ACTId] LIKE 'REPORTED%') THEN REPLACE([ACTId], 'REPORTED', '') ELSE REPLACE([ACTId], 'MAPAW', '') END END AS [Valor]"
                + " FROM [dbo].[IntUsu] (NOLOCK) WHERE [USUId] = '{1}' AND [INTTipoInterfaz] IN (1,3) AND [MODId] = '{2}'"
                + " ) AS [T]"
                + " INNER JOIN [dbo].[Actividad] AS [A] (NOLOCK) ON [T].[ACTId] = [A].[ACTId]"
                + " LEFT JOIN [dbo].[MENDetalle] AS [M] (NOLOCK) ON [A].[MENNombreClave] = [M].[MENClave] AND [M].[MEDTipoLenguaje] = 'EM'"
                + " LEFT JOIN [dbo].[VAVDescripcion] AS [V] (NOLOCK) ON [T].[Valor] = [V].[VAVClave] AND (([T].[ACTId] LIKE 'REPORTEW%' AND [V].[VARCodigo] = 'REPORTEW') OR ([T].[ACTId] LIKE 'MAPAW%' AND [V].[VARCodigo] = 'MAPAW') OR ([T].[ACTId] LIKE 'REPORTED%' AND [V].[VARCodigo] = 'REPORTED')) AND [V].[VADTipoLenguaje] = 'EM'"
                + " LEFT JOIN [dbo].[VARValor] AS [VV] (NOLOCK) ON [V].[VARCodigo] = [VV].[VARCodigo] AND [V].[VAVClave] = [VV].[VAVClave]"
                + " ) AS [T2]"
                + " WHERE [T2].[Estado] IS NULL OR [T2].[Estado] = 1"
                + " ORDER BY [T2].[Secuencia]",
                sPERClave, sUSUId, oModulo.MODId);
            oModulo.Actividades = Connection.Query<cActividad>(query).ToList();
        }
    }

    public class cModulo
    {
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

    public class cActividad
    {
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