using DevExpress.XtraReports.UI;
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
    public class PuntosPorCliente
    {

        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string CEDI, string Clientes)
        {
            StringBuilder sConsulta = new StringBuilder();

            sConsulta.AppendLine("SELECT Cliente.Clave, Cliente.RazonSocial, Cliente.NombreCorto, Punto.Otorgados, Punto.Canjeados, (Punto.Otorgados - Punto.Canjeados) AS Disponibles ");
            sConsulta.AppendLine("FROM Punto (NOLOCK) ");
            sConsulta.AppendLine("INNER JOIN Cliente (NOLOCK) ON Punto.ClienteClave = Cliente.ClienteClave ");
            sConsulta.AppendLine("INNER JOIN Almacen (NOLOCK) ON Cliente.AlmacenID = Almacen.AlmacenID ");
            sConsulta.AppendLine(pvCondicion);
            sConsulta.AppendLine("ORDER BY Cliente.Clave ");
            QueryString = sConsulta.ToString();

            List<PuntosPorClienteModel> ctes = Connection.Query<PuntosPorClienteModel>(QueryString, null, null, true, 600).ToList();

            if (ctes.Count() <= 0)
            {
                return null;
            }

            var lista = (from c in ctes
                         select c).ToList();

            ReportePuntosPorCliente report = new ReportePuntosPorCliente();
            report.DataSource = lista;

            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;


            report.lblCedi.Text = CEDI;
            report.lblClientes.Text = Clientes;

            report.Clave.DataBindings.Add("Text", null, "Clave");
            report.RazonSocial.DataBindings.Add("Text", null, "RazonSocial");
            //report.NombreCorto.DataBindings.Add("Text", null, "NombreCorto");
            report.Otorgados.DataBindings.Add("Text", null, "Otorgados");
            report.Canjeados.DataBindings.Add("Text", null, "Canjeados");
            report.Disponibles.DataBindings.Add("Text", null, "Disponibles");

            report.TotalOtorgados.Text = lista.Sum(x => x.Otorgados).ToString();
            report.TotalCanjeados.Text = lista.Sum(x => x.Canjeados).ToString();
            report.TotalDisponibles.Text = lista.Sum(x => x.Disponibles).ToString();

            return report;
        }

    }

    class PuntosPorClienteModel
    {
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string NombreCorto { get; set; }
        public float Otorgados { get; set; }
        public float Canjeados { get; set; }
        public float Disponibles { get; set; }
    }
}