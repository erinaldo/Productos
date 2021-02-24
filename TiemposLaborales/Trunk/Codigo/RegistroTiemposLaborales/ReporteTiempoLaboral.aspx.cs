using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroTiemposLaborales
{
    public partial class ReporteTiempoLaboral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if(!Page.IsPostBack)
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

        public void generarTabla()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            char[] separador = { '/' };
            
            //DateTime Fecha1 = new DateTime(int.Parse(TextBoxFecha1.Text.Split(separador)[2]), int.Parse(TextBoxFecha1.Text.Split(separador)[1]), int.Parse(TextBoxFecha1.Text.Split(separador)[0]), 0, 0, 0);
            //DateTime Fecha2 = new DateTime(int.Parse(TextBoxFecha2.Text.Split(separador)[2]), int.Parse(TextBoxFecha2.Text.Split(separador)[1]), int.Parse(TextBoxFecha2.Text.Split(separador)[0]), 23, 59, 59);

            DateTime Fecha1 =DateTime.Parse(Request.QueryString["f1"]);
            DateTime Fecha2 = DateTime.Parse(Request.QueryString["f2"]);

            DateTime FechaT = Fecha1;

          
 



            DataTable tDatos = new DataTable();
            tDatos.Columns.Add("Usuario", typeof(string));
            tDatos.Columns.Add("link", typeof(string));
            tDatos.Columns.Add("Horas", typeof(double));
            tDatos.Columns.Add("HorasRegistradas", typeof(double));

            string[] sUsuarios = UsuariosPermisos();
            string[] usuario = {User.Identity.Name};
            sUsuarios = UsuariosPermisos();
    
            for (int u = 0; u < sUsuarios.Length; u++)//Por CAda Usuario
            {
                TimeSpan TiempoTotal = new TimeSpan();
                double HorasRegistradasxProyecto = 0;

                for (int i = 0; i < (Fecha2 - Fecha1).Days + 1; i++)//Por Cada Dia
                {
                    FechaT = Fecha1.AddDays(i);
                    var Dia = from d in db.RegistroTiempos
                              where d.Proyecto != new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && d.Usuario == sUsuarios[u] && d.FechaInicioJornada.DayOfYear == FechaT.DayOfYear && d.FechaInicioJornada.Year == FechaT.Year
                              select d.FechaHoraInicial;

                    List<DateTime> horas = Dia.ToList<DateTime>();

                    if (horas.Count % 2 != 0)//si no cerro jornada
                    {

                        if (FechaT.DayOfYear == DateTime.Now.DayOfYear && FechaT.Year == DateTime.Now.Year)
                            horas.Add(DateTime.Now);
                        else
                        {
                            var UltimaHora = (from d in db.RegistroTiempos
                                              where d.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && d.Usuario == sUsuarios[u] && d.FechaInicioJornada.DayOfYear == FechaT.DayOfYear && d.FechaInicioJornada.Year == FechaT.Year
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
                                     where d.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && d.Usuario == sUsuarios[u] && d.FechaHoraInicial.DayOfYear == FechaT.DayOfYear && d.FechaHoraInicial.Year == FechaT.Year
                                     select (double?)d.Horas).Sum();

                    if (Horas != null)
                       HorasRegistradasxProyecto += (double)Horas;



                }

                //tDatos.Rows.Add(new object[] { sUsuarios[u],"ReporteTiempoLaboralUsuario.aspx?u="+sUsuarios[u], Math.Round(TiempoTotal.TotalHours, 0), Math.Round(HorasRegistradasxProyecto, 0) });
                tDatos.Rows.Add(new object[] { sUsuarios[u], "ReporteTiempoLaboralUsuario.aspx?u=" + sUsuarios[u] + "&f1=" + Fecha1.ToString("s").Replace(":", "..").Replace("-", "_") + "&f2=" + Fecha2.ToString("s").Replace(":", "..").Replace("-", "_"), Math.Round(TiempoTotal.TotalHours, 0), Math.Round(HorasRegistradasxProyecto, 0) });

            
            }

            GridView1.DataSource = tDatos;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            char[] separador = { '/' };

            DateTime Fecha1 = new DateTime(int.Parse(TextBoxFecha1.Text.Split(separador)[2]), int.Parse(TextBoxFecha1.Text.Split(separador)[1]), int.Parse(TextBoxFecha1.Text.Split(separador)[0]), 0, 0, 0);
            DateTime Fecha2 = new DateTime(int.Parse(TextBoxFecha2.Text.Split(separador)[2]), int.Parse(TextBoxFecha2.Text.Split(separador)[1]), int.Parse(TextBoxFecha2.Text.Split(separador)[0]), 23, 59, 59);
            Response.Redirect("ReporteTiempoLaboral.aspx?f1=" + Fecha1.ToString("s")+"&f2="+Fecha2.ToString("s"));


            
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {

            foreach (TableCell celda in e.Row.Cells)
            { 
                celda.Style.Add("border-color"," #6a8ccb"); 
                celda.Style.Add("border-style","solid");
                celda.Style.Add("border-width","1px");
            }

            
        }

        public string[] UsuariosPermisos()
        {
               TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var usuarios = from u in db.PermisoUsuario
                          where u.Usuario== User.Identity.Name
                          select u.Usuario2;

            string[] usuario = { User.Identity.Name };


           return usuarios.ToArray().Union(usuario).ToArray().OrderBy( a => a).ToArray() ;
        }
    }
}
