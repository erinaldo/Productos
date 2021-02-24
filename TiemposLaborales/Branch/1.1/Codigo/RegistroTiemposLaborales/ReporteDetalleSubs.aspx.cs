using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RegistroTiemposLaborales
{
    public partial class ReporteDetalleSubs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarSubordinados();
                txtFechaInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
                if (Session["Usuario"] != null && Session["Usuario"].ToString() != "")
                {
                    pnlControlesVisibles.Visible = true;
                    ButtonGenerar.Visible = true;
                    GenerarReporte();
                }
            }
        }
        private void CargarSubordinados()
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                List<string> usuarios = (from u in db.PermisoUsuario where u.Usuario == Session["Usuario"].ToString() orderby u.Usuario2 select u.Usuario2 ).ToList();
                cmbSubordinados.Items.Clear();
                pnlSubordinados.Visible = (usuarios.Count != 0);
                cmbSubordinados.Items.Add(new ListItem("Todos",""));
                foreach (string u in usuarios)
                    cmbSubordinados.Items.Add(new ListItem(u,u));
                
            }
        }
        private void GenerarReporte()
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
            DateTime fechaIni = DateTime.ParseExact(txtFechaInicial.Text.Trim(), "dd/MM/yyyy", culture);
            DateTime fechaFin = DateTime.ParseExact(txtFechaFinal.Text.Trim(), "dd/MM/yyyy", culture);
            fechaFin = fechaFin.AddDays(1);
 
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Usuario");
            tabla.Columns.Add("Proyecto");
            tabla.Columns.Add("Fecha");
            tabla.Columns.Add("Hora");
            tabla.Columns.Add("Tipo");
            tabla.Columns.Add("Area");
            tabla.Columns.Add("Actividad");
            tabla.Columns.Add("Descripcion");
            tabla.Columns.Add("CantHoras");
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                List<string> usuarios = new List<string>();
                if (cmbSubordinados.SelectedValue == "")
                    usuarios = (from u in db.PermisoUsuario where u.Usuario == Session["Usuario"].ToString() select u.Usuario2).ToList();
                else
                    usuarios.Add(cmbSubordinados.SelectedValue);

                var lista = from l in db.RegistroTiempos
                            where l.FechaHoraInicial >= fechaIni && l.FechaHoraInicial < fechaFin
                            && (usuarios.Contains(l.Usuario) )
                            orderby l.Usuario, l.FechaHoraInicial descending
                            select new { Tipo = l.ValorReferencia1.Descripcion, Usuario = l.Usuario, Proyecto = l.ValorReferencia.Descripcion, FechaHora = l.FechaHoraInicial, Descripcion = l.Descripcion, CantHoras = l.Horas, Actividad = l.ValorReferencia2.Descripcion, Area = l.ValorReferencia3.Descripcion};
                string usuario = "";
                foreach (var i in lista)
                {
                    DataRow fila = tabla.NewRow();
                    if (usuario != i.Usuario)
                    {
                        fila["Usuario"] = i.Usuario;
                        usuario = i.Usuario;
                    }
                    fila["Proyecto"] = i.Proyecto;
                    fila["Fecha"] = i.FechaHora.ToString("dd/MM/yyyy");
                    fila["Hora"] = i.FechaHora.ToString("hh:mm tt");
                    fila["Tipo"] = i.Tipo;
                    fila["Area"] = i.Area;
                    fila["Actividad"] = i.Actividad;
                    fila["Descripcion"] = i.Descripcion;
                    fila["CantHoras"] = i.CantHoras > 0 ? i.CantHoras.ToString() : "";
                    tabla.Rows.Add(fila);
                }
            }           
            GridView1.DataSource = tabla;
            GridView1.DataBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GenerarReporte();
        }
    }
}
