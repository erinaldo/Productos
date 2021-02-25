using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class GenerarReporte : System.Web.UI.Page, IGenerarReporte
{
    [System.Web.Services.WebMethod]
    public static void DescargarReportes(string id)
    {
        HttpContext.Current.Session.Remove("Reporte" + id);
        HttpContext.Current.Session.Remove("Reporte" + id + "Detalle");
        HttpContext.Current.Session.Remove("Reporte" + id + "Filtro");
    }
    protected override void OnInit(EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if ((Request["tipo"] != null) && (Request["tipo"] != ""))
            {
                DescargarReportes(Request["id"]);
                GenerarReportes control = new GenerarReportes();
                control.ConsultarReporte(Request["tipo"], Convert.ToDateTime(Request["f1"]), Convert.ToDateTime(Request["f2"]), this);
                UtilEtiquetas.CargarEtiquetas(this);
            }

        }
        ConstruirTabla();
        ConstruirDetalle();
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
   


    public void PoblarTabla(DataTable tabla)
    {

        Session["Reporte" + Request["id"]] = tabla;
    }
    private void ConstruirTabla()
    {
        if (Session["Reporte" + Request["id"]] == null)
            return;

        DataTable tabla = (DataTable)Session["Reporte" + Request["id"]];
        var table = new HtmlGenericControl("table") { ID = "tablaReporte" };
        table.Attributes["class"] = "Reportes";

        var trhead = new HtmlGenericControl("tr");
        trhead.Attributes["class"] = "Reportes";
        bool primero = true;
        foreach (DataColumn c in tabla.Columns)
        {
            if ((c.ColumnName != "idnodo") && (c.ColumnName != "idpadre") && (c.ColumnName != "nodoultimo") && (!c.ColumnName.StartsWith("_")))
            {
                string titulo = c.ColumnName;
                if (titulo.StartsWith("?"))
                {
                    titulo = "#" + titulo.Substring(1);
                    titulo = UtilMensaje.ObtenerMensaje(titulo);
                }
                var th = new HtmlGenericControl("th") { InnerText = titulo };
                if (primero)
                {
                    th.InnerText = "";
                    primero = false;
                }
                th.Attributes["class"] = "Reportes";
                trhead.Controls.Add(th);
            }
        }
        table.Controls.Add(trhead);
        foreach (DataRow fila in tabla.Rows)
        {
            var tr = new HtmlGenericControl("tr");
            tr.ID = fila["idnodo"].ToString();
            if ((fila["idpadre"] != null) && (fila["idpadre"].ToString() != ""))
                tr.Attributes["class"] = "child-of-" + fila["idpadre"].ToString();
            bool primeraColumna = true;
            bool nombre = true;
            foreach (DataColumn c in tabla.Columns)
            {
                if ((c.ColumnName != "idnodo") && (c.ColumnName != "idpadre") && (c.ColumnName != "nodoultimo") && (!c.ColumnName.StartsWith("_")))
                {
                    var td = new HtmlGenericControl("td") { InnerText = fila[c.ColumnName].ToString() };
                    if (nombre)
                    {
                        td.Style.Add("text-align", "left");
                        nombre = false;
                    }
                    else
                        td.Style.Add("text-align", "center");

                    if ((Convert.ToBoolean(fila["nodoultimo"])) && (primeraColumna))
                    {
                        primeraColumna = false;
                        td.InnerText = "";
                        LinkButton lb = new LinkButton();
                        lb.ID = fila["idnodo"].ToString() + c.ColumnName;
                        lb.Text = fila[c.ColumnName].ToString();
                        lb.Click += new EventHandler(lb_Click);
                        lb.CommandArgument = fila["idnodo"].ToString();
                        td.Controls.Add(lb);
                    }

                    tr.Controls.Add(td);

                }
            }
            table.Controls.Add(tr);
        }
        pnlReporte.Controls.Clear();
        pnlReporte.Controls.Add(table);
    }

    private void ConstruirDetalle()
    {

        if (Session["Reporte" + Request["id"] + "Detalle"] != null)
        {

            DataTable tablaOrigen = (DataTable)Session["Reporte" + Request["id"] + "Detalle"];
            string filtro = "";
            if (Session["Reporte" + Request["id"] + "Filtro"] != null)
                filtro = Session["Reporte" + Request["id"] + "Filtro"].ToString();

            DataView tabla = new DataView(tablaOrigen, filtro, "", DataViewRowState.CurrentRows);
            //DataRow[] tabla = tablaOrigen.Select(filtro);
            /*if (filtros != null)
            {
                string strFiltro="";
                
                     tabla.Select(
            }*/

            switch (Request["tipo"])
            {
                case "32":
                    if (chkImagenes.Checked)
                    {
                        if (grdDetalle.Visible)
                        {
                            pnlDetalle.Visible = false;
                            //grdDetalle.Visible = false;
                            updDetalle.Update();
                        }
                        dlAudCableado.Visible = true;
                        dlAudCableado.DataSource = tabla;
                        dlAudCableado.DataBind();
                        UtilEtiquetas.CargarEtiquetas(dlAudCableado);
                        updImagenesAudCableado.Update();
                    }
                    else
                    {
                        pnlDetalle.Visible = true;
                        //grdDetalle.Visible = true;
                        CargarDetalle(tabla);
                        if (dlAudCableado.Visible)
                        {
                            dlAudCableado.Visible = false;
                            updImagenesAudCableado.Update();
                        }
                    }
                    break;
                case "33":
                    if (chkImagenes.Checked)
                    {
                        if (grdDetalle.Visible)
                        {
                            pnlDetalle.Visible = false;
                            //grdDetalle.Visible = false;
                            updDetalle.Update();
                        }
                        dlAudVisita.Visible = true;
                        dlAudVisita.DataSource = tabla;
                        dlAudVisita.DataBind();
                        UtilEtiquetas.CargarEtiquetas(dlAudVisita);
                        updImagenesAudVisita.Update();
                    }
                    else
                    {
                        pnlDetalle.Visible = true;
                        //grdDetalle.Visible = true;
                        CargarDetalle(tabla);
                        if (dlAudVisita.Visible)
                        {
                            dlAudVisita.Visible = false;
                            updImagenesAudVisita.Update();
                        }
                    }
                    break;
                default:
                    CargarDetalle(tabla);
                    break;
            }

        }

       
        /*foreach (DataControlField c in grdDetalle.Columns)
        {
            grdDetalle.Columns.Remove(
        }*/
        
    }
    private void CargarDetalle(DataView tabla)
    {
        /*grdDetalle.AutoGenerateColumns = false;
        grdDetalle.Columns.Clear();
        foreach (DataColumn c in tabla.Table.Columns)
        {
            if (!c.ColumnName.StartsWith("_"))
            {

                BoundField columna = new BoundField();
                columna.DataField = c.ColumnName;
                columna.HeaderText = c.ColumnName;
                grdDetalle.Columns.Add(columna);
            }
        }
        grdDetalle.DataSource = tabla;
        grdDetalle.DataBind();*/

        //pnlDetalle.Controls.Clear();
        HtmlGenericControl table = (HtmlGenericControl)pnlDetalle.FindControl("tablaDetalle");
        bool existe = false;
        bool hayFiltros = false;
        if (table == null)
        {
            table = new HtmlGenericControl("table") { ID = "tablaDetalle" };
            var trhead = new HtmlGenericControl("tr");
            var trFiltros = new HtmlGenericControl("tr");

            foreach (DataColumn c in tabla.Table.Columns)
            {
                if ((c.ColumnName != "idnodo") && (c.ColumnName != "idpadre") && (c.ColumnName != "nodoultimo") && (!c.ColumnName.StartsWith("_")))
                {
                    string titulo = c.ColumnName;
                    if (titulo.StartsWith("?") || titulo.StartsWith("!") || titulo.StartsWith("|"))
                    {
                        titulo = "#" + titulo.Substring(1);
                        titulo = UtilMensaje.ObtenerMensaje(titulo);
                    }
                    var th = new HtmlGenericControl("th") { InnerText = titulo };
                    trhead.Controls.Add(th);
                    var tf = new HtmlGenericControl("th");
                    if (titulo.StartsWith("?"))
                    {
                        TextBox txt = new TextBox();
                        txt.ID = "filtro" + c.ColumnName.Replace(" ", ""); ;
                        tf.Controls.Add(txt);
                        hayFiltros = true;
                    }
                    trFiltros.Controls.Add(tf);
                }
            }
            table.Controls.Add(trhead);
            if (hayFiltros)
            {
                var thBotonFiltrar = new HtmlGenericControl("th");
                ImageButton imgFiltrar = new ImageButton();
                imgFiltrar.ID = "btnFiltrar";
                imgFiltrar.ImageUrl = "img/Document Down.jpg";
                imgFiltrar.Click += new ImageClickEventHandler(imgFiltrar_Click);
                ImageButton imgSinFilto = new ImageButton();
                imgSinFilto.ID = "btnSinFiltro";
                imgSinFilto.ImageUrl = "img/SinFiltro.gif";
                imgSinFilto.Click += new ImageClickEventHandler(imgSinFilto_Click);

                thBotonFiltrar.Controls.Add(imgFiltrar);
                thBotonFiltrar.Controls.Add(imgSinFilto);
                trFiltros.Controls.Add(thBotonFiltrar);
                table.Controls.Add(trFiltros);
            }
        }
        else
        {
            existe = true;
            int borrarDesde = (hayFiltros ? 2 : 1);
            while (table.Controls.Count > borrarDesde)
                table.Controls.RemoveAt(borrarDesde);
        }
        
        foreach (DataRowView fila in tabla)
        {
            var tr = new HtmlGenericControl("tr");

            foreach (DataColumn c in tabla.Table.Columns)
            {
                if ((c.ColumnName != "idnodo") && (c.ColumnName != "idpadre") && (c.ColumnName != "nodoultimo") && (!c.ColumnName.StartsWith("_")))
                {
                    var td = new HtmlGenericControl("td");
                    if (c.ColumnName.StartsWith("|"))
                        td.InnerHtml = fila[c.ColumnName].ToString();
                    else
                        td.InnerText = fila[c.ColumnName].ToString();
                    tr.Controls.Add(td);
                }
            }
            table.Controls.Add(tr);
        }
        
        if (!existe)
            pnlDetalle.Controls.Add(table);

        updDetalle.Update();
    }

    void imgSinFilto_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Reporte" + Request["id"] + "Detalle"] != null)
        {
            DataTable tabla = (DataTable)Session["Reporte" + Request["id"] + "Detalle"];

            foreach (DataColumn col in tabla.Columns)
            {
                TextBox txt = (TextBox)pnlDetalle.FindControl("filtro" + col.ColumnName);
                txt.Text = "";
            }
            Session["Reporte" + Request["id"] + "Filtro"] = "";
            ConstruirDetalle();
        }
    }

    void imgFiltrar_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["Reporte" + Request["id"] + "Detalle"] != null)
        {
            DataTable tabla = (DataTable)Session["Reporte" + Request["id"] + "Detalle"];
            string filtro = "";
            foreach(DataColumn col in tabla.Columns){
                TextBox txt = (TextBox)pnlDetalle.FindControl("filtro" + col.ColumnName);
                if ((txt != null)&&(txt.Text.Trim().Length > 0))
                {
                    filtro += col.ColumnName + " LIKE '%" + txt.Text.Trim() + "%' AND";
                }
            }
            if (filtro.Trim().Length > 3)
                filtro = filtro.Substring(0, filtro.Length - 4);
            Session["Reporte" + Request["id"] + "Filtro"] = filtro;
            ConstruirDetalle();
        }
    }
    
    public void lb_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;

        GenerarReportes control = new GenerarReportes();
        DataTable tabla = control.ObtenerDetalles(Request["tipo"].ToString(), lb.CommandArgument, (DataTable)Session["Reporte" + Request["id"]]);
        Session["Reporte" + Request["id"] + "Detalle"] = tabla;
        Session["Reporte" + Request["id"] + "Filtro"] = "";
        grdDetalle.PageIndex = 0;
        ConstruirDetalle();
        
        //throw new NotImplementedException();
    }

    protected void grdDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdDetalle.PageIndex = e.NewPageIndex;
        ConstruirDetalle();
    }

    protected string RutaImagen(object claveSucursal, object archivo)
    {
        return "cotroles/obtenerimagen.ashx?cs=" + claveSucursal.ToString() + "&a=" + archivo.ToString();
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
        chkImagenes.Visible = Habilita;
    }
    protected void chkImagenes_CheckedChanged(object sender, EventArgs e)
    {
        ConstruirDetalle();
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
            DateTime fecha1= Convert.ToDateTime(Request["f1"]);
            DateTime fecha2= Convert.ToDateTime(Request["f2"]);
            fecha2 = fecha2.AddDays(-1);

            this.Title = lblTitulo.Text + " : " + fecha1.ToString("dd/MM/yyyy") + (fecha1.CompareTo(fecha2) == 0 ? "" : " - " + fecha2.AddDays(1).ToString("dd/MM/yyyy"));
        }
    }
}