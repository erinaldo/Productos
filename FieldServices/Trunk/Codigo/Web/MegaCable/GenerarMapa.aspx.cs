using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using System.Data;
using System.Collections;
using Subgurim.Controles;
using System.Drawing;

public partial class GenerarMapa : System.Web.UI.Page, IGenerarReporte
{
    [System.Web.Services.WebMethod]
    public static void DescargarMapas(string id)
    {
        HttpContext.Current.Session.Remove("Mapa" + id);
        HttpContext.Current.Session.Remove("Mapa" + id + "Detalle");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if ((Request["tipo"] != null) && (Request["tipo"] != ""))
            {
                DescargarMapas(Request["id"]);
                GenerarReportes control = new GenerarReportes();
                control.ConsultarReporte(Request["tipo"], Convert.ToDateTime(Request["f1"]), Convert.ToDateTime(Request["f2"]), this);
                UtilEtiquetas.CargarEtiquetas(this);

                CargaControlesMapa();
                GMap1.enableHookMouseWheelToZoom = true;
                GMap1.setCenter(new GLatLng(20.650878, -103.367377), 10);

                if (Request["tipo"] == "35")
                    btnFiltrar.Visible = true;

                if (Application["Colores"] == null)
                {
                    Dictionary<string, Color> colores = new Dictionary<string, Color>();
                    colores.Add("1012", ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["Asignada"]));
                    colores.Add("1013", ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["Asignada"]));
                    colores.Add("1014", ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["En Proceso"]));
                    colores.Add("1015", ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["Con Problema"]));
                    colores.Add("1016", ColorTranslator.FromHtml(System.Configuration.ConfigurationManager.AppSettings["Atendida"]));
                    Application["Colores"] = colores;
                }

            }

        }
        CargarFiltros();
    }
    private void CargaControlesMapa()
    {
        GControl control1 = new GControl(GControl.preBuilt.LargeMapControl3D, new GControlPosition(GControlPosition.position.Top_Left));
        GControl control2 = new GControl(GControl.preBuilt.MenuMapTypeControl, new GControlPosition(GControlPosition.position.Top_Right));

        GMap1.addControl(control1);
        GMap1.addControl(control2);
    }

    private void CargarFiltros()
    {
        if (Session["Mapa" + Request["id"]] != null)
        {
            Dictionary<string, eleSupervisorTecnico> listaSup = (Dictionary<string, eleSupervisorTecnico>)Session["Mapa" + Request["id"]];

            if ((cmbSupervicion.SelectedValue.Length > 0) && (listaSup.ContainsKey(cmbSupervicion.SelectedValue)))
            {
                grdTecnico.Columns.Clear();
                switch (Request["tipo"])
                {
                    case "34":

                        grdTecnico.Columns.Clear();
                        grdTecnico.DataKeyNames = new string[] { "ClaveCuadrilla" };

                        ButtonField campo = new ButtonField();
                        campo.DataTextField = "CuadrillaTecnico";
                        campo.CommandName = "RutaCuadrillas";
                        grdTecnico.Columns.Add(campo);
                        break;
                    case "35":
                        grdTecnico.DataKeyNames = new string[] { "ClaveCuadrilla" };


                        BoundField cuaUbicacion = new BoundField();
                        cuaUbicacion.DataField = "CuadrillaTecnico";
                        grdTecnico.Columns.Add(cuaUbicacion);
                        TemplateField colUbicacion = new TemplateField();
                        colUbicacion.ItemTemplate = new TemplateColor();
                        grdTecnico.Columns.Add(colUbicacion);
                        break;

                } 
                grdTecnico.DataSource = listaSup[cmbSupervicion.SelectedValue].ListaSupervision;
                grdTecnico.DataBind();
            }
            
        }
    }

    private class eleTecnico
    {
        public string ClaveCuadrilla { get; set; }
        public string CuadrillaTecnico { get; set; }
        public string Estado { get; set; }
    }
    private class eleSupervisorTecnico
    {
        public string ClaveSupervisor { get; set; }
        public string NombreSupervisor { get; set; }
        public List<eleTecnico> ListaSupervision = new List<eleTecnico>();
    }

    public void PoblarTabla(System.Data.DataTable tabla)
    {
        Dictionary<string, eleSupervisorTecnico> listaSup = new Dictionary<string, eleSupervisorTecnico>();
        foreach (DataRow f in tabla.Rows)
        {
            string claveSupervisor = f["ClaveSupervisor"].ToString();
            if (!listaSup.ContainsKey(claveSupervisor))
            {
                listaSup.Add(claveSupervisor, new eleSupervisorTecnico());
                listaSup[claveSupervisor].ClaveSupervisor = claveSupervisor;
                listaSup[claveSupervisor].NombreSupervisor = f["Supervisor"].ToString();
            }
            listaSup[claveSupervisor].ListaSupervision.Add(new eleTecnico { ClaveCuadrilla = f["ClaveCuadrilla"].ToString(), CuadrillaTecnico = f["ClaveCuadrilla"].ToString() + " - " + f["Tecnico"].ToString(), Estado = (tabla.Columns.Contains("Estado") ? f["Estado"].ToString() : "")});
        }
        Session["Mapa" + Request["id"]] = listaSup;

        switch (Request["tipo"])
        {
            case "34":
                foreach (eleSupervisorTecnico s in listaSup.Values)
                    cmbSupervicion.Items.Add(new ListItem(s.NombreSupervisor, s.ClaveSupervisor));

                /*grdTecnico.Columns.Clear();
                grdTecnico.DataKeyNames = new string[] { "ClaveCuadrilla" };

                ButtonField campo = new ButtonField();
                campo.DataTextField = "CuadrillaTecnico";
                campo.CommandName = "RutaCuadrillas";
                grdTecnico.Columns.Add(campo);*/

                
                break;
            case "35":
                foreach (eleSupervisorTecnico s in listaSup.Values)
                    cmbSupervicion.Items.Add(new ListItem(s.NombreSupervisor, s.ClaveSupervisor));


                Session["Mapa" + Request["id"] + "Detalle"] = tabla;

                break;
        }
    }

   

    public string Filtro
    {
        get
        {
            return lblFiltro.Text;
        }
        set
        {
            lblFiltro.Text = value;
        }
    }

    public void HabilitarFotos(bool Habilita)
    {
    }
    protected void grdTecnico_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "RutaCuadrillas")
        {
            grdTecnico.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            string ClaveCuadrilla = grdTecnico.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            GenerarReportes control = new GenerarReportes();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ClaveCuadrilla");
            tabla.Columns.Add("Fecha1");
            tabla.Columns.Add("Fecha2");

            DataRow fila = tabla.NewRow();
            fila["ClaveCuadrilla"] = ClaveCuadrilla;
            fila["Fecha1"] = Convert.ToDateTime(Request["f1"]);
            fila["Fecha2"] = Convert.ToDateTime(Request["f2"]);
            tabla.Rows.Add(fila);
            Session["Mapa" + Request["id"] + "Detalle"] = control.ObtenerDetalles(Request["tipo"], ClaveCuadrilla, tabla);
            MostrarMapa();
            updFiltros.Update();
        }
    }

    private void MostrarMapa()
    {
        if (Session["Mapa" + Request["id"] + "Detalle"] != null)
        {
            DataTable table = (DataTable)Session["Mapa" + Request["id"] + "Detalle"];

            switch (Request["tipo"])
            {
                case "34":
                    MostrarRutaCuadrillas(table);
                    break;
                case "35":
                    MostrarUbicacionEnElMomento(table);
                    break;
            }
            CargaControlesMapa();

        }
    }
    private void MostrarUbicacionEnElMomento(DataTable tabla)
    {
        List<string> cuadrillas = new List<string>();
        foreach (GridViewRow fila in grdTecnico.Rows)
        {
            CheckBox chk = (CheckBox)fila.FindControl("chkSeleccion");
            if ((chk != null) && (chk.Checked))
                cuadrillas.Add(grdTecnico.DataKeys[fila.RowIndex].Value.ToString());
            
        }

        GMap1.reset();

        GLatLngBounds cuadro = new GLatLngBounds();

        string labelTecnico = UtilMensaje.ObtenerMensaje("#Tecnico");
        string labelContrato = UtilMensaje.ObtenerMensaje("#NoContrato");
        string labelHora = UtilMensaje.ObtenerMensaje("#Hora");
        string labelTrabajo = UtilMensaje.ObtenerMensaje("#Trabajo");
        string labelEstado = UtilMensaje.ObtenerMensaje("#Estado");

        foreach (DataRow fila in tabla.Rows)
        {
            if (cuadrillas.Contains(fila["ClaveCuadrilla"].ToString()))
            {
                if ((fila["Lat"] == DBNull.Value) || (fila["Lng"] == DBNull.Value))
                    continue;
                GIcon icono = new GIcon();

                Dictionary<string, Color> colores = (Dictionary<string, Color>)Application["Colores"];
                icono.flatIconOptions = new FlatIconOptions(
                    60, 20,
                    (colores.ContainsKey(fila["Estado"].ToString()) ? colores[fila["Estado"].ToString()] : Color.Red)
                    , System.Drawing.Color.Gray,
                    fila["ClaveCuadrilla"].ToString(),
                    System.Drawing.Color.Black, 9, FlatIconOptions.flatIconShapeEnum.roundedrect);

                GMarker gm = new GMarker(new GLatLng(Convert.ToDouble(fila["Lat"]), Convert.ToDouble(fila["Lng"])), icono);
                string html = "<b>" + labelTecnico + "</b>:" + fila["Tecnico"].ToString() + "<br/>";
                html += "<b>" + labelContrato + "</b>:" + fila["NoContrato"].ToString() + "<br/>";
                html += "<b>" + labelHora + "</b>:" + fila["Hora"].ToString() + "<br/>";
                html += "<b>" + labelTrabajo + "</b>:" + fila["Trabajo"].ToString() + "<br/>";
                html += "<b>" + labelEstado + "</b>:" + fila["EstadoDescripcion"].ToString();
                GInfoWindow ventana = new GInfoWindow(gm, html);

                cuadro.extend(gm.point);

                GMap1.addInfoWindow(ventana);
            }
        }
        int z = GMap1.getBoundsZoomLevel(cuadro);
        if (z < 15)
            z = 15;
        GMap1.setCenter(cuadro.getCenter(), z);
    }
    private void MostrarRutaCuadrillas(DataTable tabla)
    {
        GMap1.reset();
        
        GLatLngBounds cuadro = new GLatLngBounds();

        string labelTecnico= UtilMensaje.ObtenerMensaje("#Tecnico");
        string labelContrato= UtilMensaje.ObtenerMensaje("#NoContrato");
        string labelHora= UtilMensaje.ObtenerMensaje("#Hora");
        string labelTrabajo= UtilMensaje.ObtenerMensaje("#Trabajo");
        string labelEstado= UtilMensaje.ObtenerMensaje("#Estado");
        List<GLatLng> linea = new List<GLatLng>();
        
        
        foreach (DataRow fila in tabla.Rows)
        {
            if ((fila["Lat"] == DBNull.Value) || (fila["Lng"] == DBNull.Value))
                continue;
            GIcon icono = new GIcon();
            PREMEG.Reportes.RutaDeCuadrillas.DetalleOrden[] ordenes = (PREMEG.Reportes.RutaDeCuadrillas.DetalleOrden[])fila["Ordenes"];
            Dictionary<string, Color> colores = (Dictionary<string, Color>)Application["Colores"];
            icono.flatIconOptions = new FlatIconOptions(
                20, 20,
                Color.Blue//(colores.ContainsKey(fila["Estado"].ToString()) ? colores[fila["Estado"].ToString()] : Color.Red)
                , System.Drawing.Color.Gray,
                fila["Orden"].ToString(),
                System.Drawing.Color.Black, 9);

            GMarker gm = new GMarker(new GLatLng( Convert.ToDouble(fila["Lat"]), Convert.ToDouble(fila["Lng"])),icono);
            linea.Add(gm.point);
            string html = "<b>" + labelTecnico + "</b>:" + fila["Tecnico"].ToString() + "<br/>";
            html += "<b>" + labelContrato + "</b>:" + fila["NoContrato"].ToString() + "<br/>";
            html += "<b>" + labelHora + "</b>:" + fila["FechaHoraI"].ToString() + "<br/>";
            //html += "<b>" + labelTrabajo + "</b>:" + fila["Trabajo"].ToString() + "<br/>";
            //html += "<b>" + labelEstado + "</b>:" + fila["EstadoDescripcion"].ToString();
            html += "<table>";
            foreach (PREMEG.Reportes.RutaDeCuadrillas.DetalleOrden o in ordenes)
                //html += "<tr><td>" + o.Hora.ToShortTimeString() + "</td><td>" + o.Descripcion + "</td><td>" + o.EstadoDescripcion + "</td></tr>";
                html += "<tr><td>" + o.Descripcion + "</td><td>" + o.EstadoDescripcion + "</td></tr>";
            html += "</table>";
            GInfoWindow ventana = new GInfoWindow(gm, html);

            cuadro.extend(gm.point);
           
            GMap1.addInfoWindow(ventana);
        }
        GMap1.addPolyline(new GPolyline(linea));
        int z = GMap1.getBoundsZoomLevel(cuadro);
        if (z < 15)
            z = 15;
        GMap1.setCenter(cuadro.getCenter(), z);
    }
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        MostrarMapa();
    }


    private class TemplateColor : ITemplate
    {

        public void InstantiateIn(Control container)
        {

            Label pnl = new Label();
            pnl.Width = 10;
            pnl.Height = 10;
            pnl.BackColor = Color.Red;
            pnl.DataBinding += new EventHandler(pnl_DataBinding);
            container.Controls.Add(pnl);
            CheckBox chk = new CheckBox();
            
            chk.ID = "chkSeleccion";
            container.Controls.Add(chk);
        }


        void pnl_DataBinding(object sender, EventArgs e)
        {
            Label pnl = (Label)sender;
            eleTecnico ele = (eleTecnico)((GridViewRow)(pnl).NamingContainer).DataItem;
            Dictionary<string, Color> colores = (Dictionary<string, Color>)pnl.Page.Application["Colores"];
            pnl.BackColor = colores[ele.Estado];
        }

    }


    public string Titulo
    {
        get
        {
            return lblTitulo.Text;
        }
        set
        {
            lblTitulo.Text = value;
            DateTime fecha1 = Convert.ToDateTime(Request["f1"]);
            DateTime fecha2 = Convert.ToDateTime(Request["f2"]);
            fecha2 = fecha2.AddDays(-1);

            this.Title = lblTitulo.Text + " : " + fecha1.ToString("dd/MM/yyyy") + (fecha1.CompareTo(fecha2) == 0 ? "" : " - " + fecha2.AddDays(1).ToString("dd/MM/yyyy"));
        }
    }
    protected void cmbSupervicion_SelectedIndexChanged(object sender, EventArgs e)
    {
        grdTecnico.SelectedIndex = -1;
        CargarFiltros();
    }
}