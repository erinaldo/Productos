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
    public class MPedidosPreventaDetallado
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        public int cont = 1;

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string pvCondicion1, string pvCondicion2, string Vendedor, string FechaInicial, string FechaFinal, string nombreCedis,string Cedi, string Presupuesto)
        {
            try
            {
                string AlmacenQuery = "select Clave from almacen (NOLOCK) where AlmacenID = '" + Cedi + "'";
                string ClaveAlmacen = Connection.Query<string>(AlmacenQuery, null, null, true, 9000).FirstOrDefault();

                //Esta validacion Iguala la FechaFinal a la Inicial en caso de que se haya solicitado una fecha unica para efectos del filtrado en la consulta,
                //mas adelante en el codigo regreso su valor al original

                Boolean FechaFinalMod = false;
                if (FechaFinal.Equals(""))
                {
                    FechaFinal += FechaInicial;
                    FechaFinalMod = true;
                }

                //Preventa

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("DECLARE @FechaMinEntrega date, @FechaCaptura date ");
                sConsulta.AppendLine("Select Top 1 @FechaCaptura = FechaCaptura from Dia (NOLOCK) where 1=1  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  ");
                sConsulta.AppendLine("set @FechaMinEntrega =  dbo.FNsumarDiasSinExcepcionFrecuencia(@FechaCaptura ) ");
                sConsulta.AppendLine("Select distinct CLI.Clave + ' - ' + CLI.RazonSocial as Cliente, VIS.ClienteClave,");
                sConsulta.AppendLine("TRP.Folio, convert(datetime,Convert(varchar(20),TRP.FechaEntrega,112)) as FechaEntrega, (select top 1 VAD.Descripcion from VAVDescripcion VAD (NOLOCK) where VAD.VARCodigo = 'TRPFASE' and VAD.VADTipoLenguaje = 'EM' and VAD.VAVClave = TRP.TipoFase ) as TipoFase, TPD.ProductoClave, PRO.Nombre,");
                sConsulta.AppendLine("CASE WHEN TPD.TipoUnidad = 2 THEN TPD.Cantidad ELSE 0 END as Cajas, ");
                sConsulta.AppendLine("CASE WHEN TPD.TipoUnidad <> 2 THEN TPD.Cantidad ELSE 0 END as OtrasUnidades,");
                sConsulta.AppendLine("CASE WHEN  convert(datetime,Convert(varchar(20),TRP.FechaEntrega,112)) > @FechaMinEntrega THEN 'POSFECHADO' ELSE 'NOPOSFECHADO' END as TipoEntrega,TRP.TipoFase as Fase ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD  (NOLOCK) ON TRP.TransProdID = TPD.TransProdID  and TRP.Tipo = 1 and TRP.TipoFase in(0, 1) ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) ON VIS.RUTClave = RUT.RUTClave  ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) ON PRO.ProductoClave = TPD.ProductoClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) ON VIS.VendedorID = VEN.VendedorID ");
                sConsulta.AppendLine("inner join VENCentroDistHist VCD (NOLOCK) ON VIS.VendedorID=VCD.vendedorid and TRP.FechaCaptura between (dateadd(dd,0, datediff(dd,0,VCHFechaInicial))) and VCD.FechaFinal ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                //sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase in(0,1) ");
                //sConsulta.AppendLine("AND VEN.VendedorID = 'R-23' ");
                //sConsulta.AppendLine("AND RUT.RutClave in('R-23')");
                //sConsulta.AppendLine("and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  and ALM.Clave = '01' ");
                sConsulta.AppendLine(pvCondicion + "and ALM.Clave = '" + ClaveAlmacen + "'");
                sConsulta.AppendLine("order by TipoEntrega, Cliente, TRP.Folio, TPD.ProductoClave ");

                //sConsulta.AppendLine(pvCondicion2);


                QueryString = "";

                QueryString = sConsulta.ToString();


                List<PreveentaPedidos> uno = Connection.Query<PreveentaPedidos>(QueryString, null, null, true, 600).ToList();

                //------
                List<PreveentaPedidos> DKg = new List<PreveentaPedidos>();
                var SubDetalladoKg = (from r in uno
                                      select r).ToList();

                var SDk_C = (from gr in SubDetalladoKg group gr by new { gr.Cliente } into grupo select grupo);
                foreach (var gCliente in SDk_C)
                        {
                            foreach (var objetoAgrupado in gCliente)
                            {
                                DKg.Add(new PreveentaPedidos
                                {

                                    Cliente = objetoAgrupado.Cliente,
                                    ClienteClave = objetoAgrupado.ClienteClave,
                                    Folio = objetoAgrupado.Folio,
                                    FechaEntrega = objetoAgrupado.FechaEntrega,
                                    TipoFase = objetoAgrupado.TipoFase,
                                    ProductoClave = objetoAgrupado.ProductoClave,
                                    Nombre = objetoAgrupado.Nombre,
                                    Cajas = objetoAgrupado.Cajas,
                                    OtrasUnidades = objetoAgrupado.OtrasUnidades
                                });
                            }
                        }
                  


                //***clientes por frecuencia
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select Count(Distinct AGV.ClienteClave) as CF ");
                sConsulta.AppendLine("from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON AGV.DiaClave = dia.DiaClave ");
                //sConsulta.AppendLine("where 1=1 ");
                //sConsulta.AppendLine(" and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  and AGV.ClaveCEDI  = '01'  AND AGV.VendedorID = 'R-23'  AND AGV.RUTClave in ('R-23')");
                sConsulta.AppendLine(pvCondicion1+ " and AGV.ClaveCEDI  = '" + ClaveAlmacen + "'");



                QueryString = "";

                QueryString = sConsulta.ToString();


                List<ClientesPorFrecuenciaPedidos> dos = Connection.Query<ClientesPorFrecuenciaPedidos>(QueryString, null, null, true, 600).ToList();


                //Clientes visitados
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("Select Count(Distinct VIS.ClienteClave) as CVIS ");
                sConsulta.AppendLine("from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON VIS.DiaClave = dia.DiaClave  ");
                //sConsulta.AppendLine("where 1=1 ");
                //sConsulta.AppendLine(" and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  AND VIS.VendedorID = 'R-23'  AND VIS.RUTClave in ('R-23')");
                sConsulta.AppendLine(pvCondicion2);


                QueryString = "";

                QueryString = sConsulta.ToString();


                List<ClientesVisitadosPedidos> tres = Connection.Query<ClientesVisitadosPedidos>(QueryString, null, null, true, 600).ToList();


                ///Indicadores
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("DECLARE @FechaMinEntrega date, @FechaCaptura date ");
                sConsulta.AppendLine("Select Top 1 @FechaCaptura = FechaCaptura from Dia (NOLOCK) where 1=1  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  ");
                sConsulta.AppendLine("set @FechaMinEntrega =  dbo.FNsumarDiasSinExcepcionFrecuencia(@FechaCaptura ) ");
                sConsulta.AppendLine("Select COUNT(Distinct PedidosEfect) as PedidosEfectivos, COUNT(DISTINCT ClientesConPedido) as ClientesConPedido, ");
                sConsulta.AppendLine("ISNULL(Sum(CajasAct),0) as CajasPedidosEfectivos, ISNULL(SUM(OtraUnidadAct),0) as OtraUnidadEfectivos,");
                sConsulta.AppendLine("COUNT(Distinct PedidosCanc) as PedidosCancelados, ISNULL(Sum(CajasCanc),0) as CajasCanceladas, ");
                sConsulta.AppendLine("COUNT(Distinct PedidosPosf) as PedidosPosfechados, ISNULL(Sum(CajasPosf),0) as CajasPosfechadas ");
                sConsulta.AppendLine("from(");
                sConsulta.AppendLine("Select CASE WHEN TipoFase = 1 THEN TRP.TransProdID ELSE null END as PedidosEfect, ");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 1 THEN VIS.ClienteClave ELSE null END as ClientesConPedido,");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 1 and TPD.TipoUnidad = 2 THEN SUM(TPD.Cantidad ) ELSE 0 END as CajasAct,");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 1 and TPD.TipoUnidad <> 2 THEN SUM(TPD.Cantidad ) ELSE 0 END as OtraUnidadAct,");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 0 THEN TRP.TransProdID ELSE null END as PedidosCanc, ");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 0 and TPD.TipoUnidad = 2 THEN SUM(TPD.Cantidad ) ELSE 0 END as CajasCanc, ");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 1 and convert(datetime,Convert(varchar(20),TRP.FechaEntrega,112)) > @FechaMinEntrega THEN TRP.TransProdID ELSE null END as PedidosPosf, ");
                sConsulta.AppendLine(" CASE WHEN TipoFase = 1 and convert(datetime,Convert(varchar(20),TRP.FechaEntrega,112)) > @FechaMinEntrega and TPD.TipoUnidad = 2 THEN SUM(TPD.Cantidad ) ELSE 0 END  as CajasPosf ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID and TRP.Tipo = 1 and TRP.TipoFase in(0, 1) ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Cliente CLI (NOLOCK) ON VIS.ClienteClave = CLI.ClienteClave ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) ON VIS.RUTClave = RUT.RUTClave  ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) ON VIS.VendedorID = VEN.VendedorID ");
                sConsulta.AppendLine("inner join VENCentroDistHist VCD (NOLOCK) ON VIS.VendedorID=VCD.vendedorid and TRP.FechaCaptura between VCD.VCHFechaInicial and VCD.FechaFinal ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId and ALM.Clave = '" + ClaveAlmacen + "' ");
                //sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase in(0,1) ");
                //sConsulta.AppendLine(" and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  and ALM.Clave = '01' ");
                //sConsulta.AppendLine(" AND VEN.VendedorID = 'R-23' AND RUT.RutClave in('R-23')");
                sConsulta.AppendLine(pvCondicion + " ");
                sConsulta.AppendLine("group by TRP.TransProdID,VIS.ClienteClave, TPD.TipoUnidad, TRP.TipoFase ,TRP.FechaEntrega ");
                sConsulta.AppendLine(" ) as tmp ");


                QueryString = "";

                QueryString = sConsulta.ToString();


                List<IndicadoresPedidos> cuatro = Connection.Query<IndicadoresPedidos>(QueryString, null, null, true, 600).ToList();



                //Sub Totales por producto
                sConsulta = new StringBuilder();
                sConsulta.AppendLine("DECLARE @FechaMinEntrega date, @FechaCaptura date ");
                sConsulta.AppendLine("Select Top 1 @FechaCaptura = FechaCaptura from Dia (NOLOCK) where 1=1  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  ");
                sConsulta.AppendLine("set @FechaMinEntrega =  dbo.FNsumarDiasSinExcepcionFrecuencia(@FechaCaptura ) ");
                sConsulta.AppendLine("Select distinct TPD.ProductoClave, PRO.Nombre,");
                sConsulta.AppendLine("(select top 1 VAD.Descripcion from VAVDescripcion VAD (NOLOCK) where VAD.VARCodigo = 'UNIDADV' and VAD.VADTipoLenguaje = 'EM' and VAD.VAVClave = TPD.TipoUnidad ) as Unidad,");
                sConsulta.AppendLine("TPD.TipoUnidad, sum(TPD.Cantidad) as TotalUnidades, sum(TPD.Total)as Importe ");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) ON TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) ON VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) ON Dia.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("inner join Ruta RUT (NOLOCK) ON VIS.RUTClave = RUT.RUTClave  ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) ON PRO.ProductoClave = TPD.ProductoClave ");
                sConsulta.AppendLine("inner join Vendedor VEN (NOLOCK) ON VIS.VendedorID = VEN.VendedorID ");
                sConsulta.AppendLine("inner join VENCentroDistHist VCD (NOLOCK) ON VIS.VendedorID=VCD.vendedorid and TRP.FechaCaptura between VCD.VCHFechaInicial and VCD.FechaFinal ");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) ON ALM.AlmacenID = VCD.AlmacenId ");
                //sConsulta.AppendLine("where TRP.Tipo = 1 and TRP.TipoFase = 1");
                //sConsulta.AppendLine(" and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) <= '2018-06-20T00:00:00'  and convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) >= '2018-06-20T00:00:00'  and ALM.Clave = '01' ");
                //sConsulta.AppendLine(" AND VEN.VendedorID = 'R-23' AND RUT.RutClave in('R-23')");
                sConsulta.AppendLine(pvCondicion + "and TRP.Tipo = 1 and TRP.TipoFase = 1 and ALM.Clave = '" + ClaveAlmacen + "'");
                sConsulta.AppendLine("group by TPD.ProductoClave, PRO.Nombre , TPD.TipoUnidad  ");
                sConsulta.AppendLine("order by  TPD.ProductoClave ");

                QueryString = "";

                QueryString = sConsulta.ToString();


                List<TotalPorProductoPedidos> cinco = Connection.Query<TotalPorProductoPedidos>(QueryString, null, null, true, 600).ToList();


                //En caso de que se haya igualado FechaFinal a FechaInicial, regreso su valor a string vacio para que no afecte funcionalidad
                if (FechaFinalMod)
                {
                    FechaFinal = "";
                }



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
                
                string VendedorQuery = "select Nombre from vendedor (NOLOCK) where VendedorID =" + Vendedor;
                string nombreVendedor = Connection.Query<string>(VendedorQuery, null, null, true, 9000).FirstOrDefault();


                PrincipalPreventaDetallado report = new PrincipalPreventaDetallado();

                string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
                byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
                MemoryStream mStream = new MemoryStream(byteArrayIn);
                report.logo.Image = Image.FromStream(mStream);
                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

                report.empresa.Text = NombreEmpresa;
                report.reporte.Text = NombreReporte;

                report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
                report.centro.Text = nombreCedis;


                report.ruta.Text = nombreVendedor;
                report.vendedor.Text = nombreVendedor;
                DateTime dt = Convert.ToDateTime(FechaInicial);
                report.fentrega.Text = dt.ToString("dd/MM/yyyy");
                //report.freporte.Text = DateTime.Now.ToString();





                if (uno.Count != 0)
                {
                    
                    //objeto Agrupado
                    PrinSubPrevetaDetallado reportPrin = new PrinSubPrevetaDetallado();
                    reportPrin.DataSource = DKg;

                    //grouheader1 SubDetallado
                    GroupField groupCliente = new GroupField("Cliente");
                    reportPrin.GroupHeader1.GroupFields.Add(groupCliente);
                    reportPrin.ClienteClave.DataBindings.Add("Text", report.DataSource, "Cliente");

                    reportPrin.folio.DataBindings.Add("Text", null, "Folio");
                    reportPrin.fechaentrega.DataBindings.Add("Text", null, "FechaEntrega", "{0:dd/MM/yyyy}");
                    reportPrin.estatus.DataBindings.Add("Text", null, "TipoFase");
                    reportPrin.sku.DataBindings.Add("Text", null, "ProductoClave");
                    reportPrin.productos.DataBindings.Add("Text", null, "Nombre");
                    reportPrin.cajas.DataBindings.Add("Text", null, "Cajas");
                    reportPrin.otras.DataBindings.Add("Text", null, "OtrasUnidades");

                    double a1   = dos.FirstOrDefault().CF;
                    double a2 = dos.FirstOrDefault().CF;
                    double a3 = cuatro.FirstOrDefault().PedidosEfectivos;
                    double a4 = cuatro.FirstOrDefault().CajasPedidosEfectivos;
                    double a5 = cuatro.FirstOrDefault().OtraUnidadEfectivos;
                    double a6 = cuatro.FirstOrDefault().PedidosCancelados;
                    double a7 = cuatro.FirstOrDefault().CajasCanceladas;
                    double a8 = cuatro.FirstOrDefault().PedidosPosfechados;
                    double a9 = cuatro.FirstOrDefault().CajasPosfechadas;



                    report.lb1.Text = a1.ToString();//Clientes Por Frecuencia
                    report.lb2.Text = a2.ToString();//Total clientes visitados
                    report.lb3.Text = String.Format("{0:#0.00}%", ((a1 / a2) * 100));//Porcentaje de Eficiencia de Visita
                    report.lb4.Text = a3.ToString();//Total de Pedidos Efectivos
                    report.lb5.Text = String.Format("{0:#0.00}%", ((a3 / a2) * 100));//Porcentaje de Eficiencia de Ventas vs Visita
                    report.lb6.Text = a4.ToString();//Total de Cajas de Preventa del día
                    report.lb7.Text = a5.ToString();//Otras Unidades de Medida
                    report.lb8.Text = a6.ToString();//Total de Pedidos Cancelados
                    report.lb9.Text = a7.ToString();//Cajas Canceladas
                    report.lb10.Text = a8.ToString();//Total de Pedidos Posfechados
                    report.lb11.Text = a9.ToString();//Cajas en Pedidos Posfechados


                    report.PrinSubPreventa.ReportSource = reportPrin;

                }



                if (cinco.Count != 0)
                {
                    //Subreporte
                    SubPreventaDetallado subReport1 = new SubPreventaDetallado();
                    subReport1.DataSource = cinco;


                    subReport1.sub1.DataBindings.Add("Text", null, "ProductoClave");
                    subReport1.sub2.DataBindings.Add("Text", null, "Nombre");
                    subReport1.sub3.DataBindings.Add("Text", null, "TipoUnidad");
                    subReport1.sub4.DataBindings.Add("Text", null, "TotalUnidades");
                    subReport1.sub5.DataBindings.Add("Text", null, "Importe", "{0:$#,##0.00}");

                    long GTC = 0;
                    decimal GTCI = 0;
                    long GTP = 0;
                    decimal GTPI = 0;

                    foreach (var e in cinco)
                    {

                        if (e.TipoUnidad==2) {

                            GTC += e.TotalUnidades;
                            GTCI += e.Importe;
                        }
                        if (e.TipoUnidad != 2)
                        {

                            GTP += e.TotalUnidades;
                            GTPI += e.Importe;
                        }

                    }

                    //GrantotapCajas
                    subReport1.gtc.Text = GTC.ToString();
                    subReport1.gtci.Text = String.Format("{0:$#,##0.00}", GTCI);


                    //GranTotalUnidad
                    subReport1.gtup.Text = GTP.ToString();
                    subReport1.gtupi.Text = String.Format("{0:$#,##0.00}", GTPI);



                    report.SubPreventa.ReportSource = subReport1;

                }

                if (uno.Count != 0 && cuatro.Count != 0 && cinco.Count != 0) {
                    return report;
                }
                else {
                    return null;
                }

                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    class PreveentaPedidos
    {
        public String Cliente { get; set; }
        public String ClienteClave { get; set; }
        public String Folio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public String TipoFase { get; set; }
        public String ProductoClave { get; set; }
        public String Nombre { get; set; }
        public int Cajas { get; set; }
        public int OtrasUnidades { get; set; }
        public String TipoEntrega { get; set; }
        public int Fase { get; set; }
        
    }

    class ClientesPorFrecuenciaPedidos
    {

        public int CF { get; set; }
        
    }

    class ClientesVisitadosPedidos
    {
        public int CVIS { get; set; }

    }

    class IndicadoresPedidos
    {    
        public int PedidosEfectivos { get; set; }
        public int ClientesConPedido { get; set; }
        public int CajasPedidosEfectivos { get; set; }
        public int OtraUnidadEfectivos { get; set; }
        public int PedidosCancelados { get; set; }
        public int CajasCanceladas { get; set; }
        public int PedidosPosfechados { get; set; }
        public int CajasPosfechadas { get; set; }

    }

    class TotalPorProductoPedidos
    {
        public String ProductoClave { get; set; }
        public String Nombre { get; set; }
        public String Unidad { get; set; }
        public int TipoUnidad { get; set; }
        public int TotalUnidades { get; set; }
        public Decimal Importe { get; set; }
    }



}