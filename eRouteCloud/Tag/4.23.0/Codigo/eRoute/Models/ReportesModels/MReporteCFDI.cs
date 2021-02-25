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
    public class MReporteCFDI
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string FechaInicial, string  FechaFinal, string nombreCedis, string Presupuesto, string Promocion)
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

                //VendedorJornada
                if (Promocion != "True")
                {
                    StringBuilder sConsulta = new StringBuilder();
                    sConsulta.AppendLine("Select ");
                    sConsulta.AppendLine("cli.clave as Cliente,");
                    sConsulta.AppendLine(" cli.RazonSocial as Nombre, ");
                    sConsulta.AppendLine("case ");
                    sConsulta.AppendLine(" when '" + Promocion + "' = 'true' then 'FAC' ");
                    sConsulta.AppendLine(" when '" + Promocion + "'= 'false' then 'NCD'");
                    sConsulta.AppendLine("end as TipoDocumento,");
                    sConsulta.AppendLine("tf.Serie as Serie,");
                    sConsulta.AppendLine("right(tp.folio,len(tp.folio)-len(tf.Serie)) as Folio,");
                    sConsulta.AppendLine("tp.FechaCaptura as FechaCaptura,");
                    sConsulta.AppendLine("tp.Subtotal as Sub,");
                    sConsulta.AppendLine("tp.Impuesto as IVA,");
                    sConsulta.AppendLine("tp.Total as Total,");
                    sConsulta.AppendLine("case ");
                    sConsulta.AppendLine(" when tp.TipoFase=1 then 'Vigente' ");
                    sConsulta.AppendLine(" when tp.TipoFase=0 then 'Cancelado'");
                    sConsulta.AppendLine("end as Estatus");
                    sConsulta.AppendLine("from TransProd tp (NOLOCK) ");
                    sConsulta.AppendLine("inner join Visita vi (NOLOCK) on  vi.VisitaClave = tp.VisitaClave");
                    sConsulta.AppendLine("inner join Dia di (NOLOCK) on di.DiaClave = vi.DiaClave");
                    sConsulta.AppendLine("inner join Cliente cli (NOLOCK) on  cli.ClienteClave = vi.ClienteClave");
                    sConsulta.AppendLine("inner join trpdatofiscal tf (NOLOCK) on tf.TransProdID = tp.TransProdID");
                    sConsulta.AppendLine("where tp.Tipo= 10 and tp.TipoFase in (" + Presupuesto + ")  " + pvCondicion + " order by tp.TipoFase desc");

                    QueryString = "";

                    QueryString = sConsulta.ToString();


                    List<ReCFDI> cfdi = Connection.Query<ReCFDI>(QueryString, null, null, true, 600).ToList();
                    if (cfdi.Count != 0)
                    {
                        ReporteCFDInota report = new ReporteCFDInota();

                        string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                        byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                        MemoryStream mStream = new MemoryStream(byteArrayIn);
                        report.logo.Image = Image.FromStream(mStream);
                        report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                        report.empresa.Text = NombreEmpresa;
                        report.reporte.Text = NombreReporte;

                        report.tipo.Text = "Nota de Crédito";

                        report.periodo.Text = fInicio.Date.ToShortDateString() + FechaFinal;

                        if (Presupuesto == "0")
                        {
                            report.estatus.Text = "Cancelados";

                        }
                        if (Presupuesto == "1")
                        {
                            report.estatus.Text = "Vigentes";

                        }
                        if (Presupuesto == "0,1")
                        {
                            report.estatus.Text = "Todos";

                        }

                        report.DataSource = cfdi;
                        report.z1.DataBindings.Add("Text", null, "Cliente");
                        report.z2.DataBindings.Add("Text", null, "Nombre");
                        report.z3.DataBindings.Add("Text", null, "TipoDocumento");
                        report.z4.DataBindings.Add("Text", null, "Serie");
                        report.z5.DataBindings.Add("Text", null, "Folio");
                        report.z6.DataBindings.Add("Text", null, "FechaCaptura", "{0:dd/MM/yyyy}");
                        report.z7.DataBindings.Add("Text", null, "Sub", "{0:$#,##0.00}");
                        report.z8.DataBindings.Add("Text", null, "IVA", "{0:$#,##0.00}");
                        report.z9.DataBindings.Add("Text", null, "Total", "{0:$#,##0.00}");
                        report.z10.DataBindings.Add("Text", null, "Estatus");

                        return report;
                    }
                    else
                    {
                        return null;
                    }
                }
                else {
                    StringBuilder sConsulta = new StringBuilder();
                    sConsulta.AppendLine("Select cl.clave as Cliente, cl.RazonSocial as Nombre, 'FAC' as TipoDocumento, fiscal.Serie,");
                    sConsulta.AppendLine(" right(tp.folio,len(tp.folio)-len(fiscal.Serie)) as Folio,tp.FechaCaptura,");
                    sConsulta.AppendLine(" case when tp.tipofase = 0 then '0.00' else round((");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" select sum(tpd.Precio * tpd.Cantidad)");
                    sConsulta.AppendLine(" from  Transprod TV (NOLOCK) ");
                    sConsulta.AppendLine("         inner join Transproddetalle tpd (NOLOCK) on TV.Transprodid = tpd.Transprodid and tp.Transprodid = TV.Facturaid");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" ),4) end as  Importe,");
                    sConsulta.AppendLine(" case when tp.TipoFase = 0 then '0.00' else (");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" select isnull(sum(isnull( tpd.DescuentoImp,0))+ sum(isnull(tdes.DesImporte,0))+sum(isnull(tven.DesImporte,0)),0)");
                    sConsulta.AppendLine(" from  Transprod TV (NOLOCK) ");
                    sConsulta.AppendLine("         inner join Transproddetalle tpd (NOLOCK) on TV.Transprodid = tpd.Transprodid and tp.Transprodid = TV.Facturaid");
                    sConsulta.AppendLine("  left join TpdDes tdes (NOLOCK) on tdes.TransProdId = tpd.TransProdID and tdes.TransProdDetalleId = tpd.TransProdDetalleID");
                    sConsulta.AppendLine("  left join TPDDesVendedor  tven (NOLOCK) on tven.TransProdId = tpd.TransProdID and  tven.TransProdDetalleId = tpd.TransProdDetalleId");
                    sConsulta.AppendLine("");
                    sConsulta.AppendLine(" ) end as Descuento,");
                    sConsulta.AppendLine(" case when tp.TipoFase=0 then '0.00' else  (");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" select ( (sum(tpd.Precio * tpd.Cantidad)) - (isnull(sum(isnull( tpd.DescuentoImp,0))+ sum(isnull(tdes.DesImporte,0))+sum(isnull(tven.DesImporte,0)),0)))");
                    sConsulta.AppendLine("  from  Transprod TV (NOLOCK) ");
                    sConsulta.AppendLine("         inner join Transproddetalle tpd (NOLOCK) on TV.Transprodid = tpd.Transprodid and tp.Transprodid = TV.Facturaid");
                    sConsulta.AppendLine("  left join TpdDes tdes (NOLOCK) on tdes.TransProdId = tpd.TransProdID and tdes.TransProdDetalleId = tpd.TransProdDetalleID");
                    sConsulta.AppendLine("  left join TPDDesVendedor  tven (NOLOCK) on tven.TransProdId = tpd.TransProdID and  tven.TransProdDetalleId = tpd.TransProdDetalleId");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" ) end as Sub, ");
                    sConsulta.AppendLine(" case when   tp.TipoFase<>0 then (select isnull(round(Sum(tim.ImpDesGlb),4),0 )");
                    sConsulta.AppendLine("    from  Transprod TV (NOLOCK) ");
                    sConsulta.AppendLine("         inner join Transproddetalle tpd (NOLOCK) on TV.Transprodid = tpd.Transprodid and tp.Transprodid = TV.Facturaid");
                    sConsulta.AppendLine("inner join TPDImpuesto tim (NOLOCK) on tim.TransProdID = tpd.TransProdID and tim.TransProdDetalleID = tpd.TransProdDetalleID");
                    sConsulta.AppendLine("inner join Impuesto im (NOLOCK) on im.ImpuestoClave = tim.ImpuestoClave and tim.ImpuestoClave = im.ImpuestoClave and im.Abreviatura = 'IEPS'");
                    sConsulta.AppendLine("  ");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" ) else  '0.00'  end as IEPS,");
                    sConsulta.AppendLine("  case when  tp.TipoFase<>0 then (select isnull(round(Sum(tim.ImpDesGlb),4),0 )");
                    sConsulta.AppendLine("    from  Transprod TV (NOLOCK) ");
                    sConsulta.AppendLine("         inner join Transproddetalle tpd (NOLOCK) on TV.Transprodid = tpd.Transprodid and tp.Transprodid = TV.Facturaid");
                    sConsulta.AppendLine("inner join TPDImpuesto tim (NOLOCK) on tim.TransProdID = tpd.TransProdID and tim.TransProdDetalleID = tpd.TransProdDetalleID");
                    sConsulta.AppendLine("inner join Impuesto im (NOLOCK) on im.ImpuestoClave = tim.ImpuestoClave and tim.ImpuestoClave = im.ImpuestoClave and im.Abreviatura = 'IVA'");
                    sConsulta.AppendLine(" ");
                    sConsulta.AppendLine(" )  else  '0.00' end as IVA,");
                    sConsulta.AppendLine(" case when tp.TipoFase <> 0 then round(tp.Total,4) end as Total,");
                    sConsulta.AppendLine(" case when tp.TipoFase = 0 then 'Cancelado' else 'Vigente' end as Estatus");
                    sConsulta.AppendLine(" from  TransProd tp (NOLOCK) ");
                    sConsulta.AppendLine("inner join Visita visi (NOLOCK) on visi.VisitaClave = tp.VisitaClave");
                    sConsulta.AppendLine("and tp.TipoFase in (" + Presupuesto + ")  and tp.Tipo= 8");
                    sConsulta.AppendLine("inner join Dia di (NOLOCK) on di.DiaClave = visi.DiaClave   " + pvCondicion + " ");
                    sConsulta.AppendLine("inner join Cliente cl (NOLOCK) on cl.ClienteClave = visi.ClienteClave");
                    sConsulta.AppendLine("inner join TRPDatoFiscal fiscal (NOLOCK) on fiscal.TransProdID = tp.TransProdID");
                    sConsulta.AppendLine("order by cl.Clave, tp.Folio asc");
                    QueryString = sConsulta.ToString();

                    List<ReCFDI> cfdi = Connection.Query<ReCFDI>(QueryString, null, null, true, 600).ToList();
                    if (cfdi.Count != 0)
                    {
                        PrincipalReporteCFDI  report = new PrincipalReporteCFDI();

                        string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                        byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                        MemoryStream mStream = new MemoryStream(byteArrayIn);
                        report.logo.Image = Image.FromStream(mStream);
                        report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                        report.empresa.Text = NombreEmpresa;
                        report.reporte.Text = NombreReporte;

                        report.tipo.Text = "Factura";

                        report.periodo.Text = fInicio.Date.ToShortDateString() + FechaFinal;

                        if (Presupuesto == "0")
                        {
                            report.estatus.Text = "Cancelados";

                        }
                        if (Presupuesto == "1")
                        {
                            report.estatus.Text = "Vigentes";

                        }
                        if (Presupuesto == "0,1")
                        {
                            report.estatus.Text = "Todos";

                        }

                        report.DataSource = cfdi;
                        report.x1.DataBindings.Add("Text", null, "Cliente");
                        report.x2.DataBindings.Add("Text", null, "Nombre");
                        report.x3.DataBindings.Add("Text", null, "TipoDocumento");
                        report.x4.DataBindings.Add("Text", null, "Serie");
                        report.x5.DataBindings.Add("Text", null, "Folio");
                        report.x6.DataBindings.Add("Text", null, "FechaCaptura", "{0:dd/MM/yyyy}");
                        report.x7.DataBindings.Add("Text", null, "Importe", "{0:$#,##0.0000}");
                        report.x8.DataBindings.Add("Text", null, "Descuento", "{0:$#,##0.0000}");
                        report.x9.DataBindings.Add("Text", null, "Sub", "{0:$#,##0.0000}");
                        report.x10.DataBindings.Add("Text", null, "IEPS", "{0:$#,##0.0000}");
                        report.x11.DataBindings.Add("Text", null, "IVA", "{0:$#,##0.0000}");
                        report.x12.DataBindings.Add("Text", null, "Total", "{0:$#,##0.0000}");
                        report.x13.DataBindings.Add("Text", null, "Estatus");

                        return report;
                    }
                    else {
                        return null;
                    }

                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
    
     class ReCFDI
    {
       
        public String Cliente { get; set; }
        public String Nombre { get; set; }
        public String TipoDocumento { get; set; }
        public String Serie { get; set; }
        public String Folio { get; set; }
        public DateTime FechaCaptura { get; set; }
        public Decimal Importe { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal Sub { get; set; }
        public Decimal IVA { get; set; }
        public Decimal IEPS { get; set; }
        public Decimal Total { get; set; }
        public String Estatus { get; set; }
    }   
}