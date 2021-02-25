using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class ClientesEsquemasVIT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string esquemaID, string Cedis, string nombreEsquema)
        {
            esquemaID = esquemaID.Replace(",", "','");


            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine(" ");
            sConsulta.AppendLine("select isnull(a.Clave,'XXX') as ClaveAlmacen, isnull(a.Nombre,'Sin Asignacion a Cedi') as NombreAlmacen, e.Clave as ClaveEsquema, e.Nombre as NombreEsquema, c.Clave as ClaveCliente, c.RazonSocial, c.NombreCorto, isnull(cd.Calle,'')+' '+isnull(cd.Numero,'')+' '+isnull(cd.NumInt,'') as Domicilio, cd.Colonia, cd.Localidad ");
            sConsulta.AppendLine("from Cliente c (NOLOCK) ");
            sConsulta.AppendLine("inner join ClienteDomicilio cd (NOLOCK) on c.ClienteClave=cd.ClienteClave and cd.Tipo=2 ");
            sConsulta.AppendLine("inner join ClienteEsquema ce (NOLOCK) on c.ClienteClave=ce.ClienteClave ");
            sConsulta.AppendLine("inner join Esquema e (NOLOCK) on ce.EsquemaID=e.EsquemaID ");
            sConsulta.AppendLine("left join Almacen a (NOLOCK) on c.AlmacenID=a.AlmacenID and a.Tipo=1 ");
            sConsulta.AppendLine(pvCondicion);
            sConsulta.AppendLine(" and e.EsquemaID in('" + esquemaID + "') ");


            QueryString = "";

            QueryString = sConsulta.ToString();


            List<clientesEsq> clientesEsquemas = Connection.Query<clientesEsq>(QueryString, null, null, true, 600).ToList();
            if (clientesEsquemas.Count <= 0)
                return null;

            var esquemas = (from A in clientesEsquemas group A by new { A.NombreEsquema } into grupo select grupo);
            List<clientesEsq> esqList = new List<clientesEsq>();

            foreach (var gEsquema in esquemas)
            {
                foreach (var objetoAgrupado in gEsquema)
                {
                    esqList.Add(new clientesEsq
                    {
                        NombreEsquema = objetoAgrupado.NombreEsquema,
                        ClaveCliente = objetoAgrupado.ClaveCliente,
                        RazonSocial = objetoAgrupado.RazonSocial,
                        NombreCorto = objetoAgrupado.NombreCorto,
                        Domicilio = objetoAgrupado.Domicilio,
                        Colonia = objetoAgrupado.Colonia,
                        Localidad = objetoAgrupado.Localidad
                    });
                }
            }

            ClientesEsqueVIT report = new ClientesEsqueVIT();
            report.DataSource = clientesEsquemas;

            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;

            if (!esquemaID.Contains("','"))
                report.lbEsquema.Text = nombreEsquema;

            GroupField groupEsquema = new GroupField("NombreEsquema");
            report.GroupHeader1.GroupFields.Add(groupEsquema);
            report.lbEsquemas.DataBindings.Add("Text", null, "NombreEsquema");

            report.lbClave.DataBindings.Add("Text", null, "ClaveCliente");
            report.lbRazonSocial.DataBindings.Add("Text", null, "RazonSocial");
            report.lbNombre.DataBindings.Add("Text", null, "NombreCorto");
            report.lbDomicilio.DataBindings.Add("Text", null, "Domicilio");
            report.lbColonia.DataBindings.Add("Text", null, "Colonia");
            report.lbMunicipio.DataBindings.Add("Text", null, "Localidad");

            return report;
        }
    }

    class clientesEsq
    {
        public String NombreEsquema { get; set; }
        public String ClaveCliente { get; set; }
        public String NombreCorto { get; set; }
        public String RazonSocial { get; set; }
        public String Colonia { get; set; }
        public String Domicilio { get; set; }
        public String Localidad { get; set; }
    }
}