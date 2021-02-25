using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Drawing;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace eRoute.Models.ReportesModels
{
    public class CierreDeDiaGrupoMOR
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";

        public ArchivoXlsModel GetReport(int VAVClave, string nombreReport, string nombreCedis, string pvCondicion, string FechaInicial, string FechaFinal, string Cedis, string unidadMedida)
        {
            try
            {
                DateTime sFecha = Convert.ToDateTime(FechaInicial);
                DateTime sFechaFin = Convert.ToDateTime(FechaFinal);

                DateTime dFechaIni = new DateTime(sFecha.Year, sFecha.Month, sFecha.Day);
                DateTime dFechaIniIni = new DateTime(sFecha.Year, sFecha.Month, 1);
                DateTime dFechaFin = new DateTime(sFechaFin.Year, sFechaFin.Month, sFechaFin.Day);

                //Fecha Total LY
                DateTime dFechaIniLYini = new DateTime(sFecha.Year - 1, sFecha.Month, 1);
                DateTime dFechaIniLYfin = new DateTime(sFecha.Year - 1, sFecha.Month, sFecha.Day);
                DateTime dFechaFinLY = new DateTime(dFechaIni.Year - 1, dFechaIni.Month, DateTime.DaysInMonth(dFechaIni.Year - 1, dFechaIni.Month));
                String sFechaTotalLY = "convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) between '" + dFechaIniLYini.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' and '" + dFechaFinLY.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'";

                //Fecha Dia a Dia LY                        
                String sFechaDiaDiaLY = "convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) between '" + dFechaIniLYini.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' and '" + dFechaIniLYfin.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'";

                //Fecha Dia a Dia              
                String sFechaDiaDia = "convert(datetime,Convert(varchar(20),Dia.FechaCaptura,112)) between '" + dFechaIniIni.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "' and '" + dFechaIni.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "'";

                bool ExisteOrdenProductos = ordenProductos(VAVClave);
                StringBuilder sConsulta = new StringBuilder();
                sConsulta.AppendLine("select tt.ALMClave, tt.ALMNombre, tt.OrdenEsquema, tt.ClaveEsquema, tt.NombreEsquema, tt.SAP, tt.ProductoClave, tt.Nombre, tt.Marca, tt.Cupo, isnull((select ISNULL(FN.BuenEstadoFin+FN.MalEstadoFin,0) FROM dbo.fn_HistoricoInventario (tt.AlmacenId, tt.ProductoClave,'" + dFechaIni.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss") + "') FN),0) as TotalInventario, sum(tt.TotalLY) as TotalLY, sum(tt.DiaDiaLY) as DiaDiaLY, sum(tt.DiaDia) as DiaDia");
                sConsulta.AppendLine("from (");
                sConsulta.AppendLine("select ALM.AlmacenID,");
                sConsulta.AppendLine("ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre,  ");
                sConsulta.AppendLine("E.Orden as OrdenEsquema,   ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema,   ");
                sConsulta.AppendLine("E.Nombre as NombreEsquema,  ");
                sConsulta.AppendLine("PRO.Id as SAP,  ");
                sConsulta.AppendLine("TPD.ProductoClave,   ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("(select top 1 EM.Nombre from ProductoEsquema PEM (NOLOCK) inner join Esquema EM (NOLOCK) on PEM.EsquemaID=EM.EsquemaID and E.TipoEstado=1 and EM.EsquemaIDPadre in (select E9.EsquemaID from Esquema E9 (NOLOCK) where E9.Tipo=2 and E9.TipoEstado=1 and E9.Clave='MAR') where PEM.ProductoClave=TPD.ProductoClave) as Marca,");
                sConsulta.AppendLine("(select top 1 EM.Nombre from ProductoEsquema PEM (NOLOCK) inner join Esquema EM (NOLOCK) on PEM.EsquemaID=EM.EsquemaID and E.TipoEstado=1 and EM.EsquemaIDPadre in (select E9.EsquemaID from Esquema E9 (NOLOCK) where E9.Tipo=2 and E9.TipoEstado=1 and E9.Clave='CUP') where PEM.ProductoClave=TPD.ProductoClave) as Cupo,");
                sConsulta.AppendLine("0 as TotalInventario");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PRD.Factor) as TotalLY, ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as TotalLY, ");
                sConsulta.AppendLine("0 as DiaDiaLY,");
                sConsulta.AppendLine("0 as DiaDia");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia on (NOLOCK) VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaTotalLY + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, E.Orden, E.Clave, E.Nombre, PRO.Id, TPD.ProductoClave, PRO.Nombre, E.TipoEstado, OP.Orden ");
                else
                    sConsulta.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, E.Orden, E.Clave, E.Nombre, PRO.Id, TPD.ProductoClave, PRO.Nombre, E.TipoEstado ");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select ALM.AlmacenID,");
                sConsulta.AppendLine("ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre,  ");
                sConsulta.AppendLine("E.Orden as OrdenEsquema,   ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema,   ");
                sConsulta.AppendLine("E.Nombre as NombreEsquema,  ");
                sConsulta.AppendLine("PRO.Id as SAP,  ");
                sConsulta.AppendLine("TPD.ProductoClave,   ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("(select top 1 EM.Nombre from ProductoEsquema PEM (NOLOCK) inner join Esquema EM (NOLOCK) on PEM.EsquemaID=EM.EsquemaID and E.TipoEstado=1 and EM.EsquemaIDPadre in (select E9.EsquemaID from Esquema E9 (NOLOCK) where E9.Tipo=2 and E9.TipoEstado=1 and E9.Clave='MAR') where PEM.ProductoClave=TPD.ProductoClave) as Marca,");
                sConsulta.AppendLine("(select top 1 EM.Nombre from ProductoEsquema PEM (NOLOCK) inner join Esquema EM (NOLOCK) on PEM.EsquemaID=EM.EsquemaID and E.TipoEstado=1 and EM.EsquemaIDPadre in (select E9.EsquemaID from Esquema E9 (NOLOCK) where E9.Tipo=2 and E9.TipoEstado=1 and E9.Clave='CUP') where PEM.ProductoClave=TPD.ProductoClave) as Cupo,");
                sConsulta.AppendLine("0 as TotalInventario,");
                sConsulta.AppendLine("0 as TotalLY");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PRD.Factor) as DiaDiaLY, ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as DiaDiaLY, ");
                sConsulta.AppendLine("0 as DiaDia");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                   sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaDiaDiaLY + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, E.Orden, E.Clave, E.Nombre, PRO.Id, TPD.ProductoClave, PRO.Nombre, E.TipoEstado, OP.Orden");
                else
                    sConsulta.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, E.Orden, E.Clave, E.Nombre, PRO.Id, TPD.ProductoClave, PRO.Nombre, E.TipoEstado");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("union all");
                sConsulta.AppendLine("");
                sConsulta.AppendLine("select ALM.AlmacenID,");
                sConsulta.AppendLine("ALM.Clave as ALMClave, ");
                sConsulta.AppendLine("ALM.Nombre as ALMNombre,  ");
                sConsulta.AppendLine("E.Orden as OrdenEsquema,   ");
                sConsulta.AppendLine("E.Clave as ClaveEsquema,   ");
                sConsulta.AppendLine("E.Nombre as NombreEsquema,  ");
                sConsulta.AppendLine("PRO.Id as SAP,  ");
                sConsulta.AppendLine("TPD.ProductoClave,   ");
                sConsulta.AppendLine("PRO.Nombre,  ");
                sConsulta.AppendLine("(select top 1 EM.Nombre from ProductoEsquema PEM (NOLOCK) inner join Esquema EM (NOLOCK) on PEM.EsquemaID=EM.EsquemaID and E.TipoEstado=1 and EM.EsquemaIDPadre in (select E9.EsquemaID from Esquema E9 (NOLOCK) where E9.Tipo=2 and E9.TipoEstado=1 and E9.Clave='MAR') where PEM.ProductoClave=TPD.ProductoClave) as Marca,");
                sConsulta.AppendLine("(select top 1 EM.Nombre from ProductoEsquema PEM (NOLOCK) inner join Esquema EM (NOLOCK) on PEM.EsquemaID=EM.EsquemaID and E.TipoEstado=1 and EM.EsquemaIDPadre in (select E9.EsquemaID from Esquema E9 (NOLOCK) where E9.Tipo=2 and E9.TipoEstado=1 and E9.Clave='CUP') where PEM.ProductoClave=TPD.ProductoClave) as Cupo,");
                sConsulta.AppendLine("0 as TotalInventario,");
                sConsulta.AppendLine("0 as TotalLY,");
                sConsulta.AppendLine("0 as DiaDiaLY");
                if (unidadMedida == "Cartones")
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PRD.Factor) as DiaDia ");
                else
                    sConsulta.AppendLine(", SUM(TPD.Cantidad * PU.Volumen) as DiaDia ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine(",OP.Orden as OrdenProductos");
                sConsulta.AppendLine("from TransProd TRP (NOLOCK) ");
                sConsulta.AppendLine("inner join TransProdDetalle TPD (NOLOCK) on TRP.TransProdId=TPD.TransProdId ");
                sConsulta.AppendLine("inner join Visita VIS (NOLOCK) on isnull(TRP.VisitaClave1,TRP.VisitaClave)=VIS.VisitaClave and isnull(TRP.DiaClave1,TRP.DiaClave)=VIS.DiaClave ");
                sConsulta.AppendLine("inner join Dia (NOLOCK) on VIS.DiaClave = Dia.DiaClave ");
                sConsulta.AppendLine("inner join Producto PRO (NOLOCK) on TPD.ProductoClave = PRO.ProductoClave and PRO.Contenido=0 and Pro.Venta=0");
                sConsulta.AppendLine("inner join ProductoUnidad PU (NOLOCK) on TPD.ProductoClave=PU.ProductoClave and TPD.TipoUnidad=PU.PRUTipoUnidad  ");
                sConsulta.AppendLine("inner join ProductoDetalle PRD (NOLOCK) on TPD.ProductoClave=PRD.ProductoClave and PRD.ProductoClave=PRD.ProductoDetClave and TPD.TipoUnidad=PRD.PRUTipoUnidad ");
                sConsulta.AppendLine("inner join VENCentroDistHist CEDI (NOLOCK) ON CEDI.VendedorId = VIS.VendedorID AND Dia.FechaCaptura BETWEEN CEDI.VCHFechaInicial AND CEDI.FechaFinal");
                sConsulta.AppendLine("inner join Almacen ALM (NOLOCK) on CEDI.AlmacenId = ALM.AlmacenID ");
                sConsulta.AppendLine("inner join ProductoEsquema PE (NOLOCK) on PRO.ProductoClave=PE.ProductoClave and PE.EsquemaID in (select E2.EsquemaID from Esquema E2 (NOLOCK) where E2.EsquemaIDPadre in (select EsquemaID from Esquema E1 (NOLOCK) where E1.Tipo=2 and E1.TipoEstado=1 and E1.Clave='SEC')) ");
                sConsulta.AppendLine("inner join Esquema E (NOLOCK) on PE.EsquemaID=E.EsquemaID ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("inner join OrdenProductos OP (NOLOCK) on TPD.ProductoClave=OP.ProductoClave and OP.ReporteW='" + VAVClave + "'");
                sConsulta.AppendLine(pvCondicion);
                sConsulta.AppendLine("and ( " + sFechaDiaDia + " )");
                sConsulta.AppendLine("and  (TRP.Tipo = 1 and TRP.TipoFase in (2,3) and TPD.Promocion<>2) ");
                if (ExisteOrdenProductos)
                    sConsulta.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, E.Orden, E.Clave, E.Nombre, PRO.Id, TPD.ProductoClave, PRO.Nombre, E.TipoEstado, OP.Orden ");
                else
                    sConsulta.AppendLine("group by ALM.AlmacenID, ALM.Clave, ALM.Nombre, E.Orden, E.Clave, E.Nombre, PRO.Id, TPD.ProductoClave, PRO.Nombre, E.TipoEstado ");
                sConsulta.AppendLine(") as tt ");
                if (ExisteOrdenProductos)
                {
                    sConsulta.AppendLine("group by tt.AlmacenId, tt.ALMClave, tt.ALMNombre, tt.OrdenEsquema, tt.NombreEsquema, tt.ClaveEsquema, tt.SAP, tt.ProductoClave, tt.Nombre, tt.Marca, tt.Cupo, tt.OrdenProductos ");
                    sConsulta.AppendLine("order by tt.OrdenProductos");
                }
                else
                {
                    sConsulta.AppendLine("group by tt.AlmacenId, tt.ALMClave, tt.ALMNombre, tt.OrdenEsquema, tt.NombreEsquema, tt.ClaveEsquema, tt.SAP, tt.ProductoClave, tt.Nombre, tt.Marca, tt.Cupo ");
                    sConsulta.AppendLine("order by tt.ALMClave, tt.OrdenEsquema");
                }
                QueryString = "";
                QueryString = sConsulta.ToString();


                List<CierreDeDiaGrupoMORModel> User = Connection.Query<CierreDeDiaGrupoMORModel>(QueryString, null, null, true, 600).ToList();


                if (User.Count() <= 0)
                {
                    return null;
                }


                var lista = (from c in User
                             select c).ToList();

                var s = (from gr in lista group gr by new { gr.ALMNombre, gr.NombreEsquema} into grupo select grupo);
                foreach(var grupo in s)
                {
                    grupo.Last().gTotalInventario = grupo.Sum(c => c.TotalInventario);
                    grupo.Last().gTotalLY = grupo.Sum(c => c.TotalLY);
                    grupo.Last().gDiaDiaLY = grupo.Sum(c => c.DiaDiaLY);
                    grupo.Last().gDiaDia = grupo.Sum(c => c.DiaDia);

                    if (grupo.FirstOrDefault().ClaveEsquema != "CE"&& grupo.FirstOrDefault().ClaveEsquema != "CB"&& grupo.FirstOrDefault().ClaveEsquema != "AG"&& grupo.FirstOrDefault().ClaveEsquema != "RE")
                    {
                        grupo.FirstOrDefault().NombreEsquema = "Otros Productos";
                    }
                }

                string empresaQuery = "select NombreEmpresa from Configuracion (NOLOCK) ";
                string nombreEmpresa = Connection.Query<string>(empresaQuery, null, null, true, 9000).FirstOrDefault();

                

                string filename = nombreReport+ DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")+".xlsx";
                MemoryStream ms = new MemoryStream();
                SpreadsheetDocument x1 = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook);
                WorkbookPart wbp = x1.AddWorkbookPart();
                WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
                Workbook wb = new Workbook();
                FileVersion fv = new FileVersion();
                fv.ApplicationName = "Microsoft Office Excel";
                Worksheet ws = new Worksheet();
                SheetData sd = new SheetData();


                Dictionary <int, Row> Rows = new Dictionary<int, Row>();

                createRow(1, ref Rows);

                createCell(1, ref Rows, "A1", CellValues.String, nombreEmpresa, false);

                createRow(2, ref Rows);
                createCell(2, ref Rows, "A2", CellValues.String, nombreReport, false);

                createRow(4, ref Rows);
                createCell(4, ref Rows, "A4", CellValues.String, "Agencia: "+ nombreCedis, false);

                createRow(5, ref Rows);
                createCell(5, ref Rows, "A5", CellValues.String, "Ventas al: " + sFecha.ToString("dd/MM/yyyy"), false);


                if(unidadMedida!= "Cartones")
                {
                    unidadMedida = "Hectolitraje";
                }
                createRow(6, ref Rows);
                createCell(6, ref Rows, "A6", CellValues.String, "Unidad: " + unidadMedida, false);

                createRow(8, ref Rows);
                createCell(8, ref Rows, "A8", CellValues.String, "TIPO", false);
                createCell(8, ref Rows, "B8", CellValues.String, "SECTOR", false);
                createCell(8, ref Rows, "C8", CellValues.String, "AGENCIA", false);
                createCell(8, ref Rows, "D8", CellValues.String, "SAP", false);
                createCell(8, ref Rows, "E8", CellValues.String, "DESCRIPCIÓN PRODUCTO", false);
                createCell(8, ref Rows, "F8", CellValues.String, "MARCA", false);
                createCell(8, ref Rows, "G8", CellValues.String, "CUPO", false);
                createCell(8, ref Rows, "H8", CellValues.String, "TOTAL INVENTARIO", false);
                createCell(8, ref Rows, "I8", CellValues.String, "VENTATOTAL LY", false);
                createCell(8, ref Rows, "J8", CellValues.String, "LY DÍA A DÍA " + dFechaIniLYini.Year, false);
                createCell(8, ref Rows, "K8", CellValues.String, "DÍA A DÍA " + dFechaIni.Year, false);

                int currentRow = 8;

                currentRow++;
                createRow(currentRow, ref Rows);
                createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, s.FirstOrDefault().FirstOrDefault().ALMNombre, false);

                foreach (var grupo in s)
                {
                    currentRow ++;
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "A" + currentRow, CellValues.String, grupo.FirstOrDefault().NombreEsquema, false);

                    foreach(var element in grupo)
                    {
                        currentRow++;
                        createRow(currentRow, ref Rows);
                        createCell(currentRow, ref Rows, "A" + currentRow, CellValues.Number, element.OrdenEsquema.ToString(), false);
                        createCell(currentRow, ref Rows, "B" + currentRow, CellValues.String, element.NombreEsquema.ToString(), false);
                        createCell(currentRow, ref Rows, "C" + currentRow, CellValues.String, element.ALMNombre.ToString(), false);
                        createCell(currentRow, ref Rows, "D" + currentRow, CellValues.Number, element.SAP.ToString(), false);
                        createCell(currentRow, ref Rows, "E" + currentRow, CellValues.String, element.Nombre.ToString(), false);
                        createCell(currentRow, ref Rows, "F" + currentRow, CellValues.String, element.Marca.ToString(), false);
                        createCell(currentRow, ref Rows, "G" + currentRow, CellValues.String, element.Cupo, false);
                        createCell(currentRow, ref Rows, "H" + currentRow, CellValues.String, element.TotalInventario.ToString("#,##0.00"), true);
                        createCell(currentRow, ref Rows, "I" + currentRow, CellValues.String, element.TotalLY.ToString("#,##0.00"), false);
                        createCell(currentRow, ref Rows, "J" + currentRow, CellValues.String, element.DiaDiaLY.ToString("#,##0.00"), false);
                        createCell(currentRow, ref Rows, "K" + currentRow, CellValues.String, element.DiaDia.ToString("#,##0.00"), false);
                        //createCell(currentRow, ref Rows, "H" + currentRow, CellValues.Number, element.TotalInventario.ToString().Replace(",", "."), true);
                        //createCell(currentRow, ref Rows, "I" + currentRow, CellValues.Number, element.TotalLY.ToString().Replace(",", "."), false);
                        //createCell(currentRow, ref Rows, "J" + currentRow, CellValues.Number, element.DiaDiaLY.ToString().Replace(",", "."), false);
                        //createCell(currentRow, ref Rows, "K" + currentRow, CellValues.Number, element.DiaDia.ToString().Replace(",", "."), false);
                    }
                    currentRow++;
                    createRow(currentRow, ref Rows);
                    createCell(currentRow, ref Rows, "G" + currentRow, CellValues.String, "TOTAL "+ grupo.FirstOrDefault().NombreEsquema, false);
                    createCell(currentRow, ref Rows, "H" + currentRow, CellValues.String, grupo.Last().gTotalInventario.ToString("#,##0.00"), false);
                    createCell(currentRow, ref Rows, "I" + currentRow, CellValues.String, grupo.Last().gTotalLY.ToString("#,##0.00"), false);
                    createCell(currentRow, ref Rows, "J" + currentRow, CellValues.String, grupo.Last().gDiaDiaLY.ToString("#,##0.00"), false);
                    createCell(currentRow, ref Rows, "K" + currentRow, CellValues.String, grupo.Last().gDiaDia.ToString("#,##0.00"), false);
                    //createCell(currentRow, ref Rows, "K" + currentRow, CellValues.String, string.Format("{0:0.#####}", grupo.Last().gDiaDia));
                }

                foreach (var row in Rows)
                {
                    sd.Append(row.Value);
                }

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheets sheets = new Sheets();
                Sheet sheet = new Sheet();
                sheet.Name = nombreReport;
                sheet.SheetId = 1;
                sheet.Id = wbp.GetIdOfPart(wsp);
                sheets.Append(sheet);
                wb.Append(fv);
                wb.Append(sheets);

                x1.WorkbookPart.Workbook = wb;
                x1.WorkbookPart.Workbook.Save();
                x1.Close();

                ArchivoXlsModel archivo = new ArchivoXlsModel();
                archivo.archivo = ms.ToArray();
                archivo.nombre = filename;
                return archivo;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        bool ordenProductos(int VAVClave)
        {
            string query = "Select * from OrdenProductos (NOLOCK) where ReporteW = '" + VAVClave + "'";
            List<DataTable> resultado = Connection.Query<DataTable>(query, null, null, true, 9000).ToList();
            if (resultado.Count > 0)
            {
                return true;
            }
            return false;
        }

        void createRow(int id, ref Dictionary<int, Row> Rows)
        {
            Rows.Add(id, new Row() { RowIndex = (UInt32)id });
        }

        void createCell(int idRow,ref Dictionary<int, Row> Rows,  string cellReference, DocumentFormat.OpenXml.Spreadsheet.CellValues dt, string cellValue, bool formatNumber)
        {
            Cell cell = new Cell();
            cell.CellReference = cellReference;
            cell.DataType = dt;
            cell.CellValue = new CellValue(cellValue);
            if (Rows.ContainsKey(idRow))
            {
                Rows[idRow].Append(cell);
            }
        }
    }

    class CierreDeDiaGrupoMORModel
    {
        public string ALMClave { get; set; }     
        public string ALMNombre { get; set; }
        public long OrdenEsquema { get; set; }
        public string ClaveEsquema { get; set; }
        public string NombreEsquema { get; set; }
        public string SAP { get; set; }
        public string ProductoClave { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Cupo { get; set; }
        public long TotalInventario { get; set; }
        public Decimal TotalLY { get; set; }
        public Decimal DiaDiaLY { get; set; }
        public Decimal DiaDia { get; set; }
        public long gTotalInventario { get; set; }
        public Decimal gTotalLY { get; set; }
        public Decimal gDiaDiaLY { get; set; }
        public Decimal gDiaDia { get; set; }

    }
}