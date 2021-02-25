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
    public class MReporteCFDI
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string RutasSplit, string FechaInicial, string FechaFinal, string nombreCedis, string Presupuesto, string Promocion)
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
                sConsulta.AppendLine("inner join Dia (NOLOCK) on Dia.DiaClave = vi.DiaClave");
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
            else
            {
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("if (select object_id('tempdb..#ImpNoDes')) is not null drop table #ImpNoDes ");
                sConsulta.AppendLine("select * into #ImpNoDes from ( ");
                sConsulta.AppendLine("    select TDI.TransProdID, TDI.TransProdDetalleID, SUM(round(TDI.ImpuestoPU,5)) as ImpuestoPU, SUM(TDI.ImpDesGlb) as ImpDesGlb ");
                sConsulta.AppendLine("    from TransProd trp (NOLOCK) ");
                sConsulta.AppendLine("    inner join Visita vis (NOLOCK) on trp.VisitaClave = vis.VisitaClave ");
                sConsulta.AppendLine("    inner join Dia (NOLOCK) on vis.DiaClave = Dia.DiaClave " + pvCondicion + " ");
                //sConsulta.AppendLine("    inner join TransProd vta (NOLOCK) on trp.TransProdID = vta.FacturaID ");
                sConsulta.AppendLine("    LEFT join TransProd vta (NOLOCK) on trp.TransProdID = vta.FacturaID ");
                //sConsulta.AppendLine("    inner join TPDImpuesto tdi (NOLOCK) on vta.TransProdID = tdi.TransProdID ");
                sConsulta.AppendLine("    LEFT join TPDImpuesto tdi (NOLOCK) on vta.TransProdID = tdi.TransProdID ");
                sConsulta.AppendLine("    where trp.Tipo = 8 and trp.TipoFase in (" + Presupuesto + ") ");
                sConsulta.AppendLine("    and vta.Tipo = 1 and TDI.ImpuestoClave in ( ");
                sConsulta.AppendLine("        select ImpuestoClave ");
                sConsulta.AppendLine("        from CLINoDesImp (NOLOCK) ");
                sConsulta.AppendLine("        where ClienteClave = vis.ClienteClave and trp.FechaHoraAlta between FechaInicio and FechaFin) ");
                sConsulta.AppendLine("    group by TDI.TransProdID, TDI.TransProdDetalleID ");
                sConsulta.AppendLine(") as t ");

                sConsulta.AppendLine("if (select object_id('tempdb..#TmpCFID')) is not null drop table #TmpCFID ");
                sConsulta.AppendLine("select * into #TmpCFID from ( ");
                sConsulta.AppendLine("    select trp.TransProdId, vis.ClienteClave, trp.Folio, trp.FechaCaptura, trp.TipoFase, trp.Total, isnull(tpd.Promocion, 0) as Regalo, tpd.Cantidad, case when isnull(tpd.Promocion, 0) = 2 then ");
                sConsulta.AppendLine("        isnull(dbo.FNObtenerPrecio(vta.PCEPrecioClave, tpd.ProductoClave, tpd.TipoUnidad, tpd.MFechaHora), 1) + ");
                sConsulta.AppendLine("        isnull(dbo.FNCalcularImpuestoNoDesglosado(tpd.ProductoClave, vis.ClienteClave, tpd.MFechaHora, isnull(dbo.FNObtenerPrecio(vta.PCEPrecioClave, tpd.ProductoClave, tpd.TipoUnidad, tpd.MFechaHora), 1)), 0) ");
                sConsulta.AppendLine("        else TPD.Precio + isnull(ind.ImpuestoPU, 0) end as Precio, ");
                sConsulta.AppendLine("    (TPD.DescuentoImp + CASE WHEN isnull(((TPD.Cantidad * IND.ImpuestoPU) - IND.ImpDesGlb), 0) <0 THEN 0 ELSE isnull(((TPD.Cantidad * IND.ImpuestoPU) - IND.ImpDesGlb), 0) END) as DescuentoImp, ");
                sConsulta.AppendLine("    isnull((select sum(DesImporte) from TpdDes TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoCliente, ");
                sConsulta.AppendLine("    isnull((select sum(DesImporte) from TPDDesVendedor TDD where TPD.TransProdId = TDD.TransProdId and TPD.TransProdDetalleId = TDD.TransProdDetalleId),0) as DescuentoVendedor ");
                sConsulta.AppendLine("    from TransProd trp (NOLOCK) ");
                sConsulta.AppendLine("    inner join Visita vis (NOLOCK) on trp.VisitaClave = vis.VisitaClave ");
                sConsulta.AppendLine("    inner join Dia (NOLOCK) on vis.DiaClave = Dia.DiaClave " + pvCondicion + " ");
                sConsulta.AppendLine("    inner join TRPDatoFiscal (NOLOCK) tdf on trp.TransProdID = tdf.TransProdID ");
                //sConsulta.AppendLine("    inner join TransProd vta (NOLOCK) on trp.TransProdID = vta.FacturaID ");
                sConsulta.AppendLine("    LEFT join TransProd vta (NOLOCK) on trp.TransProdID = vta.FacturaID ");
                //sConsulta.AppendLine("    inner join TransProdDetalle tpd (NOLOCK) on vta.TransProdID = tpd.TransProdID ");
                sConsulta.AppendLine("    LEFT join TransProdDetalle tpd (NOLOCK) on vta.TransProdID = tpd.TransProdID ");
                sConsulta.AppendLine("    left join #ImpNoDes as ind on tpd.TransProdID = ind.TransProdID and tpd.TransProdDetalleID = ind.TransProdDetalleID ");
                sConsulta.AppendLine("    where trp.Tipo = 8 and trp.TipoFase in (" + Presupuesto + ") ");
                sConsulta.AppendLine(") as t ");

                sConsulta.AppendLine("select tmp.Clave as Cliente, tmp.Nombre, 'FAC' as TipoDocumento, tmp.Serie, tmp.Folio, tmp.FechaCaptura, ISNULL(tmp.Importe, 0) AS Importe, tmp.Descuento, ");
                sConsulta.AppendLine("ISNULL(tmp.Importe - tmp.Descuento, 0) as Sub, ");
                sConsulta.AppendLine("case when tmp.TipoFase = 0 then '0.00' else round(isnull(sum(case when imp.Abreviatura = 'IEPS' then tdi.ImpDesGlb else 0 end), 0), 4) end as IEPS, ");
                sConsulta.AppendLine("case when tmp.TipoFase = 0 then '0.00' else round(isnull(sum(case when imp.Abreviatura = 'IVA' then tdi.ImpDesGlb else 0 end), 0), 4) end as IVA, ");
                sConsulta.AppendLine("case when tmp.TipoFase = 0 then '0.00' else round(tmp.Total, 4) end as Total, ");
                //sConsulta.AppendLine("case when tmp.TipoFase = 0 then 'Cancelado' else 'Vigente' end as Estatus ");
                sConsulta.AppendLine("CASE WHEN tmp.TipoFase = 0 THEN 'Cancelado' WHEN tmp.TipoFase = 1 AND MIN(ven.TransProdID) IS NULL THEN 'Inconsistente' else 'Vigente' end as Estatus ");
                sConsulta.AppendLine("from ( ");
                sConsulta.AppendLine("select fac.TransProdID, cli.ClienteClave, fac.TipoFase, cli.Clave, cli.RazonSocial as Nombre, tdf.Serie, right(fac.Folio, len(fac.Folio)-len(tdf.Serie)) as Folio, fac.FechaCaptura, fac.Total, ");
                sConsulta.AppendLine("case when fac.TipoFase = 0 then '0.00' else round(sum(fac.Cantidad * fac.Precio), 4) end as Importe, ");
                sConsulta.AppendLine("case when fac.TipoFase = 0 then '0.00' else round(sum(isnull(DescuentoImp, 0) + DescuentoCliente + DescuentoVendedor + (case when fac.Regalo = 2 then fac.Cantidad * fac.Precio else 0 end)), 4) end as Descuento ");
                sConsulta.AppendLine("from #TmpCFID fac ");
                sConsulta.AppendLine("inner join Cliente cli (NOLOCK) on fac.ClienteClave = cli.ClienteClave ");
                sConsulta.AppendLine("inner join TRPDatoFiscal tdf (NOLOCK) on fac.TransProdID = tdf.TransProdID ");
                sConsulta.AppendLine("group by fac.TransProdID, cli.ClienteClave, cli.Clave, cli.RazonSocial, tdf.Serie, fac.Folio, fac.FechaCaptura, fac.TipoFase, fac.Total ");
                sConsulta.AppendLine(") as tmp ");
                //sConsulta.AppendLine("inner join TransProd ven (NOLOCK) on tmp.TransProdID = ven.FacturaID ");
                sConsulta.AppendLine("LEFT join TransProd ven (NOLOCK) on tmp.TransProdID = ven.FacturaID ");
                sConsulta.AppendLine("left join TPDImpuesto tdi (NOLOCK) on ven.TransProdID = tdi.TransProdID ");
                sConsulta.AppendLine("and tdi.ImpuestoClave not in ( ");
                sConsulta.AppendLine("    select ImpuestoClave ");
                sConsulta.AppendLine("    from CLINoDesImp (NOLOCK) ");
                sConsulta.AppendLine("    where ClienteClave = tmp.ClienteClave and tmp.FechaCaptura between FechaInicio and FechaFin) ");
                sConsulta.AppendLine("left join Impuesto imp (NOLOCK) on tdi.ImpuestoClave = imp.ImpuestoClave ");
                sConsulta.AppendLine("group by tmp.Clave, tmp.Nombre, tmp.Serie, tmp.Folio, tmp.FechaCaptura, tmp.Importe, tmp.Descuento, tmp.Total, tmp.TipoFase ");
                sConsulta.AppendLine("order by tmp.Clave, tmp.Folio ");

                QueryString = sConsulta.ToString();

                List<ReCFDI> cfdi = Connection.Query<ReCFDI>(QueryString, null, null, true, 600).ToList();
                if (cfdi.Count != 0)
                {
                    PrincipalReporteCFDI report = new PrincipalReporteCFDI();

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
                else
                {
                    return null;
                }

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