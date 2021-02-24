using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using InfoSoftGlobal;
namespace RegistroTiemposLaborales
{
    public partial class GraficaTiempoProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            DateTime Fecha1 = DateTime.Parse(Request.QueryString["f1"]);
            DateTime Fecha2 = DateTime.Parse(Request.QueryString["f2"]);
            CalendarExtenderFecha1.SelectedDate = Fecha1;
            CalendarExtenderFecha2.SelectedDate = Fecha2;
        }

       
        public string generarGraficaBarras()
        {
        
        ArrayList arrayCliente = new ArrayList();
        ArrayList arrayHoras = new ArrayList();



        DateTime Fecha1 = DateTime.Parse(Request.QueryString["f1"]);
        DateTime Fecha2 = DateTime.Parse(Request.QueryString["f2"]);


        TiempoLaboralDataContext db = new TiempoLaboralDataContext();

        var Proyecto = from p in db.ValorReferencia
                       where p.Codigo == "CLIENTE"
                          select p ;

            Random r1 = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < Proyecto.Count(); i++)
            {


                double? Horas = (from h in db.RegistroTiempos
                                 where (UsuariosPermisos().Contains(h.Usuario) && h.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"]) && h.Cliente == Proyecto.Skip(i).FirstOrDefault().Clave && Fecha1 <= h.FechaInicioJornada && Fecha2 >= h.FechaInicioJornada)
                                 select (double?)h.Horas).Sum();

                if (Horas != null)
                {
                    arrayCliente.Add(Proyecto.Skip(i).FirstOrDefault().Descripcion);
                    arrayHoras.Add(Horas);
                }

            }


        String[,] arrData = new String[arrayCliente.Count, 3];

        
        for (int y =0;y <= arrayCliente.Count - 1;y ++)
            {
            arrData[y, 0] = arrayCliente[y].ToString();
            arrData[y, 1]  = arrayHoras[y].ToString();
        
            }
        
            string strXML,strCategories,strDataCurr;
         

        strXML = "<graph caption='Horas por Proyecto' numberPrefix='Horas ' decimalPrecision='1' >";

 
        strCategories = "<categories>";

        //'Titulo Por Filtro
     
      



                strDataCurr = "<dataset seriesName='Clientes' color='AFD8F8'>";
               



                for (int i = 0; i < arrayCliente.Count ; i++)
                {

                    strCategories = strCategories + "<category name='" + arrData[i, 0] + "' />";

                    strDataCurr = strDataCurr + "<set value='" + arrData[i, 1] + "' />";
                  
                }
           
        


        strCategories = strCategories + "</categories>";


        strDataCurr = strDataCurr + "</dataset>";
        

       
        strXML = strXML + strCategories + strDataCurr  + "</graph>";

        
        return FusionCharts.RenderChart("Graficas/MSColumn3D.swf", "", strXML, "HOrasxProyecto", "900", "300", false, false);

        }

        protected void ButtonGenerar_Click(object sender, EventArgs e)
        {
            char[] separador = { '/' };

            DateTime Fecha1 = new DateTime(int.Parse(TextBoxFecha1.Text.Split(separador)[2]), int.Parse(TextBoxFecha1.Text.Split(separador)[1]), int.Parse(TextBoxFecha1.Text.Split(separador)[0]), 0, 0, 0);
            DateTime Fecha2 = new DateTime(int.Parse(TextBoxFecha2.Text.Split(separador)[2]), int.Parse(TextBoxFecha2.Text.Split(separador)[1]), int.Parse(TextBoxFecha2.Text.Split(separador)[0]), 23, 59, 59);
            Response.Redirect("GraficaTiempoProyecto.aspx?f1=" + Fecha1.ToString("s") + "&f2=" + Fecha2.ToString("s"));

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
