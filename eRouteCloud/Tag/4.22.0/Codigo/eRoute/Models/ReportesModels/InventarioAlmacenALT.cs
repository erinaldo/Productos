using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using System.IO;
using System.Drawing;
using DevExpress.XtraReports.Parameters;

namespace eRoute.Models.ReportesModels
{
    public class InventarioAlmacenALT
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string fecha, string nombreReport, string pvCondicion, string Cedi)
        {
            try
            {


                DateTime dFechaIni = DateTime.Parse(fecha);
                String filtro = dFechaIni.ToString("yyyyMMdd");

               
                StringBuilder sConsulta = new StringBuilder();
                /*
               sConsulta.Append("select top(1) DiaClave as Fecha, Folio as Vendedor from TransProd");



               QueryString = "";

               QueryString = sConsulta.ToString();


               List<ReportHeader> ReportHeaderList = Connection.Query<ReportHeader>(QueryString, null, null, true, 600).ToList();


               var lista = (from c in ReportHeaderList
                            select c).ToList();
                            */

                /*DATASOURCE**/

                List<ReportHeader> headerList = new List<ReportHeader>();


                headerList.Add(new ReportHeader
                {
                    Fecha = dFechaIni
                });

               sConsulta = new StringBuilder();


                sConsulta.Append("SELECT ");
                sConsulta.Append("Linea, CODIGO, Producto, ");
                sConsulta.Append("isnull(TEPATITLAN, 0) as TEPATITLAN, ");

                sConsulta.Append("isnull(YAHUALICA, 0) as YAHUALICA, ");
                sConsulta.Append("isnull(ARANDAS, 0) AS ARANDAS, ");
                sConsulta.Append(" isnull(ATOTONILCO,0) as ATOTONILCO, ");
                sConsulta.Append("isnull(TEPATITLAN, 0) + isnull(YAHUALICA, 0) + isnull(ARANDAS, 0) + isnull(ATOTONILCO, 0) AS TOTAL ");
                sConsulta.Append("FROM( ");
                sConsulta.Append("Select lin.Nombre as Linea, PRO.ProductoClave as CODIGO, PRO.Nombre as Producto, 'TEPATITLAN' as Nombre, i.Cantidad ");

                sConsulta.Append("from ProductoEsquema PRE (NOLOCK) ");
                sConsulta.Append("inner join Producto PRO (NOLOCK) on PRO.ProductoClave = PRE.ProductoClave ");
                sConsulta.Append("inner join RouteADM.dbo.InventarioFisico i (NOLOCK) on i.IdProducto = pro.ProductoClave and i.Status = 'A'and pro.Contenido = 0 and i.Fecha = '" + filtro+"' ");
                sConsulta.Append("inner join Esquema LIN on LIN.EsquemaID in (Select Ids from dbo.BuscaIdsEsquema(PRE.EsquemaID)) and LIN.Clasificacion in(9,10,11) ");
                sConsulta.Append("UNION ALL ");
                sConsulta.Append("Select lin.Nombre as Linea,PRO.ProductoClave as CODIGO,PRO.Nombre as Producto,'YAHUALICA' as Nombre,i.Cantidad ");
                sConsulta.Append("from[25.10.132.165\\SQL2012].RouteYahualica.dbo.ProductoEsquema PRE (NOLOCK) ");
                sConsulta.Append("inner join[25.10.132.165\\SQL2012].RouteYahualica.dbo.Producto PRO (NOLOCK) on PRO.ProductoClave = PRE.ProductoClave ");
                sConsulta.Append(" inner join[25.10.132.165\\SQL2012].RouteADM.dbo.InventarioFisico i (NOLOCK) on i.IdProducto = pro.ProductoClave and i.Status = 'A'and pro.Contenido = 0 and i.Fecha = '" + filtro+"' ");
                sConsulta.Append("inner join[25.10.132.165\\SQL2012].RouteYahualica.dbo.Esquema LIN on LIN.EsquemaID in (Select Ids from dbo.BuscaIdsEsquema(PRE.EsquemaID)) and LIN.Clasificacion in(9,10,11) ");
                sConsulta.Append("UNION ALL ");

                //Atotonilco
                sConsulta.Append("Select lin.Nombre as Linea,PRO.ProductoClave as CODIGO,PRO.Nombre as Producto,'ATOTONILCO' as Nombre,i.Cantidad ");
                sConsulta.Append("from[25.12.140.215\\SQL2012].RouteAtotonilco.dbo.ProductoEsquema PRE (NOLOCK) ");
                sConsulta.Append("inner join[25.12.140.215\\SQL2012].RouteAtotonilco.dbo.Producto PRO (NOLOCK) on PRO.ProductoClave = PRE.ProductoClave ");
                sConsulta.Append("inner join[25.12.140.215\\SQL2012].RouteADM.dbo.InventarioFisico i (NOLOCK) on i.IdProducto = pro.ProductoClave and i.Status = 'A'and pro.Contenido = 0 and i.Fecha = '" + filtro+"' ");
                sConsulta.Append("inner join[25.12.140.215\\SQL2012].RouteAtotonilco.dbo.Esquema LIN (NOLOCK) on LIN.EsquemaID in (Select Ids from dbo.BuscaIdsEsquema(PRE.EsquemaID)) and LIN.Clasificacion in(9,10,11) ");

                sConsulta.Append("UNION ALL ");

                //--Arandas
                sConsulta.Append("Select lin.Nombre as Linea,PRO.ProductoClave as CODIGO,PRO.Nombre as Producto,'ARANDAS' as Nombre,i.Cantidad ");
                sConsulta.Append("from[25.12.2.1\\SQL2012].RouteArandas.dbo.ProductoEsquema PRE (NOLOCK) ");
                sConsulta.Append("inner join[25.12.2.1\\SQL2012].RouteArandas.dbo.Producto PRO (NOLOCK) on PRO.ProductoClave = PRE.ProductoClave ");
                sConsulta.Append("inner join[25.12.2.1\\SQL2012].RouteADM.dbo.InventarioFisico i (NOLOCK) on i.IdProducto = pro.ProductoClave and i.Status = 'A'and pro.Contenido = 0 and i.Fecha = '" + filtro+"' ");
                sConsulta.Append("inner join[25.12.2.1\\SQL2012].RouteArandas.dbo.Esquema LIN (NOLOCK) on LIN.EsquemaID in (Select Ids from dbo.BuscaIdsEsquema(PRE.EsquemaID)) and LIN.Clasificacion in(9,10,11) ");
                sConsulta.Append(" ) pvt ");
                sConsulta.Append("PIVOT ");
                sConsulta.Append("( ");
                sConsulta.Append("sum(Cantidad) FOR Nombre IN([TEPATITLAN],[YAHUALICA],[ARANDAS],[ATOTONILCO]) ");
                sConsulta.Append(") AS PivotTable; ");


                sConsulta.Append("select top(200)  Nombre as Cerveza, p.ProductoClave as Codigo, case pd.PRUTipoUnidad");
                sConsulta.Append(" when 2 then 'MEDIANA' when 3 then 'MEGAS' when 5 then 'CUARTOS' END AS Envase, TipoFase as Tepatitlan, CantidadProduccion as Yahualica,");
                sConsulta.Append("DecimalProducto as Arandas, ISNULL(DecimalProducto, 0) as Atotonilco, TipoAdquisicion as Total from Producto p (NOLOCK) ");
                sConsulta.Append("inner join ProductoDetalle pd (NOLOCK) on P.ProductoClave = pd.ProductoClave");


                QueryString = "";
                QueryString = sConsulta.ToString();
          

                List<ReporteGeneralALT> DataSourceList = Connection.Query<ReporteGeneralALT>(QueryString, null, null, true, 600).ToList();

                if(DataSourceList.Count == 0)
                {
                    return null;
                }

                List<TotalReporte> totalesList = new List<TotalReporte>();


                var datasourceList = (from c in DataSourceList
                             select c).ToList();

                var s = (from gr in datasourceList group gr by new { gr.Linea } into grupo select grupo);

                List<ReporteGeneralALT> listaCompleta = new List<ReporteGeneralALT>();


                foreach (var grupo in s)
                {
                    foreach(var g in grupo)
                    {
                        listaCompleta.Add(new ReporteGeneralALT
                        {
                            Linea = g.Linea,
                            Producto = g.Producto,
                            Codigo = g.Codigo,
                            Tepatitlan = g.Tepatitlan,
                            Yahualica = g.Yahualica,
                            Arandas = g.Arandas,
                            Atotonilco = g.Atotonilco,
                            Total = g.Total
                        });
                    }
                }

                totalesList.Add(new TotalReporte
                {
                    ArandasTotal = datasourceList.Sum(x => x.Arandas),
                    TepatitlanTotal = datasourceList.Sum(x => x.Tepatitlan),
                    YahualicaTotal = datasourceList.Sum(x => x.Yahualica),
                    AtotonilcoTotal = datasourceList.Sum(x => x.Atotonilco),
                    TotalReporteSuma = datasourceList.Sum(x => x.Total)
                });




            ReporteInventarioAlmacenALT reporteGeneral = new ReporteInventarioAlmacenALT();


                reporteGeneral.DataSource = listaCompleta;

                /*imagen*/
                string LogoQuery = "Select Logotipo from Configuracion (NOLOCK) ";


                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                reporteGeneral.xrPictureBox1.Image = Image.FromStream(mStream);
                reporteGeneral.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;


                //data source general
                reporteGeneral.cervezaData.DataBindings.Add("Text", listaCompleta, "Producto");
                reporteGeneral.codigoData.DataBindings.Add("Text", listaCompleta, "Codigo");
                reporteGeneral.tepaData.DataBindings.Add("Text", listaCompleta, "Tepatitlan");
                reporteGeneral.yahualicaData.DataBindings.Add("Text", listaCompleta, "Yahualica");

                reporteGeneral.arandasData.DataBindings.Add("Text", listaCompleta, "Arandas");
                reporteGeneral.atotonilcoData.DataBindings.Add("Text", listaCompleta, "Atotonilco");
                reporteGeneral.totalData.DataBindings.Add("Text", listaCompleta, "Total");
                
                /*HEADER**/
                reporteGeneral.headerFecha.DataBindings.Add("Text", headerList, "Fecha", "{0:dd/MM/yyyy}");

                /*GROUP HEADER 1**/
                //groupheader1
                GroupField groupCliente = new GroupField("Linea");
                reporteGeneral.GroupHeader1.GroupFields.Add(groupCliente);
                reporteGeneral.envaseGroup.DataBindings.Add("Text", listaCompleta, "Linea");

                /*TOTALES**/
                reporteGeneral.aranTotal.DataBindings.Add("Text", totalesList, "ArandasTotal", "{0:$#.00}");
                reporteGeneral.atotoTotal.DataBindings.Add("Text", totalesList, "AtotonilcoTotal", "{0:$#.00}");
                reporteGeneral.tepaTotal.DataBindings.Add("Text", totalesList, "TepatitlanTotal", "{0:$#.00}");
                reporteGeneral.yahuaTotal.DataBindings.Add("Text", totalesList, "YahualicaTotal", "{0:$#.00}");
                reporteGeneral.totalTotal.DataBindings.Add("Text", totalesList, "TotalReporteSuma", "{0:$#.00}");


                return reporteGeneral;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }

    /*CLASES AUXILIARES**/

    class ReportHeader
    {
        public DateTime Fecha { get; set; }
        public string Vendedor { get; set; }

    }

    class ReporteGeneralALT
    {
        public string Linea { get; set; }
        public string Producto { get; set; }
        public string Codigo { get; set; }
        public long Tepatitlan { get; set; }
        public long Yahualica { get; set; }
        public long Arandas { get; set; }
        public long Atotonilco { get; set; }
        public long Total { get; set; }

    }
    class TotalReporte
    {
        public long TepatitlanTotal { get; set; }
        public long YahualicaTotal { get; set; }
        public long ArandasTotal { get; set; }
        public long AtotonilcoTotal { get; set; }
        public long TotalReporteSuma { get; set; }
    }



}