using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.DataAccess.Sql;

namespace eRoute.Models.ReportesModels
{
    public class MClientesSinVentas
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        //ClientesSinVenta report = new ClientesSinVenta();

        public XtraReport GetReport(string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal)
        {
            try
            {
                DateTime fInicio = DateTime.Parse(FechaInicial);
                DateTime fFin = DateTime.Now;
                if (String.IsNullOrEmpty(FechaFinal) || FechaFinal == "null")
                {
                    FechaFinal = "";
                }
                else
                {
                    fFin = DateTime.Parse(FechaFinal);
                    FechaFinal = " - " + fFin.Date.ToShortDateString();
                }
                string LogoQuery = "Select Logotipo from Configuracion (NOLOCK)";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);

                #region consulta
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("select * from (");
                sConsulta.AppendLine("select distinct 'Clientes No Visitados' as AgrupadorEncabezado, dia.DiaClave as FechaCaptura, rut.RUTClave + '-' + rut.Descripcion as Ruta, CLI.Clave, CLI.RazonSocial, CLI.NombreCorto, CLD.Calle, ");
                sConsulta.AppendLine("CLD.Numero, CLD.NumInt,	'' as Improductividad ");
                sConsulta.AppendLine("from AgendaVendedor avg (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON dia.DiaClave = avg.DiaClave ");
                sConsulta.AppendLine("inner join Ruta rut (NOLOCK) ON rut.RUTClave = avg.RUTClave ");
                sConsulta.AppendLine("inner join Cliente cli (NOLOCK) ON cli.ClienteClave = avg.ClienteClave ");
                sConsulta.AppendLine("inner join ClienteDomicilio cld (NOLOCK) ON cld.ClienteClave = cli.ClienteClave AND cld.Tipo= 2 ");
                sConsulta.AppendLine("where avg.ClienteClave not in ( select  vis.ClienteClave ");
                sConsulta.AppendLine("from Visita vis (NOLOCK) ");
                sConsulta.AppendLine("where vis.DiaClave = avg.DiaClave ) ");
                sConsulta.AppendLine(pvCondicion);
                //sConsulta.AppendLine(" and rut.RUTClave in ('002','083')  and convert(datetime,Convert(varchar(20),dia.FechaCaptura,112)) between '2016-11-01T00:00:00' and '2016-12-31T00:00:00' ");
                sConsulta.AppendLine("union all ");
                sConsulta.AppendLine("select distinct 'Clientes Visitados Sin Venta' as AgrupadorEncabezado, dia.DiaClave as FechaCaptura, rut.RUTClave + '-' + rut.Descripcion as Ruta, CLI.Clave, CLI.RazonSocial, CLI.NombreCorto, CLD.Calle, ");
                sConsulta.AppendLine("CLD.Numero, CLD.NumInt, vdes.Descripcion as Improductividad ");
                sConsulta.AppendLine("from ImproductividadVenta impvta (NOLOCK) ");
                sConsulta.AppendLine("inner join Visita vis (NOLOCK) ON impvta.VisitaClave=vis.VisitaClave ");
                sConsulta.AppendLine("inner join Ruta rut (NOLOCK) ON vis.RUTClave=rut.RUTClave ");
                sConsulta.AppendLine("inner join Cliente cli (NOLOCK) ON cli.ClienteClave = vis.ClienteClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON dia.DiaClave = impvta.DiaClave ");
                sConsulta.AppendLine("inner join ClienteDomicilio cld (NOLOCK) ON cld.ClienteClave = cli.ClienteClave AND cld.Tipo= 2 ");
                sConsulta.AppendLine("inner join VAVDescripcion vdes (NOLOCK) ON vdes.VARCodigo='MOTIMPRO' and impvta.TipoMotivo=vdes.VAVClave and vdes.VADTipoLenguaje=(select dbo.FNObtenerLenguaje()) ");
                sConsulta.AppendLine("where vis.ClienteClave in (select  avg.ClienteClave ");
                sConsulta.AppendLine("from AgendaVendedor avg (NOLOCK) ");
                sConsulta.AppendLine("where avg.DiaClave = vis.DiaClave) ");
                sConsulta.AppendLine(pvCondicion);
                //sConsulta.AppendLine(" and rut.RUTClave in ('002','083')  and convert(datetime,Convert(varchar(20),dia.FechaCaptura,112)) between '2016-11-01T00:00:00' and '2016-12-31T00:00:00' ");
                sConsulta.AppendLine(") as t ");
                sConsulta.AppendLine("order by t.Clave ");
                QueryString = sConsulta.ToString();
                #endregion
                ClientesSinVenta report = new ClientesSinVenta(QueryString);

                //ReportHeader
                report.Logo.Image = Image.FromStream(mStream);
                report.Logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.L_FechaRango.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                report.L_Ruta.Text = RutasSplit;

                return report;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}