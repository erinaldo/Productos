using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class VentasvsAnioAnterior
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        ReporteVentasvsAnioAnterior report = new ReporteVentasvsAnioAnterior();

        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, int VAVClave, string pvCondicion, string pvCondicion1, string VendedorSplit, string FechaInicial, string FechaFinal, string Cedis, string nombreCedis, string unidadMedida)
        {
            //Logo Empresa
            string LogoQuery = "SELECT Logotipo FROM Configuracion (NOLOCK) ";
            byte[] byteArrayIn = Connection.Query<byte[]>(LogoQuery, null, null, true, 9000).FirstOrDefault();
            MemoryStream mStream = new MemoryStream(byteArrayIn);
            report.logo.Image = Image.FromStream(mStream);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;

            //CEDI
            if (Cedis != "" && Cedis != "null")
            {
                report.labelCEDIHeader.Text = Cedis + "-" + nombreCedis;
            }
            else
            {
                report.labelCEDIHeader.Text = "Todos";
            }

            //Vendedor
            if (VendedorSplit != "" && VendedorSplit != "null")
            {
                //Obtener Detalle
                StringBuilder VDetalle = new StringBuilder();
                VDetalle.AppendLine("Set ANSI_WARNINGS OFF ");
                VDetalle.AppendLine("Set nocount on ");
                VDetalle.AppendLine("Select Clave + '-' + Nombre as VenDetalle from");
                VDetalle.AppendLine("(");
                VDetalle.AppendLine("select U.Clave as Clave, V.Nombre as Nombre, V.VendedorID as VendedorID ");
                VDetalle.AppendLine("from Vendedor V (NOLOCK)");
                VDetalle.AppendLine("inner join Usuario U (NOLOCK) on V.USUId = U.USUId");
                VDetalle.AppendLine(") as TempA");
                VDetalle.AppendLine(pvCondicion);

                QueryString = "";
                QueryString = VDetalle.ToString();

                List<VendedorDetalle> DetalleList = Connection.Query<VendedorDetalle>(QueryString, null, null, true, 600).ToList();

                var Det = (from D in DetalleList select D).ToList().GroupBy(DD => new { DD.VenDetalle })
                        .SelectMany(DL => DL.Select(DS => new VendedorDetalle
                        {
                            VenDetalle = DS.VenDetalle
                        })).ToList();
                string DetalleV = "";
                foreach (var item in Det)
                {
                    if (item == Det.Last())
                    {
                        DetalleV += item.VenDetalle;
                    }
                    else
                    {
                        DetalleV += item.VenDetalle + ", ";
                    }
                }
                //---------------
                report.labelVendedorHeader.Text = DetalleV;
                //Cambia el tamaño del label vendedores
                float aux1 = Convert.ToInt32(report.TopMargin.HeightF);
                int contador = DetalleV.Length / 85;
                if (DetalleV.Length % 85 != 0)
                    contador += 1;
                for (int i = 1; i < contador; i++)
                {
                    aux1 += 16;
                }

                report.TopMargin.HeightF = (aux1);
            }
            else
            {
                report.labelVendedorHeader.Text = "Todos";
            }

            //FechaFiltro
            report.labelFechaFiltroHeader.Text = DateTime.Parse(FechaInicial).Date.ToShortDateString();

            //Filtro
            string Filtro = FechaInicial.Replace("T05:00:00.000Z", " 00:00:00");

            //SubReporte Anual Acumulado
            SubReporteGeneral SubReporteG = new SubReporteGeneral();

            StringBuilder VentasGeneral = new StringBuilder();
            VentasGeneral.AppendLine("Set ANSI_WARNINGS OFF ");
            VentasGeneral.AppendLine("Set nocount on ");
            VentasGeneral.AppendLine("set transaction isolation level read uncommitted ");
            VentasGeneral.AppendLine("Declare @FechaInicioAñoActual as Datetime, @FechaInicioAñoAnterior as Datetime,  @FechaInicioMesActual as Datetime, @FechaInicioMesAñoAnterior as Datetime, @FechaFiltradaAñoAnterior as Datetime ");
            VentasGeneral.AppendLine("Declare @Filtro as Datetime ");
            VentasGeneral.AppendLine("set @Filtro = '" + Filtro + "' ");
            VentasGeneral.AppendLine("set @FechaInicioAñoActual = DATEADD(yy,DATEDIFF(yy,0,@Filtro),0) ");
            VentasGeneral.AppendLine("set @FechaInicioAñoAnterior = DATEADD(yy,-1,DATEADD(yy,DATEDIFF(yy,0,@Filtro),0)) ");
            VentasGeneral.AppendLine("set @FechaInicioMesActual = DATEADD(MONTH, DATEDIFF(MONTH, 0,@Filtro), 0)  ");
            VentasGeneral.AppendLine("set @FechaInicioMesAñoAnterior = DATEADD(yy,-1,DATEADD(MONTH, DATEDIFF(MONTH, 0,@Filtro), 0)) ");
            VentasGeneral.AppendLine("set @FechaFiltradaAñoAnterior = DATEADD(yy,-1,@Filtro) ");
            VentasGeneral.AppendLine("Declare @TablaTempA TABLE ( Vendedor varchar(25),VendedorID varchar(25),Linea varchar(25), Actual decimal(25,2), Anterior  decimal(25,2) ); ");
            VentasGeneral.AppendLine("Declare @TablaTempB TABLE ( Vendedor varchar(25),VendedorID varchar(25),Linea varchar(25), Actual decimal(25,2), Anterior  decimal(25,2) ); ");
            VentasGeneral.AppendLine("Declare @VARValorLinea Table(VAVClave varchar(16)) ");
            VentasGeneral.AppendLine("insert into @VARValorLinea Select VAVClave from VARValor (NOLOCK) where Grupo = 'LIN' and VARCodigo = 'CESQUEMA' and Estado = 1 ");
            VentasGeneral.AppendLine("Insert Into @TablaTempA(Vendedor,VendedorID,Linea,Actual,Anterior) ");
            VentasGeneral.AppendLine("SELECT ");
            VentasGeneral.AppendLine("pt.Vendedor, ");
            VentasGeneral.AppendLine("pt.VendedorID, ");
            VentasGeneral.AppendLine("pt.Linea, ");
            VentasGeneral.AppendLine("pt.Actual, ");
            VentasGeneral.AppendLine("pt.Anterior ");
            VentasGeneral.AppendLine("FROM ");
            VentasGeneral.AppendLine("( ");
            VentasGeneral.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasGeneral.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasGeneral.AppendLine("'Actual' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasGeneral.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasGeneral.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between  @FechaInicioAñoActual and @Filtro");
            VentasGeneral.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasGeneral.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasGeneral.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasGeneral.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasGeneral.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasGeneral.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasGeneral.AppendLine("union all ");
            VentasGeneral.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasGeneral.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasGeneral.AppendLine("'Anterior' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasGeneral.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasGeneral.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between @FechaInicioAñoAnterior and @FechaFiltradaAñoAnterior");
            VentasGeneral.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasGeneral.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasGeneral.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasGeneral.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasGeneral.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasGeneral.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasGeneral.AppendLine(") pvt ");
            VentasGeneral.AppendLine("PIVOT ");
            VentasGeneral.AppendLine("( ");
            VentasGeneral.AppendLine("sum(Cajas) FOR Nombre IN ([Actual],[Anterior]) ");
            VentasGeneral.AppendLine(") AS pt ");
            VentasGeneral.AppendLine("where Linea <>'' ");
            VentasGeneral.AppendLine("Insert Into @TablaTempB(Vendedor,VendedorID,Linea,Actual,Anterior) ");
            VentasGeneral.AppendLine("SELECT ");
            VentasGeneral.AppendLine("pt.Vendedor, ");
            VentasGeneral.AppendLine("pt.VendedorID, ");
            VentasGeneral.AppendLine("pt.Linea, ");
            VentasGeneral.AppendLine("pt.Actual, ");
            VentasGeneral.AppendLine("pt.Anterior ");
            VentasGeneral.AppendLine("FROM ");
            VentasGeneral.AppendLine("( ");
            VentasGeneral.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasGeneral.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasGeneral.AppendLine("'Actual' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasGeneral.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasGeneral.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between  @FechaInicioAñoActual and @Filtro");
            VentasGeneral.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasGeneral.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasGeneral.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasGeneral.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasGeneral.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasGeneral.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasGeneral.AppendLine("union all ");
            VentasGeneral.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasGeneral.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasGeneral.AppendLine("'Anterior' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasGeneral.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasGeneral.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between @FechaInicioAñoAnterior and @FechaFiltradaAñoAnterior");
            VentasGeneral.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasGeneral.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasGeneral.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasGeneral.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasGeneral.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasGeneral.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasGeneral.AppendLine(") pvt ");
            VentasGeneral.AppendLine("PIVOT ");
            VentasGeneral.AppendLine("( ");
            VentasGeneral.AppendLine("sum(Cajas) FOR Nombre IN ([Actual],[Anterior]) ");
            VentasGeneral.AppendLine(") AS pt ");
            VentasGeneral.AppendLine("where Linea <>'' ");
            VentasGeneral.AppendLine("select TA.linea as Linea, isnull(TA.CartonesAnoActual,0) as CartonA, isnull(TA.CartonesAnoAnterior,0) as CartonAAnterior, case when isnull(TA.CartonesAnoAnterior,0) <> 0 then convert(int,(((isnull(TA.CartonesAnoActual,0) - isnull(TA.CartonesAnoAnterior,0)) / isnull(TA.CartonesAnoAnterior,0)) * 100)) else 100 end as ComparacionAnio, ");
            VentasGeneral.AppendLine("isnull(TB.CartonesAnoActual,0) as CartonM, isnull(TB.CartonesAnoAnterior,0) as CartonMAnterior, case when isnull(TB.CartonesAnoAnterior,0) <> 0 then convert(int,(((isnull(TB.CartonesAnoActual,0) - isnull(TB.CartonesAnoAnterior,0)) / isnull(TB.CartonesAnoAnterior,0)) * 100)) else 100 end as ComparacionMes, ");
            VentasGeneral.AppendLine("CONCAT('Del ',DAY(@FechaInicioAñoActual),'/',MONTH(@FechaInicioAñoActual),'/',YEAR(@FechaInicioAñoActual),' al ',DAY(@Filtro),'/',MONTH(@Filtro),'/',YEAR(@Filtro)) as FechaAcumulada, ");
            VentasGeneral.AppendLine("CONCAT('Del ',DAY(@FechaInicioMesActual),'/',MONTH(@FechaInicioMesActual),'/',YEAR(@FechaInicioMesActual),' al ',DAY(@Filtro),'/',MONTH(@Filtro),'/',YEAR(@Filtro)) as FechaMensualAcumulada ");
            VentasGeneral.AppendLine("from  ");
            VentasGeneral.AppendLine("( ");
            VentasGeneral.AppendLine("select Linea ,Sum(Actual) as CartonesAnoActual, Sum(Anterior) as CartonesAnoAnterior from @TablaTempA group by Linea ");
            VentasGeneral.AppendLine(") as TA ");
            VentasGeneral.AppendLine("inner join ");
            VentasGeneral.AppendLine("( ");
            VentasGeneral.AppendLine("select Linea ,Sum(Actual) as CartonesAnoActual, Sum(Anterior) as CartonesAnoAnterior from @TablaTempB group by Linea ");
            VentasGeneral.AppendLine(") as TB on TA.Linea = TB.Linea ");

            QueryString = "";
            QueryString = VentasGeneral.ToString();

            List<VentasvsAnioAnteriorGeneralModel> VG = Connection.Query<VentasvsAnioAnteriorGeneralModel>(QueryString, null, null, true, 600).ToList();

            var VGList = (from G in VG select G).ToList().GroupBy(GD => new { GD.Linea })
                    .SelectMany(GL => GL.Select(GS => new VentasvsAnioAnteriorGeneralModel
                    {
                        Linea = GS.Linea,
                        CartonA = GS.CartonA.Replace(",00", ""),
                        ComparacionAnio = GS.ComparacionAnio + " %",
                        CartonM = GS.CartonM.Replace(",00", ""),
                        ComparacionMes = GS.ComparacionMes + " %",
                        FechaAcumulada = GS.FechaAcumulada,
                        FechaMensualAcumulada = GS.FechaMensualAcumulada
                    })).ToList();

            string FDia = "";
            string FRango = "";
            foreach (var item in VGList)
            {
                FDia = item.FechaAcumulada;
                FRango = item.FechaMensualAcumulada;
            }

            SubReporteG.DataSource = VGList;
            SubReporteG.labelFecha1.Text = FDia;
            SubReporteG.labelProducto1.DataBindings.Add("Text", null, "Linea");
            SubReporteG.labelCartones1.DataBindings.Add("Text", null, "CartonA");
            SubReporteG.labelPorcentaje1.DataBindings.Add("Text", null, "ComparacionAnio");
            SubReporteG.labelFecha2.Text = FRango;
            SubReporteG.labelProducto2.DataBindings.Add("Text", null, "Linea");
            SubReporteG.labelCartones2.DataBindings.Add("Text", null, "CartonM");
            SubReporteG.labelPorcentaje2.DataBindings.Add("Text", null, "ComparacionMes");

            if (VGList.Count > 0)
            {
                report.xrSubreportGral.ReportSource = SubReporteG;
            }

            //SubconsultaGral
            StringBuilder VentasDetalladas = new StringBuilder();
            VentasDetalladas.AppendLine("Set ANSI_WARNINGS OFF ");
            VentasDetalladas.AppendLine("Set nocount on ");
            VentasDetalladas.AppendLine("set transaction isolation level read uncommitted ");
            VentasDetalladas.AppendLine("Declare @FechaInicioAñoActual as Datetime, @FechaInicioAñoAnterior as Datetime,  @FechaInicioMesActual as Datetime, @FechaInicioMesAñoAnterior as Datetime, @FechaFiltradaAñoAnterior as Datetime ");
            VentasDetalladas.AppendLine("Declare @Filtro as Datetime ");
            VentasDetalladas.AppendLine("set @Filtro = '" + Filtro + "' ");
            VentasDetalladas.AppendLine("set @FechaInicioAñoActual = DATEADD(yy,DATEDIFF(yy,0,@Filtro),0) ");
            VentasDetalladas.AppendLine("set @FechaInicioAñoAnterior = DATEADD(yy,-1,DATEADD(yy,DATEDIFF(yy,0,@Filtro),0)) ");
            VentasDetalladas.AppendLine("set @FechaInicioMesActual = DATEADD(MONTH, DATEDIFF(MONTH, 0,@Filtro), 0)  ");
            VentasDetalladas.AppendLine("set @FechaInicioMesAñoAnterior = DATEADD(yy,-1,DATEADD(MONTH, DATEDIFF(MONTH, 0,@Filtro), 0)) ");
            VentasDetalladas.AppendLine("set @FechaFiltradaAñoAnterior = DATEADD(yy,-1,@Filtro) ");
            VentasDetalladas.AppendLine("Declare @TablaTempA TABLE ( Vendedor varchar(25),VendedorID varchar(25),Linea varchar(25), Actual decimal(25,2), Anterior  decimal(25,2) ); ");
            VentasDetalladas.AppendLine("Declare @TablaTempB TABLE ( Vendedor varchar(25),VendedorID varchar(25),Linea varchar(25), Actual decimal(25,2), Anterior  decimal(25,2) ); ");
            VentasDetalladas.AppendLine("Declare @VARValorLinea Table(VAVClave varchar(16)) ");
            VentasDetalladas.AppendLine("insert into @VARValorLinea Select VAVClave from VARValor (NOLOCK) where Grupo = 'LIN' and VARCodigo = 'CESQUEMA' and Estado = 1 ");
            VentasDetalladas.AppendLine("Insert Into @TablaTempA(Vendedor,VendedorID,Linea,Actual,Anterior) ");
            VentasDetalladas.AppendLine("SELECT ");
            VentasDetalladas.AppendLine("pt.Vendedor, ");
            VentasDetalladas.AppendLine("pt.VendedorID, ");
            VentasDetalladas.AppendLine("pt.Linea, ");
            VentasDetalladas.AppendLine("pt.Actual, ");
            VentasDetalladas.AppendLine("pt.Anterior ");
            VentasDetalladas.AppendLine("FROM ");
            VentasDetalladas.AppendLine("( ");
            VentasDetalladas.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasDetalladas.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasDetalladas.AppendLine("'Actual' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasDetalladas.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasDetalladas.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between  @FechaInicioAñoActual and @Filtro");
            VentasDetalladas.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasDetalladas.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasDetalladas.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasDetalladas.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasDetalladas.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasDetalladas.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasDetalladas.AppendLine("union all ");
            VentasDetalladas.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasDetalladas.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasDetalladas.AppendLine("'Anterior' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasDetalladas.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasDetalladas.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between @FechaInicioAñoAnterior and @FechaFiltradaAñoAnterior");
            VentasDetalladas.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasDetalladas.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasDetalladas.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasDetalladas.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasDetalladas.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasDetalladas.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasDetalladas.AppendLine(") pvt ");
            VentasDetalladas.AppendLine("PIVOT ");
            VentasDetalladas.AppendLine("( ");
            VentasDetalladas.AppendLine("sum(Cajas) FOR Nombre IN ([Actual],[Anterior]) ");
            VentasDetalladas.AppendLine(") AS pt ");
            VentasDetalladas.AppendLine("where Linea <>'' ");
            VentasDetalladas.AppendLine("Insert Into @TablaTempB(Vendedor,VendedorID,Linea,Actual,Anterior) ");
            VentasDetalladas.AppendLine("SELECT ");
            VentasDetalladas.AppendLine("pt.Vendedor, ");
            VentasDetalladas.AppendLine("pt.VendedorID, ");
            VentasDetalladas.AppendLine("pt.Linea, ");
            VentasDetalladas.AppendLine("pt.Actual, ");
            VentasDetalladas.AppendLine("pt.Anterior ");
            VentasDetalladas.AppendLine("FROM ");
            VentasDetalladas.AppendLine("( ");
            VentasDetalladas.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasDetalladas.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasDetalladas.AppendLine("'Actual' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasDetalladas.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasDetalladas.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between  @FechaInicioAñoActual and @Filtro");
            VentasDetalladas.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasDetalladas.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasDetalladas.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasDetalladas.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasDetalladas.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasDetalladas.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasDetalladas.AppendLine("union all ");
            VentasDetalladas.AppendLine("Select Ven.Nombre as Vendedor, Ven.VendedorID as VendedorID, ");
            VentasDetalladas.AppendLine("isnull((Select ESQ.Nombre  from dbo.BuscaIdsEsquema(PRO.EsquemaID) BE inner join Esquema ESQ (NOLOCK) on BE.Ids = ESQ.EsquemaID and Clasificacion in (Select VAVClave from @VARValorLinea)),'') as Linea, ");
            VentasDetalladas.AppendLine("'Anterior' as Nombre,isnull(TPD.Cantidad,0) as Cajas from TransProd TP (NOLOCK) ");
            VentasDetalladas.AppendLine("inner join Visita V (NOLOCK) on V.VisitaClave = case when TP.VisitaClave1 is null Or TP.VisitaClave1 = '' then TP.VisitaClave  else TP.VisitaClave1 end and TP.Tipo IN (1,24) and TP.TipoFase in (2,3) " + pvCondicion1);
            VentasDetalladas.AppendLine("inner join Dia D (NOLOCK) on D.DiaClave = v.DiaClave and D.FechaCaptura between @FechaInicioAñoAnterior and @FechaFiltradaAñoAnterior");
            VentasDetalladas.AppendLine("inner join Cliente C (NOLOCK) on C.ClienteClave = V.ClienteClave ");
            VentasDetalladas.AppendLine("inner join Vendedor Ven (NOLOCK) on V.VendedorID = Ven.VendedorID ");
            VentasDetalladas.AppendLine("inner join VENCentroDistHist VHt (NOLOCK) on VHt.VendedorId = Ven.VendedorID and VHt.VCHFechaInicial <= @FechaInicioAñoActual and VHt.FechaFinal >= @Filtro");
            VentasDetalladas.AppendLine("inner join Almacen A (NOLOCK) on A.AlmacenID = VHt.AlmacenId and A.Clave = '" + Cedis + "'");
            VentasDetalladas.AppendLine("inner join TransprodDetalle TPD (NOLOCK) on TP.transprodid = TPD.TransProdID ");
            VentasDetalladas.AppendLine("inner join ProductoEsquema Pro (NOLOCK) on Pro.ProductoClave = TPD.ProductoClave  and isnull(TPD.Promocion,0) <> 2 ");
            VentasDetalladas.AppendLine(") pvt ");
            VentasDetalladas.AppendLine("PIVOT ");
            VentasDetalladas.AppendLine("( ");
            VentasDetalladas.AppendLine("sum(Cajas) FOR Nombre IN ([Actual],[Anterior]) ");
            VentasDetalladas.AppendLine(") AS pt ");
            VentasDetalladas.AppendLine("where Linea <>'' ");
            VentasDetalladas.AppendLine("select TempA.Vendedor as NombreV, TempA.VendedorID as VendedorID, TempA.Linea as Linea, isnull(TempA.Actual,0) as ActualA,isnull(TempA.Anterior,0) as AnteriorA, ");
            VentasDetalladas.AppendLine("isnull(TempB.Actual,0) as ActualM, isnull(TempB.Anterior,0) as AnteriorM, ");
            VentasDetalladas.AppendLine("case when isnull(TempA.Anterior,0)<> 0 then convert(int, Round(((isnull(TempA.Actual, 0) - isnull(TempA.Anterior, 0)) / isnull(TempA.Anterior, 0)) * 100,0)) else 100 end as PAcumulado, ");
            VentasDetalladas.AppendLine("case when isnull(TempB.Anterior,0)<> 0 then convert(int, Round(((isnull(TempB.Actual, 0) - isnull(TempB.Anterior, 0)) / isnull(TempB.Anterior, 0)) * 100,0)) else 100 end as PMensual  ");
            VentasDetalladas.AppendLine("from @TablaTempA TempA ");
            VentasDetalladas.AppendLine("inner join @TablaTempB TempB on TempA.VendedorID = TempB.VendedorID and TempA.Linea = TempB.Linea ");
            if (VendedorSplit != null && VendedorSplit != "null" && VendedorSplit != "")
            {
                VentasDetalladas.AppendLine(pvCondicion);
            }
            VentasDetalladas.AppendLine("order By Linea, NombreV ");

            QueryString = "";
            QueryString = VentasDetalladas.ToString();

            List<VentasvsAnioAnteriorDetalladoModel> VD = Connection.Query<VentasvsAnioAnteriorDetalladoModel>(QueryString, null, null, true, 600).ToList();

            var VDList = (from D in VD select D).ToList().GroupBy(DD => new { DD.Linea })
                    .SelectMany(DL => DL.Select(DS => new VentasvsAnioAnteriorDetalladoModel
                    {
                        NombreV = DS.NombreV,
                        Linea = "Ventas por Vendedor " + DS.Linea,
                        VendedorID = DS.VendedorID,
                        ActualA = DS.ActualA.Replace(",00", ""),
                        AnteriorA = DS.AnteriorA,
                        ActualM = DS.ActualM.Replace(",00", ""),
                        AnteriorM = DS.AnteriorM,
                        PAcumulado = DS.PAcumulado + " %",
                        PMensual = DS.PMensual + " %"
                    })).ToList();

            SubReporteDetallado SubReporteD = new SubReporteDetallado();
            SubReporteD.DataSource = VDList;

            //GroupHeader1
            GroupField groupLinea = new GroupField("Linea");
            SubReporteD.GroupHeader1.GroupFields.Add(groupLinea);
            SubReporteD.labelSeparador.DataBindings.Add("Text", report.DataSource, "Linea");
            SubReporteD.labelFecha1.Text = FDia;
            SubReporteD.labelFecha2.Text = FRango;

            //Datos Generales
            SubReporteD.labelProducto1.DataBindings.Add("Text", null, "NombreV");
            SubReporteD.labelCartones1.DataBindings.Add("Text", null, "ActualA");
            SubReporteD.labelPorcentaje1.DataBindings.Add("Text", null, "PAcumulado");
            SubReporteD.labelProducto2.DataBindings.Add("Text", null, "NombreV");
            SubReporteD.labelCartones2.DataBindings.Add("Text", null, "ActualM");
            SubReporteD.labelPorcentaje2.DataBindings.Add("Text", null, "PMensual");

            if (VDList.Count > 0)
            {
                report.xrSubreportDetallado.ReportSource = SubReporteD;
            }

            //Regresa el reporte completo
            if (VGList.Count == 0 && VDList.Count == 0)
            {
                return null;
            }
            else
            {
                return report;
            }
        }

    }

    class VentasvsAnioAnteriorGeneralModel
    {
        public string Nombre { get; set; }
        public string Linea { get; set; }
        public string CartonA { get; set; }
        public string ComparacionAnio { get; set; }
        public string CartonM { get; set; }
        public string ComparacionMes { get; set; }
        public string FechaAcumulada { get; set; }
        public string FechaMensualAcumulada { get; set; }
    }

    class VentasvsAnioAnteriorDetalladoModel
    {
        public string NombreV { get; set; }
        public string VendedorID { get; set; }
        public string Linea { get; set; }
        public string ActualA { get; set; }
        public string AnteriorA { get; set; }
        public string ActualM { get; set; }
        public string AnteriorM { get; set; }
        public string PAcumulado { get; set; }
        public string PMensual { get; set; }
    }

    class VendedorDetalle
    {
        public string VenDetalle { get; set; }
    }

}