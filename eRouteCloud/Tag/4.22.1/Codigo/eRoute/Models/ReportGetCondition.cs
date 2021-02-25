using eRoute.Controllers.API;
using eRoute.Controllers.API.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace eRoute.Models
{
    public class ReportGetCondition
    {
        public ConditionModel Get(List<GetModel> Lotes, List<GetRoutesModel> Routes, List<Clients> Clientes, List<GetSellerModel> Seller, List<GetProductsModel> Products, List<GetProductsSchemeModel> ProductsSchema, string nombreReport = "", string Cedis = "", string nombreCedis = "", string dateStatus = "", string init = "", string end = "", int VAVClave = 0, bool reportType = false, string unidadMedida = "", string CENClave = "", string promocion = "", string Presupuesto = "", string NombreProductos = "")
        {

            ConditionModel condition = new ConditionModel();

            //int rutas = 0;
            //int clientes = 0;
            //int vend = 0;

            string queryList = String.Empty;

            try
            {
                queryList = GetDateQuery(dateStatus, init, end, true, "");
            }
            catch
            {
                queryList = String.Empty;
            }

            //vendedores

            if (Seller != null)
            {
                var checkedSellers = (from c in Seller
                                      where c.Checked == true
                                      select c).ToList();
                //vend = checkedSellers.Count();
                StringBuilder listSellers = new StringBuilder();
                foreach (var x in checkedSellers)
                {
                    if (x.Equals(checkedSellers.Last()))
                    {
                        listSellers.Append("'" + x.VendedorId + "'");
                    }
                    else
                    {
                        listSellers.Append("'" + x.VendedorId + "',");
                    }
                }

                string auxSl = listSellers.ToString();
                string[] SellerList = null;
                string cleanQuerySl = String.Empty;
                if (checkedSellers.Count() == 1)
                {
                    SellerList = auxSl.Split(',');
                }
                else
                {
                    SellerList = auxSl.Split(' ');
                }
                condition.Vendedor = SellerList.ElementAt(0);
            }
            else
            {
                condition.Vendedor = "";
            }
            //string sellerquery = String.Empty;
            //if (Seller != "Seller")
            //{
            //    sellerquery = Seller;
            //}


            //productos
            if (Products != null)
            {
                var checkedProducts = (from c in Products
                                       where c.Checked == true
                                       select c).ToList();
                //vend = checkedSellers.Count();
                StringBuilder listProducts = new StringBuilder();
                foreach (var x in checkedProducts)
                {
                    if (x.Equals(checkedProducts.Last()))
                    {
                        listProducts.Append("'" + x.Clave + "'");
                    }
                    else
                    {
                        listProducts.Append("'" + x.Clave + "',");
                    }
                }

                string auxPr = listProducts.ToString();
                string[] ProductsList = null;
                string cleanQueryPr = String.Empty;
                if (checkedProducts.Count() == 1)
                {
                    ProductsList = auxPr.Split(',');
                }
                else
                {
                    ProductsList = auxPr.Split(' ');
                }
                condition.Productos = ProductsList.ElementAt(0);
            }
            else
            {
                condition.Productos = "";
            }

            //nombre de productos
            if (Products != null)
            {
                //seleccionamos todos los productos que esten checados
                var checkedProducts = (from c in Products
                                       where c.Checked == true
                                       select c).ToList();
                //si no existe ningun producto checado, seleccionamos todos los productos (asi viene el flujo del antiguo reporteador)
                if (checkedProducts.Count() == 0)
                {
                    checkedProducts = (from c in Products select c).ToList();
                }

                StringBuilder listProducts = new StringBuilder();
                foreach (var x in checkedProducts)
                {
                    if (x.Equals(checkedProducts.Last()))
                    {
                        listProducts.Append(x.Nombre);
                    }
                    else
                    {
                        listProducts.Append(x.Nombre + ", ");
                    }
                }

                string auxPr = listProducts.ToString();
                condition.NombreProductos = auxPr;
            }
            else
            {
                condition.NombreProductos = "";
            }

            //nombre de productos Scheme
            if (ProductsSchema != null)
            {
                //seleccionamos todos los productos que esten checados
                var checkedProductsSchema = (from c in ProductsSchema
                                             where c.Checked == true
                                             select c).ToList();
                //si no existe ningun producto checado, seleccionamos todos los productos (asi viene el flujo del antiguo reporteador)
                if (checkedProductsSchema.Count() == 0)
                {
                    checkedProductsSchema = (from c in ProductsSchema select c).ToList();
                }

                StringBuilder listProductsSchema = new StringBuilder();
                foreach (var x in checkedProductsSchema)
                {
                    if (x.Equals(checkedProductsSchema.Last()))
                    {
                        listProductsSchema.Append("'" + x.Clave + "'");
                    }
                    else
                    {
                        listProductsSchema.Append("'" + x.Clave + "', ");
                    }
                }

                string auxPr = listProductsSchema.ToString();
                condition.ProductosScheme = auxPr;
            }
            else
            {
                condition.ProductosScheme = "";
            }

            //rutas
            if (Routes != null)
            {
                var checkedRoutes = (from d2 in Routes
                                     where d2.Checked == true
                                     select d2).ToList();

                //rutas = checkedRoutes.Count();
                StringBuilder list = new StringBuilder();
                foreach (var x in checkedRoutes)
                {
                    if (x.Equals(checkedRoutes.Last()))
                    {
                        list.Append("'" + x.RUTClave + "'");
                    }
                    else
                    {
                        list.Append("'" + x.RUTClave + "',");
                    }
                }

                string aux = list.ToString();
                string[] RouteList = null;
                string cleanQuery = String.Empty;
                if (checkedRoutes.Count() == 1)
                {
                    RouteList = aux.Split(',');
                }
                else
                {
                    RouteList = aux.Split(' ');
                }
                condition.Rutas = RouteList.ElementAt(0);
            }
            else
            {
                condition.Rutas = "";
            }

            //clientes
            if (Clientes != null)
            {
                var checkedClients = (from c in Clientes
                                      where c.Checked == true
                                      select c).ToList();

                //clientes = checkedClients.Count();
                StringBuilder listClients = new StringBuilder();
                foreach (var x in checkedClients)
                {
                    if (x.Equals(checkedClients.Last()))
                    {
                        listClients.Append("'" + x.Clave + "'");
                    }
                    else
                    {
                        listClients.Append("'" + x.Clave + "',");
                    }
                }

                string auxCl = listClients.ToString();
                string[] ClientList = null;
                string cleanQueryCl = String.Empty;
                if (checkedClients.Count() == 1)
                {
                    ClientList = auxCl.Split(',');
                }
                else
                {
                    ClientList = auxCl.Split(' ');
                }
                condition.Clientes = ClientList.ElementAt(0);

            }
            else
            {
                condition.Clientes = "";
            }

            //Lotes
            if (Lotes != null)
            {
                var checkedLotes = (from c in Lotes
                                      where c.Checked == true
                                      select c).ToList();
                StringBuilder listLotes = new StringBuilder();
                foreach (var x in checkedLotes)
                {
                    if (x.Equals(checkedLotes.Last()))
                    {
                        listLotes.Append("'" + x.Clave + "'");
                    }
                    else
                    {
                        listLotes.Append("'" + x.Clave + "',");
                    }
                }

                string auxLotes = listLotes.ToString();
                string[] LotesList = null;
                string cleanQueryCl = String.Empty;
                if (checkedLotes.Count() == 1)
                {
                    LotesList = auxLotes.Split(',');
                }
                else
                {
                    LotesList = auxLotes.Split(' ');
                }
                condition.Lotes = LotesList.ElementAt(0);

            }
            else
            {
                condition.Lotes = "";
            }

            //if (vend == 0 || rutas == 0 || clientes == 0)
            //{
            //    condition.Status = 400;
            //}

            //condition.Status = 200;

            condition.nombreReport = nombreReport;
            condition.Cedis = Cedis;
            condition.nombreCedis = nombreCedis;
            condition.Fechas = queryList;
            condition.VAVClave = VAVClave;
            condition.FechaInicial = init;
            if (dateStatus == "Entre")
                condition.FechaFinal = end;
            else
                condition.FechaFinal = "";
            condition.Rango = dateStatus;
            condition.reportType = reportType;
            condition.unidadMedida = unidadMedida;
            condition.CENClave = CENClave;
            condition.promocion = promocion;
            condition.Presupuesto = Presupuesto;
            condition.NombreProductos = NombreProductos;
            return condition;
        }

        public string Get(List<GetModel> Objeto, bool change = false)
        {
            if (Objeto.Count() != 0)
            {
                StringBuilder listObjeto = new StringBuilder();
                foreach (var x in Objeto)
                {
                    if (x.Equals(Objeto.Last()))
                    {
                        listObjeto.Append((change == true ? x.Nombre : x.Clave));
                    }
                    else
                    {
                        listObjeto.Append((change == true ? x.Nombre + "," : x.Clave) + ",");
                    }
                }
                return listObjeto.ToString();
            }
            return "";
        }

        public string BuildRutas(List<GetRoutesModel> Routes)
        {
            if (Routes == null)
            {
                Routes = new List<GetRoutesModel>();
            }
            var checkedRoutes = (from d2 in Routes
                                 where d2.Checked == true
                                 select d2).ToList();

            StringBuilder list = new StringBuilder();
            foreach (var x in checkedRoutes)
            {
                if (x.Equals(checkedRoutes.Last()))
                {
                    list.Append("'" + x.RUTClave.Replace("+", "%2B") + "'");
                }
                else
                {
                    list.Append("'" + x.RUTClave.Replace("+", "%2B") + "',");
                }
            }


            string aux = list.ToString();
            string[] RouteList = null;
            string cleanQuery = String.Empty;
            if (checkedRoutes.Count() == 1)
            {
                RouteList = aux.Split(',');
            }
            else
            {
                RouteList = aux.Split(' ');
            }

            return RouteList.ElementAt(0);
        }

        public string strWhereRutas(string Rutas, string CampoRuta)
        {
            if (String.IsNullOrEmpty(Rutas) || Rutas.Equals("null"))
            {
                return String.Empty;
            }
            else
            {
                return " and " + CampoRuta + " in (" + Rutas + ")";
            }
        }

        public string strWhereCedis(string Cedis, string CampoAlmacen)
        {
            if (Cedis != "")
            {
                return " and " + CampoAlmacen + " = '" + Cedis + "'";
            }
            else
            {
                return String.Empty;
            }
        }

        public string strWhereClientes(string Clientes, string CampoCliente)
        {
            if (String.IsNullOrEmpty(Clientes) || Clientes.Equals("null"))
            {
                return String.Empty;
            }
            else
            {
                return " and " + CampoCliente + " in (" + Clientes + ")";
            }
        }

        public string strWhereSupervisor(string Supervisor, string CampoSupervisor)
        {
            if (String.IsNullOrEmpty(Supervisor) || Supervisor.Equals("null"))
            {
                return String.Empty;
            }
            else
            {
                return " and " + CampoSupervisor + " in (" + Supervisor + ")";
            }
        }

        public string strWhereVendedores(string Vendedores, string CampoVendedores)
        {
            if (Vendedores != "")
            {
                return (" and " + CampoVendedores + " in (" + Vendedores + ")");
            }
            else
            {
                return String.Empty;
            }
        }

        public string strWhereEsquema(string Productos, string campoProductos)
        {
            if (String.IsNullOrEmpty(Productos) || Productos.Equals("null"))
            {
                return String.Empty;
            }
            else
            {
                return (" and " + campoProductos + " in (" + Productos + ")");
            }
        }

        public string strWherePromociones(string Promociones, string campoPromociones)
        {
            if (String.IsNullOrEmpty(Promociones) || Promociones.Equals("null"))
            {
                return String.Empty;
            }
            else
            {
                if (Promociones.Contains("Activas") && Promociones.Contains("Inactivas"))
                {
                    return " and " + campoPromociones + " in(1, 2)";
                }
                else if (Promociones.Contains("Activas"))
                {
                    return " and " + campoPromociones + " = 1";
                }
                else if (Promociones.Contains("Inactivas"))
                {
                    return " and " + campoPromociones + " = 2";
                }
                else
                {
                    return "";
                }
            }
        }

        public string GetDateQuery(string dateStatus, string InitDate, string EndDate, bool pvEsFecha, string CampoFecha)
        {
            DateTime init = DateTime.Parse(InitDate);
            string query = "";
            switch (dateStatus)
            {
                case "Igual":
                    if (pvEsFecha)
                    {
                        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112))='" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    }
                    else
                    {
                        query = " and " + CampoFecha + " between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + init.Date.ToString("yyyy-MM-ddT23:mm:ss") + "'";
                    }
                    break;
                //case "Diferente":
                //    if (pvEsFecha)
                //    {
                //        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) <>'" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }
                //    else
                //    {
                //        query = " and CONVERT(nvarchar(10)," + CampoFecha + ",126)+'T00:00:00' <> '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }

                //    break;
                //case "Mayor que":
                //    if (pvEsFecha)
                //    {
                //        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) > '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }
                //    else
                //    {
                //        query = " and CONVERT(nvarchar(10)," + CampoFecha + ",126)+'T00:00:00' > '" + init.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }

                //    break;
                //case "Menor que":
                //    if (pvEsFecha)
                //    {
                //        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) < '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }
                //    else
                //    {
                //        query = " and CONVERT(nvarchar(10)," + CampoFecha + ",126)+'T00:00:00' < '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }

                //    break;
                //case "Mayor o igual que":
                //    if (pvEsFecha)
                //    {
                //        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) >= '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }
                //    else
                //    {
                //        query = " and CONVERT(nvarchar(10)," + CampoFecha + ",126)+'T00:00:00' >= '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }

                //    break;
                //case "Menor o igual que":
                //    if (pvEsFecha)
                //    {
                //        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) <= '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }
                //    else
                //    {
                //        query = " and CONVERT(nvarchar(10)," + CampoFecha + ",126)+'T00:00:00' <= '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                //    }

                //    break;
                case "Entre":
                    if (pvEsFecha)
                    {
                        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + DateTime.Parse(EndDate).Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    }
                    else
                    {
                        query = " and " + CampoFecha + " between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + DateTime.Parse(EndDate).Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    }

                    break;

            }
            return query;
        }

        public string strWhereFechaAnioAnterior(string dateStatus, string InitDate, string EndDate, bool pvEsFecha, string CampoFecha)
        {
            DateTime init = DateTime.Parse(InitDate);
            init = init.AddYears(-1);
            string query = "";
            switch (dateStatus)
            {
                case "Igual":
                    if (pvEsFecha)
                    {
                        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112))='" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    }
                    else
                    {
                        query = " and " + CampoFecha + " between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + init.Date.ToString("yyyy-MM-ddT23:mm:ss") + "'";
                    }
                    break;
                case "Entre":
                    DateTime end = DateTime.Parse(EndDate);
                    end = end.AddYears(-1);
                    if (pvEsFecha)
                    {
                        query = " and convert(datetime,Convert(varchar(20)," + CampoFecha + ",112)) between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + end.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    }
                    else
                    {
                        query = " and " + CampoFecha + " between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + end.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    }

                    break;

            }
            return query;
        }

        public string GetDateSecondQuery(string dateStatus, string InitDate, string EndDate)
        {
            DateTime init = DateTime.Parse(InitDate);


            string query = "";
            switch (dateStatus)
            {
                case "Igual":
                    query = " and convert(datetime,Convert(varchar(20),FNG.Fecha,112))='" + init.Date.ToString("yyyy-MM-ddT23:mm:ss") + "'";
                    break;
                case "Diferente":
                    query = "and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' <> '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    break;
                case "Mayor que":
                    query = "and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' > '" + init.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    break;
                case "Menor que":
                    query = "and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' < '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    break;
                case "Mayor o igual que":
                    query = "and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' >= '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    break;
                case "Menor o igual que":
                    query = "and CONVERT(nvarchar(10),Dia.FechaCaptura,126)+'T00:00:00' <= '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    break;
                case "Entre":
                    query = "and Dia.FechaCaptura between '" + init.Date.ToString("yyyy-MM-ddTHH:mm:ss") + "' and '" + DateTime.Parse(EndDate).Date.ToString("yyyy-MM-ddTHH:mm:ss") + "'";
                    break;

            }
            return query;
        }

        public string strWhereFechaSinHoras(string dateStatus, string InitDate, string EndDate, bool pvEsFecha, string CampoFecha)
        {
            DateTime init = DateTime.Parse(InitDate);
            string query = "";
            switch (dateStatus)
            {
                case "Igual":
                    query = " and " + CampoFecha + " = '" + init.Date.ToString("s") + "' ";
                    break;
                case "Entre":
                    query = " and " + CampoFecha + " between '" + init.Date.ToString("s") + "' and '" + DateTime.Parse(EndDate).Date.ToString("s") + "' ";
                    break;
            }
            return query;
        }

        public string AllFilter(string valueString, dynamic value)
        {
            if (!(valueString == "undefined" || String.IsNullOrEmpty(valueString) || valueString == "null" || valueString == "" || valueString == " " || String.IsNullOrWhiteSpace(valueString)))
            {
                return valueString;
            }
            return value;
        }

        public string BuildCedis(List<GetCedisModelPro> LCedis = null, string Cedis = null)
        {
            if (Cedis != null)
            {
                return "'" + Cedis + "'";
            }
            if (LCedis == null)
            {
                LCedis = new List<GetCedisModelPro>();
            }
            var checkedCedis = (from d2 in LCedis
                                where d2.Checked == true
                                select d2).ToList();

            StringBuilder list = new StringBuilder();
            foreach (var x in checkedCedis)
            {
                if (x.Equals(checkedCedis.Last()))
                {
                    list.Append("'" + x.value.Replace("+", "%2B") + "'");
                }
                else
                {
                    list.Append("'" + x.value.Replace("+", "%2B") + "',");
                }
            }
            
            string aux = list.ToString();
            string[] CedisList = null;
            string cleanQuery = String.Empty;
            if (checkedCedis.Count() == 1)
            {
                CedisList = aux.Split(',');
            }
            else
            {
                CedisList = aux.Split(' ');
            }

            return CedisList.ElementAt(0);
        }

        public string BuildSellers(List<GetSellerModel> LSellers = null, string Sellers = null)
        {
            if (Sellers != null)
            {
                return "'" + Sellers + "'";
            }
            if (LSellers == null)
            {
                LSellers = new List<GetSellerModel>();
            }
            var checkedSellers = (from d2 in LSellers
                                where d2.Checked == true
                                select d2).ToList();

            StringBuilder list = new StringBuilder();
            foreach (var x in checkedSellers)
            {
                if (x.Equals(checkedSellers.Last()))
                {
                    list.Append("'" + x.VendedorId.Replace("+", "%2B") + "'");
                }
                else
                {
                    list.Append("'" + x.VendedorId.Replace("+", "%2B") + "',");
                }
            }
            
            string aux = list.ToString();
            string[] SellersList = null;
            string cleanQuery = String.Empty;
            if (checkedSellers.Count() == 1)
            {
                SellersList = aux.Split(',');
            }
            else
            {
                SellersList = aux.Split(' ');
            }

            return SellersList.ElementAt(0);
        }

        public string BuildClientScheme(List<ClientSchemaModel> LClientScheme = null, string ClientScheme = null)
        {
            if (ClientScheme != null)
            {
                return "'" + ClientScheme + "'";
            }
            if (LClientScheme == null)
            {
                LClientScheme = new List<ClientSchemaModel>();
            }
            var checkedClientScheme = (from d2 in LClientScheme
                                  where d2.Checked == true
                                  select d2).ToList();

            StringBuilder list = new StringBuilder();
            foreach (var x in checkedClientScheme)
            {
                if (x.Equals(checkedClientScheme.Last()))
                {
                    list.Append("'" + x.EsquemaID.Replace("+", "%2B") + "'");
                }
                else
                {
                    list.Append("'" + x.EsquemaID.Replace("+", "%2B") + "',");
                }
            }

            string aux = list.ToString();
            string[] ClientSchemeList = null;
            string cleanQuery = String.Empty;
            if (checkedClientScheme.Count() == 1)
            {
                ClientSchemeList = aux.Split(',');
            }
            else
            {
                ClientSchemeList = aux.Split(' ');
            }

            return ClientSchemeList.ElementAt(0);
        }

        public string BuildProductsScheme(List<GetProductsSchemeModel> LProductsScheme = null, string ProductsScheme = null)
        {
            if (ProductsScheme != null)
            {
                return "'" + ProductsScheme + "'";
            }
            if (LProductsScheme == null)
            {
                LProductsScheme = new List<GetProductsSchemeModel>();
            }
            var checkedProductsScheme = (from d2 in LProductsScheme
                                         where d2.Checked == true
                                       select d2).ToList();

            StringBuilder list = new StringBuilder();
            foreach (var x in checkedProductsScheme)
            {
                if (x.Equals(checkedProductsScheme.Last()))
                {
                    list.Append("'" + x.Clave.Replace("+", "%2B") + "'");
                }
                else
                {
                    list.Append("'" + x.Clave.Replace("+", "%2B") + "',");
                }
            }
            
            string aux = list.ToString();
            string[] ProductsSchemeList = null;
            string cleanQuery = String.Empty;
            if (checkedProductsScheme.Count() == 1)
            {
                ProductsSchemeList = aux.Split(',');
            }
            else
            {
                ProductsSchemeList = aux.Split(' ');
            }

            return ProductsSchemeList.ElementAt(0);
        }
    }

    public class ConditionModel
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public int VAVClave { get; set; }
        public string Rutas { get; set; }
        public string Clientes { get; set; }
        public string Productos { get; set; }
        public string NombreProductos { get; set; }
        public string ProductosScheme { get; set; }
        public string nombreReport { get; set; }
        public string Cedis { get; set; }
        public string nombreCedis { get; set; }
        public string Vendedor { get; set; }
        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public string Rango { get; set; }
        public string Fechas { get; set; }
        public bool reportType { get; set; }
        public string unidadMedida { get; set; }
        public string CENClave { get; set; }
        public string promocion { get; set; }
        public string Presupuesto { get; set; }
        public string Lotes { get; set; }
    }

    public class ArchivoXlsModel
    {
        public byte[] archivo { get; set; }
        public string nombre { get; set; }
    }
}