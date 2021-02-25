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

namespace eRoute.Models.ReportesModels
{
    public class NecesidadesDeCargaUNI
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string RutasSplit, string ClientesSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis)
        {
            try
            {

               
              
                StringBuilder sConsulta = new StringBuilder();


                sConsulta.AppendLine("SELECT");

                sConsulta.AppendLine("ProductoClave as SKU,");

                sConsulta.AppendLine("NombreLargo as Producto,");

                sConsulta.AppendLine("Descripcion as Unidad_de_Medida,");

                sConsulta.AppendLine("isnull(Venta,0) as Venta,");

                sConsulta.AppendLine("isnull(Cambios,0) as Cambios,");

                sConsulta.AppendLine("isnull([Promociones],0) as Promociones,");

                sConsulta.AppendLine("isnull(Venta,0)+isnull(Cambios,0)+isnull([Promociones],0) as Total_Unidades_para_Cargar,");

                sConsulta.AppendLine("isnull(Importe,0) as Importe_Venta");

                sConsulta.AppendLine("FROM (");     
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);
                //sConsulta.AppendLine("where 1 = 1 and d.FechaCaptura between '2018-01-15T00:00:00' and '2018-01-15T23:00:00' and vi.RUTClave in ('AAp1508')");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo = 3 and tp.TipoFase=1");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave  and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID   and tp.TipoMovimiento= 1 and tp.Tipo = 9 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave  and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tpd.Promocion = 2 and tpd.Total = 0  and tp.Tipo = 1 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine(pvCondicion);

                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Venta' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave = tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave");
                sConsulta.AppendLine(pvCondicion1);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID  and tp.Tipo = 3 and tp.TipoFase=1");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave  and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave");
                sConsulta.AppendLine(pvCondicion1);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Cambios' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID   and tp.TipoMovimiento= 1 and tp.Tipo = 9 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave  and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave");
                sConsulta.AppendLine(pvCondicion1);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Promociones' as Nombre, tpd.Cantidad as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tpd.Promocion = 2 and tpd.Total = 0  and tp.Tipo = 1 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave");
                sConsulta.AppendLine(pvCondicion1);
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("select p.ProductoClave,p.NombreLargo,vd.Descripcion, 'Importe' as Nombre, tpd.Total as Total");
                sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle tpd (NOLOCK) on tp.TransProdID = tpd.TransProdID and tp.Tipo = 1 and tp.TipoFase<>0");
                sConsulta.AppendLine("inner join Visita vi (NOLOCK) on vi.VisitaClave = tp.VisitaClave and vi.DiaClave=tp.DiaClave");
                sConsulta.AppendLine("inner join Dia d (NOLOCK) on d.DiaClave = vi.DiaClave");
                sConsulta.AppendLine("inner join Producto p (NOLOCK) on p.ProductoClave = tpd.ProductoClave");
                sConsulta.AppendLine("inner join ProductoUnidad pu (NOLOCK) on p.ProductoClave = pu.ProductoClave");
                sConsulta.AppendLine("inner join VAVDescripcion vd (NOLOCK) on vd.VARCodigo = 'UNIDADV' and vd.VAVClave = pu.PRUTipoUnidad and vd.VADTipoLenguaje ='EM'");
                sConsulta.AppendLine("inner join Ruta r (NOLOCK) on r.Tipo = 2 and r.RUTClave = vi.RUTClave");
                sConsulta.AppendLine("inner join TMP_RutaPreventaReparto tr (NOLOCK) on tr.RutaPreventa1= r.RUTClave or tr.RutaPreventa2=r.RUTClave");
                sConsulta.AppendLine(pvCondicion1);
                sConsulta.AppendLine(") pvt");
                sConsulta.AppendLine("PIVOT");
                sConsulta.AppendLine("(");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("sum(Total) FOR Nombre IN ([Cambios],[Venta],[Promociones],[Total_Unidades],[Importe])");
                sConsulta.AppendLine(") AS PivotTable;");



                QueryString = "";

                QueryString = sConsulta.ToString();

                List<NecesidadesModel> liquidacion = Connection.Query<NecesidadesModel>(QueryString, null, null, true, 600).ToList();

                if (liquidacion.Count() <= 0)
                {
                    return null;
                }

                //Fin
                liquidacion.LastOrDefault().TotalImporte_Venta = liquidacion.Sum(c => c.Importe_Venta);
                liquidacion.LastOrDefault().TotalVenta = liquidacion.Sum(c => c.Venta);
                liquidacion.LastOrDefault().TotalCambios = liquidacion.Sum(c => c.Cambios);
                liquidacion.LastOrDefault().TotalPromociones = liquidacion.Sum(c => c.Promociones);
                liquidacion.LastOrDefault().TTotal_Unidades_para_Cargar = liquidacion.Sum(c => c.Total_Unidades_para_Cargar);

                ReporteNecesidadesDeCarga report = new ReporteNecesidadesDeCarga();
                report.DataSource = liquidacion;
                


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

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;


                report.fecha.Text = fInicio.Date.ToShortDateString() + FechaFinal;
                
                if (RutasSplit=="") {
                    report.ruta.Text = "Todas";
                } else {
                    report.ruta.Text = RutasSplit;
                }
                    
                report.centro.Text = Cedis;
                //Preventa
               


                report.l1.DataBindings.Add("Text", null, "SKU");
                report.l2.DataBindings.Add("Text", null, "Producto");
                report.l3.DataBindings.Add("Text", null, "Unidad_de_Medida");
                report.l4.DataBindings.Add("Text", null, "Venta");
                report.l5.DataBindings.Add("Text", null, "Cambios");
                report.l6.DataBindings.Add("Text", null, "Promociones");
                report.l7.DataBindings.Add("Text", null, "Total_Unidades_para_Cargar");
                report.l8.DataBindings.Add("Text", null, "Importe_Venta", "{0:$#,##0.00}");

                report.totalv.DataBindings.Add("Text", null, "TotalVenta");
                report.totalc.DataBindings.Add("Text", null, "TotalCambios");
                report.totalp.DataBindings.Add("Text", null, "TotalPromociones");
                report.totalu.DataBindings.Add("Text", null, "TTotal_Unidades_para_Cargar");
                report.totali.DataBindings.Add("Text", null, "TotalImporte_Venta", "{0:$#,##0.00}");


                /*
                if (ClientesNoVisitados.Count>0) {
                    report.Subreport1.ReportSource = ClientesN;
                    report.totaln.Text = ClientesNoVisitados.Count.ToString();

                }else
                {
                    report.Subreport1.Visible =false;
                    report.totaln.Text = ClientesNoVisitados.Count.ToString();
                }
                
                */
                return report;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }

    class NecesidadesModel
    {
        public string SKU { get; set; }
        public string Producto { get; set; }
        public string Unidad_de_Medida { get; set; }
        public int Venta { get; set; }
        public int Cambios { get; set; }
        public int Promociones { get; set; }
        public int Total_Unidades_para_Cargar { get; set; }
        public Decimal Importe_Venta { get; set; }


        public int TotalVenta { get; set; }
        public int TotalCambios { get; set; }
        public int TotalPromociones { get; set; }
        public int TTotal_Unidades_para_Cargar { get; set; }
        public Decimal TotalImporte_Venta { get; set; }


    }


}