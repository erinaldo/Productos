using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace RegistroTiemposLaborales
{
    public partial class ReporteProyectoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (!Page.IsPostBack)
            {
                char[] separador = { '/' };
                DateTime Fecha1 = DateTime.Parse(Request.QueryString["f1"]);
                DateTime Fecha2 = DateTime.Parse(Request.QueryString["f2"]);
                CalendarExtenderFecha1.SelectedDate = Fecha1;
                CalendarExtenderFecha2.SelectedDate = Fecha2;
                UpdatePanelGrid.Update();
                generarTabla();
            }
        }

        public class Resultados
        {
            public string Proyecto { get; set; }
            public string Usuario { get; set; }
            public string Descripcion { get; set; }
            public double Horas { get; set; }
        }
        public void generarTabla()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            char[] separador = { '/' };

            DateTime Fecha1 = DateTime.Parse(Request.QueryString["f1"]);
            DateTime Fecha2 = DateTime.Parse(Request.QueryString["f2"]);

            DateTime FechaT = Fecha1;

            DataTable tDatos = new DataTable();
            tDatos.Columns.Add("Proyecto", typeof(string));
            tDatos.Columns.Add("Usuario", typeof(string));
            tDatos.Columns.Add("Descripcion", typeof(string));
            tDatos.Columns.Add("Horas", typeof(double));
            tDatos.Columns.Add("TotalHoras", typeof(double));

            string[] sUsuarios = UsuariosPermisos();
            List<Resultados> res = (from t in db.RegistroTiempos
                                    where t.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && sUsuarios.Contains(t.Usuario) && Fecha1 <= t.FechaInicioJornada && Fecha2 >= t.FechaInicioJornada
                                    orderby t.ValorReferencia.Descripcion, t.FechaHoraInicial
                                    select new Resultados
                                    {
                                        Proyecto = t.ValorReferencia.Descripcion,
                                        Usuario = t.Usuario,
                                        Descripcion = t.Descripcion,
                                        Horas = t.Horas
                                    }).ToList();





            foreach(Resultados r in res )
            {



                //tDatos.Rows.Add(new object[] { sUsuarios[u],"ReporteTiempoLaboralUsuario.aspx?u="+sUsuarios[u], Math.Round(TiempoTotal.TotalHours, 0), Math.Round(HorasRegistradasxProyecto, 0) });
                tDatos.Rows.Add(new object[] { 
                    r.Proyecto, 
                    r.Usuario, 
                    r.Descripcion, 
                    r.Horas, 
                    res.Where(p => p.Proyecto == r.Proyecto).Sum(a => a.Horas) 
                });


            }

            Repeater1.DataSource = tDatos;
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            char[] separador = { '/' };

            DateTime Fecha1 = new DateTime(int.Parse(TextBoxFecha1.Text.Split(separador)[2]), int.Parse(TextBoxFecha1.Text.Split(separador)[1]), int.Parse(TextBoxFecha1.Text.Split(separador)[0]), 0, 0, 0);
            DateTime Fecha2 = new DateTime(int.Parse(TextBoxFecha2.Text.Split(separador)[2]), int.Parse(TextBoxFecha2.Text.Split(separador)[1]), int.Parse(TextBoxFecha2.Text.Split(separador)[0]), 23, 59, 59);
            Response.Redirect("ReporteProyectoUsuario.aspx?f1=" + Fecha1.ToString("s") + "&f2=" + Fecha2.ToString("s"));

        }

       
        public string[] UsuariosPermisos()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var usuarios = from u in db.PermisoUsuario
                           where u.Usuario == User.Identity.Name
                           select u.Usuario2;

            string[] usuario = { User.Identity.Name };


            return usuarios.ToArray().Union(usuario).ToArray().OrderBy(a => a).ToArray();
        }

      

        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            
        }

        public bool mostrarProyecto(object tabla,int fila,object cont)
        {
            var row = (from Control r in ((RepeaterItem)cont).Controls
                       where r.ID == "FILA"
                       select r).FirstOrDefault();


            if (row != null)
            {
                var proyec = from DataRow a in ((DataTable)tabla).Rows
                             select a["Proyecto"].ToString() ;


                

                if (proyec.Distinct().ToList().IndexOf(((DataTable)tabla).Rows[fila]["Proyecto"].ToString()) % 2 == 0)
                {
                    ((HtmlTableRow)row).Style.Add("background-image", "url('images/fondo.gif')");
                    ((HtmlTableRow)row).Style.Add("background-repeat", "repeat-x");
                    ((HtmlTableRow)row).Style.Add("background-color", "#a5c2f6");



                }

            }


            if (fila == 0)
                return true;
            else
            {
                if (((DataTable)tabla).Rows[fila]["Proyecto"].ToString() == ((DataTable)tabla).Rows[fila - 1]["Proyecto"].ToString())
                {
                    return false;
                }
                else
                    return true;
            }
              

        }


        public bool mostrarTotal(object tabla,int fila)
        {
            if (fila == ((DataTable)tabla).Rows.Count - 1)
                return true;
            else
            {
                if (((DataTable)tabla).Rows[fila]["Proyecto"].ToString() == ((DataTable)tabla).Rows[fila +1]["Proyecto"].ToString())
                {
                    return false;
                }
                else
                    return true;
            }

        }


    }
}
