using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RegistroTiemposLaborales
{
    public partial class ReporteTiempoLaboralUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (!Page.IsPostBack)
            {
                char[] separador = { '/' };

                DateTime Fecha1 = DateTime.Parse(Request.QueryString["f1"].Replace("..", ":").Replace("_", "-"));
                DateTime Fecha2 = DateTime.Parse(Request.QueryString["f2"].Replace("..", ":").Replace("_", "-"));
             
                if (!UsuariosPermisos().Contains( Request.QueryString["u"]))
                Response.Redirect("ReporteTiempoLaboral.aspx?f1=" + Fecha1.ToString("s") + "&f2=" +Fecha2.ToString("s"));

                UpdatePanelGrid.Update();
                generarTabla(Fecha1, Fecha2, Request.QueryString["u"]);
                
                LabelUsuario.Text = Request.QueryString["u"];
                LabelFechas.Text = "Periodo del " + Fecha1.ToString("dd/MM/yyyy") + " hasta " + Fecha2.ToString("dd/MM/yyyy");

                LinkAtras.NavigateUrl = "ReporteTiempoLaboral.aspx?f1=" + Fecha1.ToString("s") + "&f2=" +Fecha2.ToString("s");
                LinkHome.NavigateUrl = "Default.aspx";
            }
        }

        public void generarTabla(DateTime Fecha1, DateTime Fecha2,string Usuario)
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            char[] separador = { '/' };

            //DateTime Fecha1 = new DateTime(int.Parse(TextBoxFecha1.Text.Split(separador)[2]), int.Parse(TextBoxFecha1.Text.Split(separador)[1]), int.Parse(TextBoxFecha1.Text.Split(separador)[0]), 0, 0, 0);
            //DateTime Fecha2 = new DateTime(int.Parse(TextBoxFecha2.Text.Split(separador)[2]), int.Parse(TextBoxFecha2.Text.Split(separador)[1]), int.Parse(TextBoxFecha2.Text.Split(separador)[0]), 23, 59, 59);



            DateTime FechaT = Fecha1;




            var usuarios = (from u in db.RegistroTiempos
                            where u.FechaInicioJornada >= Fecha1 && u.FechaInicioJornada <= Fecha2
                            select u.Usuario).Distinct();


            DataTable tDatos = new DataTable();
            tDatos.Columns.Add("Fecha", typeof(string));
      
            tDatos.Columns.Add("Horas", typeof(string));
            tDatos.Columns.Add("HorasRegistradas", typeof(string));

          

           

                for (int i = 0; i < (Fecha2 - Fecha1).Days + 1; i++)
                {
                    TimeSpan TiempoTotal = new TimeSpan();
                    double HorasRegistradasxProyecto = 0;


                    FechaT = Fecha1.AddDays(i);
                    var Dia = from d in db.RegistroTiempos
                              where d.Proyecto != new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && d.Usuario == Usuario && d.FechaInicioJornada.DayOfYear == FechaT.DayOfYear && d.FechaInicioJornada.Year == FechaT.Year
                              select d.FechaHoraInicial;

                    List<DateTime> horas = Dia.ToList<DateTime>();

                    if (horas.Count % 2 != 0)
                    {
                        if (FechaT.DayOfYear == DateTime.Now.DayOfYear && FechaT.Year == DateTime.Now.Year)
                            horas.Add(DateTime.Now);
                        else
                        {
                            var UltimaHora = (from d in db.RegistroTiempos
                                              where d.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && d.Usuario == Usuario && d.FechaInicioJornada.DayOfYear == FechaT.DayOfYear && d.FechaInicioJornada.Year == FechaT.Year
                                              orderby d.FechaHoraInicial descending
                                              select d.FechaHoraInicial).FirstOrDefault();


                            if (UltimaHora < (DateTime)horas[horas.Count - 1])
                            {
                                horas.Add((DateTime)horas[horas.Count - 1]);
                            }
                            else
                            {
                                horas.Add(UltimaHora);
                            }
                        }
                    }

                    for (int j = 0; j < horas.Count; j += 2)
                    {

                        TiempoTotal += horas[j + 1] - horas[j];
                    }

                    double? Horas = (from d in db.RegistroTiempos
                                     where d.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && d.Usuario == Usuario && d.FechaHoraInicial.DayOfYear == FechaT.DayOfYear && d.FechaHoraInicial.Year == FechaT.Year
                                     select (double?)d.Horas).Sum();

                    if (Horas != null)
                        HorasRegistradasxProyecto += (double)Horas;

                    TimeSpan registradas = new TimeSpan( (int)HorasRegistradasxProyecto,(int)(( HorasRegistradasxProyecto-(int)HorasRegistradasxProyecto)*60),0);


                    tDatos.Rows.Add(new object[] { FechaT.ToString("dd/MM/yyyy"), TiempoTotal.Hours.ToString() + " Horas " + TiempoTotal.Minutes + " Minutos", registradas.Hours + " Horas " + registradas.Minutes + " Minutos" });

                }

                //tDatos.Rows.Add(new object[] { sUsuarios[u],"ReporteTiempoLaboralUsuario.aspx?u="+sUsuarios[u], Math.Round(TiempoTotal.TotalHours, 0), Math.Round(HorasRegistradasxProyecto, 0) });
               

           
            GridView1.DataSource = tDatos;
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell celda in e.Row.Cells)
            {
                celda.Style.Add("border-color", " #6a8ccb");
                celda.Style.Add("border-style", "solid");
                celda.Style.Add("border-width", "1px");
            }
        }
        public string[] UsuariosPermisos()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var usuarios = from u in db.PermisoUsuario
                           where u.Usuario == User.Identity.Name
                           select u.Usuario2;

            string[] usuario = { User.Identity.Name };


            return usuarios.ToArray().Union(usuario).ToArray(); ;
        }
    }
}
