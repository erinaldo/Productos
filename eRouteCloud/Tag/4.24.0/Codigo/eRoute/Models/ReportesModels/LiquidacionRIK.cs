using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Globalization;
using System.Text;
using System.IO;
using System.Drawing;
using System.Web;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace eRoute.Models.ReportesModels
{
    public class LiquidacionRIK
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private string Fecha;
        private string VendedorID;
        private string NombreReporte;
        private string NombreEmpresa;
        
        public bool GetReport(string NombreReporte, string NombreEmpresa, string Fecha, string VendedorID, bool Detallado)
        {
            this.NombreReporte = NombreReporte;
            this.NombreEmpresa = NombreEmpresa;

            if (Detallado)
                return GetReportDetallado(Fecha, VendedorID);
            else
                return GetReportGeneral(Fecha, VendedorID);
        }

        public bool GetReportGeneral(string Fecha, string VendedorID)
        {
            try
            {
                this.NombreReporte = this.NombreReporte + " General";
                DateTime dFecha;
                DateTime.TryParse(Fecha, out dFecha);
                DateTime dFechaFiltro = dFecha.Date;
                this.Fecha = dFecha.ToShortDateString();
                this.VendedorID = VendedorID.Replace("'", "");

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");

                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");
                sConsulta.AppendLine("declare @UsuarioID as varchar(16) ");
                sConsulta.AppendLine("declare @PrecioBase as varchar(10) ");
                sConsulta.AppendLine("declare @IdInvBordo as varchar(16) ");
                sConsulta.AppendLine("declare @IdPrimerCarga as varchar(16) ");
                sConsulta.AppendLine("declare @IdRegargaDiaSig as varchar(16) ");

                sConsulta.AppendLine("set @Fecha = '" + dFechaFiltro.ToString("s") + "' ");
                sConsulta.AppendLine("set @VendedorID = " + VendedorID + " ");

                sConsulta.AppendLine("set @UsuarioID = (select USUId from Vendedor (NOLOCK) where VendedorID = @VendedorID) ");
                sConsulta.AppendLine("set @PrecioBase = (select ListaPrecioBase from Vendedor (NOLOCK) where VendedorID = @VendedorID) ");

                sConsulta.AppendLine("set @IdInvBordo = (");
                sConsulta.AppendLine("  select top 1 TRP.TransProdID ");
                sConsulta.AppendLine("  from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where TRP.Tipo = 23 and TRP.TipoFase = 1 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura < @Fecha ");
                sConsulta.AppendLine("  order by Dia.FechaCaptura desc) ");

                sConsulta.AppendLine("set @IdPrimerCarga = (");
                sConsulta.AppendLine("  select top 1 TRP.TransProdID ");
                sConsulta.AppendLine("  from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("  order by TRP.FechaHoraAlta) ");

                sConsulta.AppendLine("set @IdRegargaDiaSig = (");
	            sConsulta.AppendLine("  select top 1 TRP.TransProdID ");
	            sConsulta.AppendLine("  from TransProd TRP (NOLOCK) ");
	            sConsulta.AppendLine("  inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
	            sConsulta.AppendLine("  where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura > @Fecha ");
	            sConsulta.AppendLine("  order by TRP.FechaHoraAlta) ");

                sConsulta.AppendLine("select t3.*, (InventarioInicial + Recarga + Devolucion + Rotacion - Promocion - DevDescAlmacen - Venta + RecargaDiaSig) as InventarioFinal ");
                sConsulta.AppendLine("from( ");
                sConsulta.AppendLine("  select sum(t2.InventarioInicial) as InventarioInicial, sum(t2.Recarga) as Recarga, sum(t2.Devolucion) as Devolucion, sum(t2.Rotacion) as Rotacion, ");
                sConsulta.AppendLine("  sum(t2.Promocion) as Promocion, sum(t2.DevDescAlmacen) as DevDescAlmacen, sum(t2.Venta) as Venta, sum(t2.RecargaDiaSig) as RecargaDiaSig ");
                sConsulta.AppendLine("  from( ");
                sConsulta.AppendLine("      select case when t1.Tipo = 23 or (t1.Tipo = 2 and t1.PrimerCarga = 1) then t1.Total else 0 end as InventarioInicial, ");
                sConsulta.AppendLine("             case when t1.Tipo = 2 and t1.PrimerCarga = 0 and t1.RecargaDiaSig = 0 then t1.Total else 0 end as Recarga, ");
                sConsulta.AppendLine("             case when t1.Tipo = 3 and t1.MotivoVenta = 0 then t1.Total else 0 end as Devolucion, ");
                sConsulta.AppendLine("             case when t1.Tipo = 3 and t1.MotivoVenta = 1 then t1.Total else 0 end as Rotacion, ");
                sConsulta.AppendLine("             case when t1.Tipo = 1 then t1.ImpPromocion else 0 end as Promocion, ");
                sConsulta.AppendLine("             case when t1.Tipo in (4, 7) then t1.Total else 0 end as DevDescAlmacen, ");
                sConsulta.AppendLine("             case when t1.Tipo = 1 then t1.Total else 0 end as Venta, ");
                sConsulta.AppendLine("             case when t1.Tipo = 2 and t1.RecargaDiaSig = 1 then t1.Total else 0 end as RecargaDiaSig ");
                sConsulta.AppendLine("      from( ");
                sConsulta.AppendLine("          --Inventario a bordo ");
                sConsulta.AppendLine("          select TRP.Tipo, TRP.Total, 0 as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as ImpPromocion ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          where TRP.TransProdID = @IdInvBordo ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Primer carga y Recarga ");
                sConsulta.AppendLine("          select t.Tipo, sum(t.Cantidad * t.Precio) as Total, t.PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as ImpPromocion "); 
			    sConsulta.AppendLine("          from( "); 
				sConsulta.AppendLine("              select TRP.Tipo, case when TRP.TransProdID = @IdPrimerCarga then 1 else 0 end as PrimerCarga, TPD.Cantidad, "); 
				sConsulta.AppendLine("              case when isnull(TPD.Precio, 0) = 0 then dbo.FNObtenerPrecio(@PrecioBase, TPD.ProductoClave, TPD.TipoUnidad, @Fecha) else TPD.Precio end as Precio ");
				sConsulta.AppendLine("              from TransProd TRP (NOLOCK) "); 
				sConsulta.AppendLine("              inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID "); 
				sConsulta.AppendLine("              inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave "); 
				sConsulta.AppendLine("              where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha "); 
			    sConsulta.AppendLine("          ) as t "); 
			    sConsulta.AppendLine("          group by t.Tipo, t.PrimerCarga ");
                //sConsulta.AppendLine("          select TRP.Tipo, TRP.Total, case when TRP.TransProdID = @IdPrimerCarga then 1 else 0 end as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as ImpPromocion ");
                //sConsulta.AppendLine("          from TransProd TRP ");
                //sConsulta.AppendLine("          inner join Dia on TRP.DiaClave = Dia.DiaClave ");
                //sConsulta.AppendLine("          where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Recarga dia siguiente ");
                sConsulta.AppendLine("          select t.Tipo, sum(t.Cantidad * t.Precio) as Total, 0 as PrimerCarga, 1 as RecargaDiaSig, 0 as MotivoVenta, 0 as ImpPromocion "); 
			    sConsulta.AppendLine("          from( "); 
                sConsulta.AppendLine("              select TRP.Tipo, TPD.Cantidad, "); 
                sConsulta.AppendLine("              case when isnull(TPD.Precio, 0) = 0 then dbo.FNObtenerPrecio(@PrecioBase, TPD.ProductoClave, TPD.TipoUnidad, @Fecha) else TPD.Precio end as Precio ");
                sConsulta.AppendLine("              from TransProd TRP (NOLOCK) "); 
                sConsulta.AppendLine("              inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID "); 
                sConsulta.AppendLine("              where TRP.TransProdID = @IdRegargaDiaSig ");
                sConsulta.AppendLine("          ) as t "); 
                sConsulta.AppendLine("          group by t.Tipo ");
                //sConsulta.AppendLine("          select TRP.Tipo, TRP.Total, 0 as PrimerCarga, 1 as RecargaDiaSig, 0 as MotivoVenta, 0 as ImpPromocion ");
                //sConsulta.AppendLine("          from TransProd TRP ");
                //sConsulta.AppendLine("          inner join Dia on TRP.DiaClave = Dia.DiaClave ");
                //sConsulta.AppendLine("          where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = dateadd(day, 1, @Fecha) ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Devolucion y Descarga al almacen ");
                sConsulta.AppendLine("          select TRP.Tipo, TRP.Total, 0 as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as ImpPromocion ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          where TRP.Tipo in (4, 7) and TRP.TipoFase = 1 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Devolucion de cliente ");
                sConsulta.AppendLine("          select TRP.Tipo, TPD.Total, 0 as PrimerCarga, 0 as RecargaDiaSig, case when upper(VAV.Grupo) = 'VENTA' then 1 else 0 end as MotivoVenta, 0 as ImpPromocion ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          inner join Visita (NOLOCK) VIS on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          inner join VARValor VAV (NOLOCK) on VAV.VARCodigo = 'TRPMOT' and VAV.VAVClave = TPD.TipoMotivo ");
                sConsulta.AppendLine("          where TRP.Tipo = 3 and TRP.TipoFase = 1 and VIS.VendedorID = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Venta y promocion ");
                sConsulta.AppendLine("          select t.Tipo, t.Total, 0 as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, ");
                sConsulta.AppendLine("          sum(case when t.Promocion = 2 then(t.Cantidad * t.Precio) else 0 end) as ImpPromocion ");
                sConsulta.AppendLine("          from( ");
                sConsulta.AppendLine("              select TRP.TransProdID, TRP.Tipo, TRP.Total, TPD.Cantidad, ");
                sConsulta.AppendLine("              case when isnull(TPD.Promocion, 0) = 2 then dbo.FNObtenerPrecio(@PrecioBase, TPD.ProductoClave, TPD.TipoUnidad, @Fecha) else TPD.Precio end as Precio, ");
                sConsulta.AppendLine("              isnull(TPD.Promocion, 0) as Promocion ");
                sConsulta.AppendLine("              from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("              inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("              inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("              inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("              where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.VendedorID = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          ) as t ");
                sConsulta.AppendLine("          group by t.TransProdID, t.Tipo, t.Total ");
                sConsulta.AppendLine("      ) as t1 ");
                sConsulta.AppendLine("  ) as t2 ");
                sConsulta.AppendLine(") as t3 ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();
                Connection.Open();
                List<TotalesLiqRIKModel> Totales = Connection.Query<TotalesLiqRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                sConsulta.Clear();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");

                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");

                sConsulta.AppendLine("set @Fecha = '" + dFechaFiltro.ToString("s") + "' ");
                sConsulta.AppendLine("set @VendedorID = " + VendedorID + " ");

                sConsulta.AppendLine("select sum(ClientesProgramados) as ClientesProgramados, sum(ClientesVisitados) as ClientesVisitados, sum(ClientesConCompra) as ClientesConCompra, ");
                sConsulta.AppendLine("case when sum(ClientesProgramados) > 0 then round((convert(float,sum(ClientesVisitados))/convert(float,sum(ClientesProgramados))) * 100, 2) else 0 end as EfectividadDeVisita, ");
                sConsulta.AppendLine("case when sum(ClientesVisitados) > 0 then round((convert(float, sum(ClientesConCompra)) / convert(float, sum(ClientesVisitados))) * 100, 2) else 0 end as EfectividadDeCompra, ");
                sConsulta.AppendLine("convert(varchar(8), convert(time, dateadd(ms, sum(TiempoDeServicio) * 1000, 0))) as TiempoDeServicio, ");
                sConsulta.AppendLine("convert(varchar(8), convert(time, dateadd(ms, sum(TiempoDeJornada - TiempoDeServicio) * 1000, 0))) as TiempoDeTraslado ");
                sConsulta.AppendLine("from( ");
                sConsulta.AppendLine("  --Clientes programados ");
                sConsulta.AppendLine("  select count(distinct(ClienteClave)) as ClientesProgramados, 0 as ClientesVisitados, 0 as ClientesConCompra, 0 as TiempoDeServicio, 0 as TiempoDeJornada ");
                sConsulta.AppendLine("  from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where AGV.VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("  union all ");
                sConsulta.AppendLine("  --Clientes visitados, con compra y tiempo de servicio ");
                sConsulta.AppendLine("  select 0 as ClientesProgramados, count(distinct(ClienteClave)) as ClientesVisitados, count(distinct(ClienteConCompra)) as ClientesConCompra, ");
                sConsulta.AppendLine("  sum(datediff(second, FechaHoraInicial, FechaHoraFinal)) as TiempoDeServicio, 0 as TiempoDeJornada ");
                sConsulta.AppendLine("  from( ");
                sConsulta.AppendLine("      select ClienteClave, FechaHoraInicial, FechaHoraFinal, case when Compra > 0 then ClienteClave else null end as ClienteConCompra ");
                sConsulta.AppendLine("      from( ");
                sConsulta.AppendLine("          select VIS.ClienteClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, count(distinct(TRP.TransProdID)) as Compra ");
                sConsulta.AppendLine("          from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          left join TransProd TRP (NOLOCK) on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase = 2 ");
                sConsulta.AppendLine("          where VIS.VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          group by VIS.ClienteClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal ");
                sConsulta.AppendLine("      ) as t ");
                sConsulta.AppendLine("  ) as t1 ");
                sConsulta.AppendLine("  union all ");
                sConsulta.AppendLine("  --Tiempo de jornada ");
                sConsulta.AppendLine("  select 0 as ClientesProgramados, 0 as ClientesVisitados, 0 as ClientesConCompra, 0 as TiempoDeServicio, ");
                sConsulta.AppendLine("  sum(datediff(second, VEJFechaInicial, FechaFinal)) as TiempoDeJornada ");
                sConsulta.AppendLine("  from VendedorJornada VEJ (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on VEJ.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine(") as t2 ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();
                Connection.Open();
                List<TotalesJornadaLiqRIKModel> TotalesJornada = Connection.Query<TotalesJornadaLiqRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                sConsulta.Clear();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");

                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");

                sConsulta.AppendLine("set @Fecha = '" + dFechaFiltro.ToString("s") + "' ");
                sConsulta.AppendLine("set @VendedorID = " + VendedorID + " ");

                sConsulta.AppendLine("select top 1 CMV.Placa, CAM.Clave, CMV.KmInicial, CMV.KmFinal, (CMV.KmFinal - CMV.KmInicial) as Recorrido ");
                sConsulta.AppendLine("from CamionVendedor CMV (NOLOCK) ");
                sConsulta.AppendLine("inner join Camion CAM (NOLOCK) on CMV.Placa = CAM.Placa ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on CMV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<CamionLiqRIKModel> Camion = Connection.Query<CamionLiqRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (Totales.Count == 0  || TotalesJornada.Count == 0) // || Camion.Count == 0)
                    return false;
                else
                {
                    CamionLiqRIKModel oCamion;
                    if (Camion.Count == 0)
                    {
                        oCamion = new CamionLiqRIKModel();
                        oCamion.Clave = "";
                        oCamion.Placa = "";
                    }
                    else
                        oCamion = Camion[0];

                    string fileName = GenerarExcelGeneral(Totales[0], TotalesJornada[0], oCamion);
                    DownloadFile.DownloadOpenXML(fileName);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GetReportDetallado(string Fecha, string VendedorID) {
            try
            {
                this.NombreReporte = this.NombreReporte + " Detallado";
                DateTime dFecha;
                DateTime.TryParse(Fecha, out dFecha);
                DateTime dFechaFiltro = dFecha.Date;
                this.Fecha = dFecha.ToShortDateString();
                this.VendedorID = VendedorID.Replace("'", "");

                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");

                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");
                sConsulta.AppendLine("declare @UsuarioID as varchar(16) ");
                sConsulta.AppendLine("declare @PrecioBase as varchar(10) ");
                sConsulta.AppendLine("declare @IdInvBordo as varchar(16) ");
                sConsulta.AppendLine("declare @IdPrimerCarga as varchar(16) ");
                sConsulta.AppendLine("declare @IdRegargaDiaSig as varchar(16) ");

                sConsulta.AppendLine("set @Fecha = '" + dFechaFiltro.ToString("s") + "' ");
                sConsulta.AppendLine("set @VendedorID = " + VendedorID + " ");

                sConsulta.AppendLine("set @UsuarioID = (select USUId from Vendedor (NOLOCK) where VendedorID = @VendedorID) ");
                sConsulta.AppendLine("set @PrecioBase = (select ListaPrecioBase from Vendedor (NOLOCK) where VendedorID = @VendedorID) ");

                sConsulta.AppendLine("set @IdInvBordo = (");
                sConsulta.AppendLine("  select top 1 TRP.TransProdID ");
                sConsulta.AppendLine("  from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where TRP.Tipo = 23 and TRP.TipoFase = 1 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura < @Fecha ");
                sConsulta.AppendLine("  order by Dia.FechaCaptura desc) ");

                sConsulta.AppendLine("set @IdPrimerCarga = (");
                sConsulta.AppendLine("  select top 1 TRP.TransProdID ");
                sConsulta.AppendLine("  from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("  order by TRP.FechaHoraAlta) ");

                sConsulta.AppendLine("set @IdRegargaDiaSig = (");
                sConsulta.AppendLine("  select top 1 TRP.TransProdID ");
                sConsulta.AppendLine("  from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura > @Fecha ");
                sConsulta.AppendLine("  order by TRP.FechaHoraAlta) ");

                sConsulta.AppendLine("select t2.ProductoClave, PRO.Nombre, InventarioInicial, Recarga, Devolucion, Rotacion, Promocion, DevDescAlmacen, t2.Venta, RecargaDiaSig, ");
                sConsulta.AppendLine("(InventarioInicial + Recarga + Devolucion + Rotacion - Promocion - DevDescAlmacen - t2.Venta + RecargaDiaSig) as InventarioFinal, ImporteVenta, ImporteDevolucion, ImporteRotacion  ");
                sConsulta.AppendLine("from ( ");
                sConsulta.AppendLine("  select t1.ProductoClave, sum(InventarioInicial) as InventarioInicial, sum(Recarga) as Recarga, sum(Devolucion) as Devolucion, sum(Rotacion) as Rotacion, ");
                sConsulta.AppendLine("  sum(Promocion) as Promocion, sum(DevDescAlmacen) as DevDescAlmacen, sum(t1.Venta) as Venta, sum(RecargaDiaSig) as RecargaDiaSig, ");
                sConsulta.AppendLine("  sum(ImporteVenta) as ImporteVenta, sum(ImporteDevolucion) as ImporteDevolucion, sum(ImporteRotacion) as ImporteRotacion ");
                sConsulta.AppendLine("  from ( ");
                sConsulta.AppendLine("      select t.ProductoClave, ");
                sConsulta.AppendLine("      case when t.Tipo = 23 or(t.Tipo = 2 and t.PrimerCarga = 1) then t.Cantidad else 0 end as InventarioInicial, "); 
                sConsulta.AppendLine("      case when t.Tipo = 2 and t.PrimerCarga = 0 and t.RecargaDiaSig = 0 then t.Cantidad else 0 end as Recarga, ");
                sConsulta.AppendLine("      case when t.Tipo = 3 and t.MotivoVenta = 0 then t.Cantidad else 0 end as Devolucion, ");
                sConsulta.AppendLine("      case when t.Tipo = 3 and t.MotivoVenta = 1 then t.Cantidad else 0 end as Rotacion, ");
                sConsulta.AppendLine("      case when t.Tipo = 1 and t.Promocion = 2 then t.Cantidad else 0 end as Promocion, ");
                sConsulta.AppendLine("      case when t.Tipo in (4, 7) then t.Cantidad else 0 end as DevDescAlmacen, ");
                sConsulta.AppendLine("      case when t.Tipo = 1 and t.Promocion <> 2 then t.Cantidad else 0 end as Venta, ");
                sConsulta.AppendLine("      case when t.Tipo = 2 and t.RecargaDiaSig = 1 then t.Cantidad else 0 end as RecargaDiaSig, ");
                sConsulta.AppendLine("      case when t.Tipo = 1 and t.Promocion <> 2 then t.Venta else 0 end as ImporteVenta, ");
                sConsulta.AppendLine("      case when t.Tipo in (4, 7) then t.Devolucion else 0 end as ImporteDevolucion, ");
                sConsulta.AppendLine("      case when t.Tipo = 3 and t.MotivoVenta = 1 then t.Rotacion else 0 end as ImporteRotacion ");
                sConsulta.AppendLine("      from ( ");
                sConsulta.AppendLine("          --Inventario a bordo ");
                sConsulta.AppendLine("          select TRP.Tipo, TPD.ProductoClave, TPD.Cantidad, 0 as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as Promocion, 0 as Venta, 0 as Devolucion, 0 as Rotacion  ");
                sConsulta.AppendLine("          from TransProd TRP ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          where TRP.TransProdID = @IdInvBordo ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Primer carga y Recarga "); 
                sConsulta.AppendLine("          select TRP.Tipo, TPD.ProductoClave, TPD.Cantidad, case when TRP.TransProdID = @IdPrimerCarga then 1 else 0 end as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as Promocion, 0 as Venta, 0 as Devolucion, 0 as Rotacion  ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Recarga dia siguiente ");
                sConsulta.AppendLine("          select TRP.Tipo, TPD.ProductoClave, TPD.Cantidad, 0 as PrimerCarga, 1 as RecargaDiaSig, 0 as MotivoVenta, 0 as Promocion, 0 as Venta, 0 as Devolucion, 0 as Rotacion  ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          where TRP.TransProdId = @IdRegargaDiaSig ");
                //sConsulta.AppendLine("          inner join Dia on TRP.DiaClave = Dia.DiaClave ");
                //sConsulta.AppendLine("          where TRP.Tipo = 2 and TRP.TipoFase <> 0 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = dateadd(day, 1, @Fecha) ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Devolucion y Descarga al almacen ");
                sConsulta.AppendLine("          select TRP.Tipo, TPD.ProductoClave, TPD.Cantidad, 0 as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, 0 as Promocion, 0 as Venta, TPD.Total as Devolucion, 0 as Rotacion  ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on TRP.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          where TRP.Tipo in (4, 7) and TRP.TipoFase = 1 and TRP.MUsuarioID = @UsuarioID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Devolucion de cliente ");
                sConsulta.AppendLine("          select TRP.Tipo, TPD.ProductoClave, TPD.Cantidad, 0 as PrimerCarga, 0 as RecargaDiaSig, case when upper(VAV.Grupo) = 'VENTA' then 1 else 0 end as MotivoVenta, 0 as Promocion, 0 as Venta, 0 as Devolucion, case when upper(VAV.Grupo) = 'VENTA' then TPD.Total else 0 end as Rotacion ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave ");
                sConsulta.AppendLine("          inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          inner join VARValor VAV (NOLOCK) on VAV.VARCodigo = 'TRPMOT' and VAV.VAVClave = TPD.TipoMotivo ");
                sConsulta.AppendLine("          where TRP.Tipo = 3 and TRP.TipoFase = 1 and VIS.VendedorID = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          union all ");
                sConsulta.AppendLine("          --Venta y Promocion ");
                sConsulta.AppendLine("          select TRP.Tipo, TPD.ProductoClave, TPD.Cantidad, 0 as PrimerCarga, 0 as RecargaDiaSig, 0 as MotivoVenta, isnull(TPD.Promocion, 0) as Promocion, TPD.Total as Venta, 0 as Devolucion, 0 as Rotacion  ");
                sConsulta.AppendLine("          from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("          inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdID = TPD.TransProdID ");
                sConsulta.AppendLine("          inner join Visita VIS (NOLOCK) on TRP.VisitaClave = VIS.VisitaClave and TRP.DiaClave = VIS.DiaClave ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          where TRP.Tipo = 1 and TRP.TipoFase = 2 and VIS.VendedorID = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("      )as t ");
                sConsulta.AppendLine("  )as t1 ");
                sConsulta.AppendLine("  group by t1.ProductoClave ");
                sConsulta.AppendLine(")as t2 ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on t2.ProductoClave = PRO.ProductoClave ");                 

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();
                Connection.Open();
                List<DetalleLiqRIKModel> Detalle = Connection.Query<DetalleLiqRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                sConsulta.Clear();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");

                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");

                sConsulta.AppendLine("set @Fecha = '" + dFechaFiltro.ToString("s") + "' ");
                sConsulta.AppendLine("set @VendedorID = " + VendedorID + " ");

                sConsulta.AppendLine("select sum(ClientesProgramados) as ClientesProgramados, sum(ClientesVisitados) as ClientesVisitados, sum(ClientesConCompra) as ClientesConCompra, ");
                sConsulta.AppendLine("case when sum(ClientesProgramados) > 0 then round((convert(float,sum(ClientesVisitados))/convert(float,sum(ClientesProgramados))) * 100, 2) else 0 end as EfectividadDeVisita, ");
                sConsulta.AppendLine("case when sum(ClientesVisitados) > 0 then round((convert(float, sum(ClientesConCompra)) / convert(float, sum(ClientesVisitados))) * 100, 2) else 0 end as EfectividadDeCompra, ");
                sConsulta.AppendLine("convert(varchar(8), convert(time, dateadd(ms, sum(TiempoDeServicio) * 1000, 0))) as TiempoDeServicio, ");
                sConsulta.AppendLine("convert(varchar(8), convert(time, dateadd(ms, sum(TiempoDeJornada - TiempoDeServicio) * 1000, 0))) as TiempoDeTraslado ");
                sConsulta.AppendLine("from( ");
                sConsulta.AppendLine("  --Clientes programados ");
                sConsulta.AppendLine("  select count(distinct(ClienteClave)) as ClientesProgramados, 0 as ClientesVisitados, 0 as ClientesConCompra, 0 as TiempoDeServicio, 0 as TiempoDeJornada ");
                sConsulta.AppendLine("  from AgendaVendedor AGV (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on AGV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where AGV.VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("  union all ");
                sConsulta.AppendLine("  --Clientes visitados, con compra y tiempo de servicio ");
                sConsulta.AppendLine("  select 0 as ClientesProgramados, count(distinct(ClienteClave)) as ClientesVisitados, count(distinct(ClienteConCompra)) as ClientesConCompra, ");
                sConsulta.AppendLine("  sum(datediff(second, FechaHoraInicial, FechaHoraFinal)) as TiempoDeServicio, 0 as TiempoDeJornada ");
                sConsulta.AppendLine("  from( ");
                sConsulta.AppendLine("      select ClienteClave, FechaHoraInicial, FechaHoraFinal, case when Compra > 0 then ClienteClave else null end as ClienteConCompra ");
                sConsulta.AppendLine("      from( ");
                sConsulta.AppendLine("          select VIS.ClienteClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal, count(distinct(TRP.TransProdID)) as Compra ");
                sConsulta.AppendLine("          from Visita VIS (NOLOCK) ");
                sConsulta.AppendLine("          inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("          left join TransProd TRP (NOLOCK) on VIS.VisitaClave = TRP.VisitaClave and VIS.DiaClave = TRP.DiaClave and TRP.Tipo = 1 and TRP.TipoFase = 2 ");
                sConsulta.AppendLine("          where VIS.VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine("          group by VIS.ClienteClave, VIS.FechaHoraInicial, VIS.FechaHoraFinal ");
                sConsulta.AppendLine("      ) as t ");
                sConsulta.AppendLine("  ) as t1 ");
                sConsulta.AppendLine("  union all ");
                sConsulta.AppendLine("  --Tiempo de jornada ");
                sConsulta.AppendLine("  select 0 as ClientesProgramados, 0 as ClientesVisitados, 0 as ClientesConCompra, 0 as TiempoDeServicio, ");
                sConsulta.AppendLine("  sum(datediff(second, VEJFechaInicial, FechaFinal)) as TiempoDeJornada ");
                sConsulta.AppendLine("  from VendedorJornada VEJ (NOLOCK) ");
                sConsulta.AppendLine("  inner join Dia (NOLOCK) on VEJ.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("  where VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");
                sConsulta.AppendLine(") as t2 ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();
                Connection.Open();
                List<TotalesJornadaLiqRIKModel> TotalesJornada = Connection.Query<TotalesJornadaLiqRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                sConsulta.Clear();

                sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
                sConsulta.AppendLine("SET NOCOUNT ON ");

                sConsulta.AppendLine("declare @Fecha as datetime ");
                sConsulta.AppendLine("declare @VendedorID as varchar(16) ");

                sConsulta.AppendLine("set @Fecha = '" + dFechaFiltro.ToString("s") + "' ");
                sConsulta.AppendLine("set @VendedorID = " + VendedorID + " ");

                sConsulta.AppendLine("select top 1 CMV.Placa, CAM.Clave, CMV.KmInicial, CMV.KmFinal, (CMV.KmFinal - CMV.KmInicial) as Recorrido ");
                sConsulta.AppendLine("from CamionVendedor CMV (NOLOCK) ");
                sConsulta.AppendLine("inner join Camion CAM (NOLOCK) on CMV.Placa = CAM.Placa ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on CMV.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("where VendedorId = @VendedorID and Dia.FechaCaptura = @Fecha ");

                sConsulta.AppendLine("SET NOCOUNT OFF ");

                QueryString = sConsulta.ToString();

                Connection.Open();
                List<CamionLiqRIKModel> Camion = Connection.Query<CamionLiqRIKModel>(QueryString, null, null, true, 9000).ToList();
                Connection.Close();

                if (Detalle.Count == 0 || TotalesJornada.Count == 0) // || Camion.Count == 0)
                    return false;
                else
                {
                    CamionLiqRIKModel oCamion;
                    if (Camion.Count == 0)
                    {
                        oCamion = new CamionLiqRIKModel();
                        oCamion.Clave = "";
                        oCamion.Placa = "";
                    }
                    else
                        oCamion = Camion[0];

                    string fileName = GenerarExcelDetallado(Detalle, TotalesJornada[0], oCamion);
                    DownloadFile.DownloadOpenXML(fileName);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //private Cell ConstructCell(string value, CellValues dataType)
        //{
        //    return new Cell()
        //    {
        //        CellValue = new CellValue(value),
        //        DataType = new EnumValue<CellValues>(dataType)
        //    };
        //}

        private string GenerarExcelGeneral(TotalesLiqRIKModel Totales, TotalesJornadaLiqRIKModel TotalesJornada, CamionLiqRIKModel Camion)
        {
            string path = ConfigurationManager.AppSettings.Get("pathReportes");
            string fileName = path + @"\Liquidacion_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Vista General" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(this.NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();                
                row.Append(MyOpenXML.ConstructCell(this.NombreReporte, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(this.Fecha, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                string sVendedor;
                try
                {
                    sVendedor = db.Vendedor.ToList().First(x => x.VendedorID == VendedorID && x.TipoEstado == 1).Nombre;
                }
                catch {
                    sVendedor = VendedorID;
                }
                 
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVendedor", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sVendedor, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();                
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInventarioIni", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRecarga", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevolucion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRotacion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPromocion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevDescAlmacen", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVenta", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRecargaDiaSig", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInventarioFinal", "EM"), CellValues.String));                   
                sheetData.AppendChild(row);                

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Totales.InventarioInicial.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.Recarga.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.Devolucion.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.Rotacion.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.Promocion.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.DevDescAlmacen.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.Venta.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.RecargaDiaSig.ToString("C", CultureInfo.CurrentCulture), CellValues.String),
                        MyOpenXML.ConstructCell(Totales.InventarioFinal.ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClientesProgramados", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.ClientesProgramados.ToString(), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClientesVisitados", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.ClientesVisitados.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XEfectividadVisita", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.EfectividadDeVisita.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("xTiempoTraslado", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.TiempoDeTraslado, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClientesConCompra", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.ClientesConCompra.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XEfectividaddeCompra", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.EfectividadDeCompra.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTiempoServicioVisita", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.TiempoDeServicio, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XEconomico", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPlaca", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInicial", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFinal", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("xRecorrido", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Camion.Clave, CellValues.String),
                        MyOpenXML.ConstructCell(Camion.Placa, CellValues.String),
                        MyOpenXML.ConstructCell(Camion.KmInicial.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Camion.KmFinal.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Camion.Recorrido.ToString(), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XMLiquidacion", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XSubtotal", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(Totales.Venta.ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevolucionesAlmacen", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell((Totales.Rotacion + Totales.DevDescAlmacen).ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotalALiquidar", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell((Totales.Venta - (Totales.Rotacion + Totales.DevDescAlmacen)).ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                worksheetPart.Worksheet.Save();                

            }//using
            return fileName;
        }//GenerarExcel

        private string GenerarExcelDetallado(List<DetalleLiqRIKModel> Detalle, TotalesJornadaLiqRIKModel TotalesJornada, CamionLiqRIKModel Camion)
        {
            string path = ConfigurationManager.AppSettings.Get("pathReportes");
            string fileName = path + @"\Liquidacion_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Vista Detallada" };
                sheets.Append(sheet);
                workbookPart.Workbook.Save();

                RouteEntities db = new RouteEntities();
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();
                row.Append(MyOpenXML.ConstructCell(((Configuracion)db.Configuracion.First()).NombreEmpresa, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(MyOpenXML.ConstructCell(ValorReferencia.ObtenerDescripcion("REPORTEW", "201", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFecha", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(this.Fecha, CellValues.String));
                sheetData.AppendChild(row);
                
                string sVendedor;
                try
                {
                    sVendedor = db.Vendedor.ToList().First(x => x.VendedorID == VendedorID && x.TipoEstado == 1).Nombre;
                }
                catch
                {
                    sVendedor = VendedorID;
                }

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVendedor", "EM"), CellValues.String),
                    MyOpenXML.ConstructCell(sVendedor, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                    MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVentasporProducto", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClave", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDescripcion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInventarioIni", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRecarga", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevolucion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRotacion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPromocion", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevDescAlmacen", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XVenta", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XRecargaDiaSig", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInventarioFinal", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XImporteVenta", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                foreach (DetalleLiqRIKModel detalle in Detalle)
                {
                    row = new Row();
                    row.Append(
                            MyOpenXML.ConstructCell(detalle.ProductoClave, CellValues.String),
                            MyOpenXML.ConstructCell(detalle.Nombre, CellValues.String),
                            MyOpenXML.ConstructCell(detalle.InventarioInicial.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.Recarga.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.Devolucion.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.Rotacion.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.Promocion.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.DevDescAlmacen.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.Venta.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.RecargaDiaSig.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.InventarioFinal.ToString(), CellValues.String),
                            MyOpenXML.ConstructCell(detalle.ImporteVenta.ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                    sheetData.AppendChild(row);
                }

                row = new Row();
                sheetData.AppendChild(row);

                float nVenta = Detalle.Sum(x => x.ImporteVenta);
                float nDevolucion = Detalle.Sum(x => x.ImporteDevolucion);
                float nRotacion = Detalle.Sum(x => x.ImporteRotacion);

                //XTotalVtasProd
                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotalVtasProd", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(nVenta.ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClientesProgramados", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.ClientesProgramados.ToString(), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClientesVisitados", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.ClientesVisitados.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XEfectividadVisita", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.EfectividadDeVisita.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("xTiempoTraslado", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.TiempoDeTraslado, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XClientesConCompra", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.ClientesConCompra.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XEfectividaddeCompra", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.EfectividadDeCompra.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTiempoServicioVisita", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(TotalesJornada.TiempoDeServicio, CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XEconomico", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XPlaca", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XInicial", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XFinal", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("xRecorrido", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Camion.Clave, CellValues.String),
                        MyOpenXML.ConstructCell(Camion.Placa, CellValues.String),
                        MyOpenXML.ConstructCell(Camion.KmInicial.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Camion.KmFinal.ToString(), CellValues.String),
                        MyOpenXML.ConstructCell(Camion.Recorrido.ToString(), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XMLiquidacion", "EM"), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                sheetData.AppendChild(row);                

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XSubtotal", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell(nVenta.ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XDevolucionesAlmacen", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell((nRotacion + nDevolucion).ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                row = new Row();
                row.Append(
                        MyOpenXML.ConstructCell(Mensaje.ObtenerDescripcion("XTotalALiquidar", "EM"), CellValues.String),
                        MyOpenXML.ConstructCell("", CellValues.String),
                        MyOpenXML.ConstructCell((nVenta - (nRotacion + nDevolucion)).ToString("C", CultureInfo.CurrentCulture), CellValues.String));
                sheetData.AppendChild(row);

                worksheetPart.Worksheet.Save();

            }//using
            return fileName;
        }//GenerarExcel

    }

    class TotalesLiqRIKModel
    {
        public float InventarioInicial { get; set; }
        public float Recarga { get; set; }
        public float Devolucion { get; set; }
        public float Rotacion { get; set; }
        public float Promocion { get; set; }
        public float DevDescAlmacen { get; set; }
        public float Venta { get; set; }
        public float RecargaDiaSig { get; set; }
        public float InventarioFinal { get; set; }
    }

    class TotalesJornadaLiqRIKModel
    {
        public long ClientesProgramados { get; set; }
        public long ClientesVisitados { get; set; }
        public long ClientesConCompra { get; set; }
        public float EfectividadDeVisita { get; set; }
        public float EfectividadDeCompra { get; set; }
        public string TiempoDeServicio { get; set; }
        public string TiempoDeTraslado { get; set; }
    }

    class CamionLiqRIKModel
    {
        public string Placa { get; set; }
        public string Clave { get; set; }
        public long KmInicial { get; set; }
        public long KmFinal { get; set; }
        public long Recorrido { get; set; }
    }

    class DetalleLiqRIKModel
    {
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public long InventarioInicial { get; set; }
        public long Recarga { get; set; }
        public long Devolucion { get; set; }
        public long Rotacion { get; set; }
        public long Promocion { get; set; }
        public long DevDescAlmacen { get; set; }
        public long Venta { get; set; }
        public long RecargaDiaSig { get; set; }
        public long InventarioFinal { get; set; }
        public float ImporteVenta { get; set; }
        public float ImporteDevolucion { get; set; }
        public float ImporteRotacion { get; set; }
    }
}