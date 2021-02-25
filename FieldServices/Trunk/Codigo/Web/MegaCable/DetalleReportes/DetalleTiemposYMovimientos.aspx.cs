using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODMEG;
using System.Web.UI.HtmlControls;

public partial class DetalleReportes_DetalleTiemposYMovimientos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            CargarDatos(Request["type"], Request["idVisita"]);
        }
        UtilEtiquetas.CargarEtiquetas(this);
    }

    private void CargarDatos(string type, string idVisita)
    {
        using (MegaCableEntities ctx = new MegaCableEntities())
        {
            Visita visita = ctx.Visita.Where(v => v.IdVisita == new Guid(idVisita)).First();

            fldSuscriptor.Text = visita.Suscriptor.ClaveSuscriptor;
            fldNombreSuscriptor.Text = visita.Suscriptor.Nombre;

            fldInicio.Text = visita.FechaHoraInicio.ToString("yyy MMMM dd HH:mm");
            if(visita.FechaHoraFin != null)
            fldFin.Text = ((DateTime)visita.FechaHoraFin).ToString("yyy MMMM dd HH:mm");

            var table = new HtmlGenericControl("table") { ID = "tablaReporte" };
            table.Attributes["class"] = "Reportes";

            var trhead = new HtmlGenericControl("tr");
            trhead.Attributes["class"] = "Reportes";

            var th = new HtmlGenericControl("th") { InnerText = UtilMensaje.ObtenerMensaje("#Trabajo") };
            th.Attributes["class"] = "Reportes";
            trhead.Controls.Add(th);
            th = new HtmlGenericControl("th") { InnerText = UtilMensaje.ObtenerMensaje("#MaterialesEquipos") };
            th.Attributes["class"] = "Reportes";
            trhead.Controls.Add(th);
            th = new HtmlGenericControl("th") { InnerText = UtilMensaje.ObtenerMensaje("#CantSerie") };
            th.Attributes["class"] = "Reportes";
            trhead.Controls.Add(th);

            table.Controls.Add(trhead);
            bool alMenosUno = false;
            foreach (OrdenTrabajo ordenTrabajo in visita.OrdenTrabajo.Where(o => o.ValorReferencia1.Grupo == 2))
            {
                var tr = new HtmlGenericControl("tr");
                tr.Attributes["class"] = "Reportes";

                var td = new HtmlGenericControl("td");
                td.InnerText = ordenTrabajo.Trabajo.Descripcion+ " | " + ordenTrabajo.ValorReferencia1.Descripcion;
                td.Attributes["class"] = "Reportes";
                tr.Controls.Add(td);
                table.Controls.Add(tr);
                foreach (ConsumoTrabajo conTra in ordenTrabajo.ConsumoTrabajo.Where(c=> c.CantidadUtilizada > 0))
                {
                    if (tr == null)
                    {
                        tr = new HtmlGenericControl("tr");
                        tr.Attributes["class"] = "Reportes";
                        td = new HtmlGenericControl("td");
                        td.Attributes["class"] = "Reportes";
                        tr.Controls.Add(td);
                        table.Controls.Add(tr);
                    }
                    td = new HtmlGenericControl("td");
                    td.InnerText = conTra.Material.Descripcion;
                    tr.Controls.Add(td);

                    td = new HtmlGenericControl("td");
                    td.InnerText = conTra.CantidadUtilizada.ToString();
                    tr.Controls.Add(td);
                    tr = null;
                    alMenosUno = true;
                }
                foreach (ConsumoCableTrabajo conCable in ordenTrabajo.ConsumoCableTrabajo.Where(c => c.CantidadUtilizada > 0))
                {
                    if (tr == null)
                    {
                        tr = new HtmlGenericControl("tr");
                        tr.Attributes["class"] = "Reportes";
                        td = new HtmlGenericControl("td");
                        td.Attributes["class"] = "Reportes";
                        tr.Controls.Add(td);
                        table.Controls.Add(tr);
                    }
                    td = new HtmlGenericControl("td");
                    td.InnerText = conCable.Material.Descripcion;
                    tr.Controls.Add(td);

                    td = new HtmlGenericControl("td");
                    td.InnerText = conCable.CantidadUtilizada.ToString();
                    tr.Controls.Add(td);
                    tr = null;
                    alMenosUno = true;
                }
                foreach (NumeroSerieEquipoDigital conNumSerie in ordenTrabajo.NumeroSerieEquipoDigital)
                {
                    if (tr == null)
                    {
                        tr = new HtmlGenericControl("tr");
                        tr.Attributes["class"] = "Reportes";
                        td = new HtmlGenericControl("td");
                        td.Attributes["class"] = "Reportes";
                        tr.Controls.Add(td);
                        table.Controls.Add(tr);
                    }
                    td = new HtmlGenericControl("td");
                    td.InnerText = conNumSerie.Material.Descripcion;
                    tr.Controls.Add(td);

                    td = new HtmlGenericControl("td");
                    td.InnerText = conNumSerie.NumeroSerieEquipoDigital1;
                    tr.Controls.Add(td);
                    tr = null;
                    alMenosUno = true;
                }
                if (ordenTrabajo.Servicio != null)
                {
                    if (tr == null)
                    {
                        tr = new HtmlGenericControl("tr");
                        tr.Attributes["class"] = "Reportes";
                        td = new HtmlGenericControl("td");
                        td.Attributes["class"] = "Reportes";
                        tr.Controls.Add(td);
                        table.Controls.Add(tr);
                    }
                    td = new HtmlGenericControl("td");
                    td.InnerText = ordenTrabajo.Servicio.Descripcion;
                    tr.Controls.Add(td);

                    td = new HtmlGenericControl("td");
                    td.InnerText = "";
                    tr.Controls.Add(td);
                    tr = null;
                    alMenosUno = true;
                }
            
            }
            if (alMenosUno)
                pnlDetalle.Controls.Add(table);
            if (type == "0")
            {
                foreach (SuscriptorVisitado sus in visita.SuscriptorVisitado)
                {
                    var img = new HtmlGenericControl("img");
                    img.Attributes["src"] = "../Cotroles/ObtenerImagen.ashx?cs="+ visita.Jornada.Cuadrilla.Sucursal.ClaveSucursal+"&a="+sus.IdImagen ;
                    pnlDetalle.Controls.Add(img);
                }
            }
            
        }
        

    }
}