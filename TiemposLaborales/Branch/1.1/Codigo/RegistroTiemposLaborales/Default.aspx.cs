using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Authentication;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
namespace RegistroTiemposLaborales
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (!Page.IsPostBack)
            {
                if (Session["Nombre"] == null)
                {
                    Response.Redirect("Login.aspx", true);
                    return;
                }

                LabelUsuario.Text = Session["Nombre"] == null ? User.Identity.Name : Session["Nombre"].ToString();
                
                
                    if (!JornadaAbierta())
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "boton", "<script language=\"javascript\" type=\"text/javascript\">" +
                            @" function clickBoton() {
                            var o = document.getElementById('" + Button1.ClientID + @"');
                            o.click();
                        }
                        </script>");
                        ModalPopupExtender1.Show();

                   
                }
                llenarCombos();
                llenarTiempos();
                SeleccionarInicial();
                UpdatePanelDataList.Update();
                RadioButtonProyecto.SelectedIndex = 0;
                comboProyecto_SelectedIndexChanged(null, null);
                LabelFechaHora.Text = UltimaFecha().ToString("f");
                UpdateFechaJornada.Update();
                LinkReporteProyecto.NavigateUrl = "ReporteProyectoUsuario.aspx?f1=" + DateTime.Today.ToString("s") + "&f2=" + DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("s");
                LinkGrafica.NavigateUrl = "GraficaTiempoProyecto.aspx?f1=" + DateTime.Today.ToString("s") + "&f2=" + DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("s");
                LinkReporteTiempo.NavigateUrl = "ReporteTiempoLaboral.aspx?f1=" + DateTime.Today.ToString("s") + "&f2=" + DateTime.Today.AddHours(23).AddMinutes(59).AddSeconds(59).ToString("s");
              

            }


           
         
        }
        public bool TiempoAbierto()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            DateTime fechaUltimaJornada = FechaUltimaJornada();
            var jornada = from r in db.RegistroTiempos
                          where r.Usuario == User.Identity.Name
                          && r.FechaInicioJornada.DayOfYear == fechaUltimaJornada.DayOfYear
                          && r.FechaInicioJornada.Year == fechaUltimaJornada.Year
                          && (r.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoEntrada"])
                                || r.Proyecto == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoSalida"]))
                          orderby r.FechaHoraInicial descending
                          select r.Proyecto;


            if (jornada.ToArray().Length == 0)
                return false;
            else
            {
                if (jornada.FirstOrDefault() == new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoSalida"]))
                    return false;

                return true;
            }



        }

        public bool JornadaAbierta()
        {
              TiempoLaboralDataContext db = new TiempoLaboralDataContext();
              var jornada = from j in db.JornadaLaboral
                            where j.FechaInicioJornada.Year == DateTime.Now.Year && j.FechaInicioJornada.DayOfYear == DateTime.Now.DayOfYear 
                         
                            select j;

              if (jornada.Count() > 0)
                  return true;
              else
                  return false;
        }

        public DateTime FechaUltimaJornada()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var jornada = (from j in db.JornadaLaboral
                          orderby j.FechaInicioJornada descending 
                          select j.FechaInicioJornada).FirstOrDefault();


            return jornada;
            
        }

        private void SeleccionarInicial()
        {
            string primerGrupo = Session["Grupos"].ToString().Trim().ToUpper().Split(new char[]{','})[0];
            foreach(ListItem i in comboAreas.Items)
                if (i.Text.ToUpper().Trim() == primerGrupo )
                {
                    comboAreas.SelectedIndex = -1;
                    i.Selected = true;
                    comboAreas_SelectedIndexChanged(comboAreas, EventArgs.Empty);
                }

        }


        public void llenarCombos()
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                var Clientes = from C in db.ValorReferencia
                               where C.Codigo == "CLIENTE"
                               orderby C.Descripcion
                               select C;

                comboCliente.DataSource = Clientes;
                comboCliente.DataTextField = "Descripcion";
                comboCliente.DataValueField = "Clave";

                comboCliente.DataBind();


                var Proyecto = from C in db.ValorReferencia
                               where C.Codigo == "TIPOTIEMPO" && C.Clave != new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoEntrada"])
                               select C;



                RadioButtonProyecto.DataSource = Proyecto;
                RadioButtonProyecto.DataTextField = "Descripcion";
                RadioButtonProyecto.DataValueField = "Clave";

                RadioButtonProyecto.DataBind();

                var Areas = from C in db.ValorReferencia
                            where C.Codigo == "AREA"
                            orderby C.Descripcion
                            select C;

                comboAreas.DataSource = Areas;
                comboAreas.DataTextField = "Descripcion";
                comboAreas.DataValueField = "Clave";

                comboAreas.DataBind();

                llenarActividades(db, new Guid(comboAreas.SelectedValue));
            }
        }
        public void llenarActividades(TiempoLaboralDataContext db, Guid area)
        {
            var Actividades = from C in db.ValorReferencia
                              where C.AreaActividad1.Any(p => p.Area == area)
                              orderby C.Descripcion
                              select C;

            comboActividades.DataSource = Actividades;
            comboActividades.DataTextField = "Descripcion";
            comboActividades.DataValueField = "Clave";

            comboActividades.DataBind();

        }
        public void llenarTiempos()
        {
        
                TiempoLaboralDataContext db = new TiempoLaboralDataContext();
                var Tiempos = (from T in db.RegistroTiempos
                               where T.Usuario == User.Identity.Name
                               orderby T.FechaHoraInicial descending
                               select new
                               {
                                   T.Descripcion,
                                   T.Horas,
                                   T.FechaHoraInicial,
                                   Cliente = T.ValorReferencia == null ? "" : T.ValorReferencia.Descripcion,
                                   Proyecto = T.ValorReferencia1.Descripcion,
                                   P = ((T.Proyecto == null) || (T.Proyecto.ToString() != System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"])),
                                   Actividad = T.ValorReferencia2 == null ? "" : T.ValorReferencia2.Descripcion,
                                   Area = T.ValorReferencia3 == null ? "": T.ValorReferencia3.Descripcion
                               }).Take(10);

                Repeater1.DataSource = Tiempos;
                Repeater1.DataBind();


                if (!TiempoAbierto())
                
                    RadioButtonProyecto.Visible = false;
            
                else
                    RadioButtonProyecto.Visible = true;

                LabelEntrada.Visible = !RadioButtonProyecto.Visible;

                UpdatePanelProyecto.Update();
         
                
        }

        public DateTime UltimaFecha()
        {

            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var Tiempos = (from J in db.JornadaLaboral
                           orderby J.FechaInicioJornada descending
                           select J.FechaInicioJornada).FirstOrDefault();
            if (Tiempos == DateTime.MinValue)
                Tiempos = DateTime.Now;
            return Tiempos;

        }

        protected void btAgregarHoras_Click(object sender, EventArgs e)
        {
            if (valHoras.IsValid)
            {
                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {
                    CostoUsuarioHora costousuario = (from c in db.CostoUsuarioHora
                                                     where c.Usuario == User.Identity.Name
                                                     select c).FirstOrDefault();
                    
                    RegistroTiempos nuevoTiempo = new RegistroTiempos();
                    nuevoTiempo.Usuario = User.Identity.Name;
                    nuevoTiempo.FechaHoraInicial = DateTime.Now;
                    nuevoTiempo.FechaInicioJornada = FechaUltimaJornada();
                    Guid proyecto = RadioButtonProyecto.Visible ? new Guid(RadioButtonProyecto.SelectedValue) : new Guid(System.Configuration.ConfigurationManager.AppSettings["TipoTiempoEntrada"]);
                    nuevoTiempo.Proyecto = proyecto;
                    if (proyecto.ToString().ToUpper() == System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"].ToUpper())
                    {
                        nuevoTiempo.Cliente = new Guid(comboCliente.SelectedValue);
                        nuevoTiempo.Actividad = new Guid(comboActividades.SelectedValue);
                        nuevoTiempo.Area = new Guid(comboAreas.SelectedValue);
                        nuevoTiempo.Horas = double.Parse(txtHoras.Text);
                    }
                    nuevoTiempo.Descripcion = txtDescripcion.Text;
                    if (costousuario != null)
                        nuevoTiempo.CostoTotal = costousuario.Costo * Convert.ToDecimal(nuevoTiempo.Horas);
                    db.RegistroTiempos.InsertOnSubmit(nuevoTiempo);
                    db.SubmitChanges();
                }
                llenarTiempos();
                comboProyecto_SelectedIndexChanged(RadioButtonProyecto, EventArgs.Empty);
                UpdatePanelDataList.Update();

                txtDescripcion.Text = "";
                UpdatePanelDescripcion.Update();

                txtHoras.Text = "";
                UpdatePanelHoras.Update();



            }


        }

        protected void valHoras_ServerValidate(object source, ServerValidateEventArgs args)
        {
            double temp;
            if (RadioButtonProyecto.Visible && RadioButtonProyecto.SelectedValue.ToUpper() == System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"].ToUpper() && comboActividades.SelectedValue == "")
            {
                valHoras.ErrorMessage = "Se tiene que seleccionar la actividad a aplicar el tiempo";
                args.IsValid = false;
            }
            else if (double.TryParse(args.Value, out temp) || !RadioButtonProyecto.Visible || RadioButtonProyecto.SelectedValue.ToUpper() != System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"].ToUpper())
            {
                valHoras.ErrorMessage = "";

                args.IsValid = true;
            }
            else
            {
                valHoras.ErrorMessage = "El valor capturado tiene que ser un valor numerico";

                args.IsValid = false;
            }
            UpdatePanelHoras.Update();
            UpdatePanelValidator.Update();
        }

        protected void comboProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool visibilidad = !((!RadioButtonProyecto.Visible) || (RadioButtonProyecto.SelectedValue.ToUpper() != System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"].ToUpper()));
            if (!visibilidad)
            {
                txtHoras.Text = "";
            }
            hidOcultar.Value = (!visibilidad).ToString();
            txtHoras.Visible = visibilidad;
            comboCliente.Visible = visibilidad;
            comboActividades.Visible = visibilidad;
            comboAreas.Visible = visibilidad;

            UpdatePanelHoras.Update();
            UpdatePanelCliente.Update();
            UpdatePanelActividades.Update();
            UpdatePanelAreas.Update();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                DateTime fecha = DateTime.Parse(e.CommandArgument.ToString());
                borrarRegistro(fecha);
                
                
            }

        }

        public void borrarRegistro(DateTime fecha)
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var deleteTiempo =
               from t in db.RegistroTiempos
               where t.FechaHoraInicial == fecha && t.Usuario==User.Identity.Name
               select t;

            foreach (var t in deleteTiempo)
            {
                db.RegistroTiempos.DeleteOnSubmit(t);
            }

                db.SubmitChanges();
          
            llenarTiempos();
            UpdatePanelDataList.Update();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {

            abrirJornada();
        }

        public void abrirJornada()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();

            JornadaLaboral nuevaJornada = new JornadaLaboral();
            nuevaJornada.Usuario = User.Identity.Name;
            nuevaJornada.FechaInicioJornada= DateTime.Now;

            db.JornadaLaboral.InsertOnSubmit(nuevaJornada);
            db.SubmitChanges();

            LabelFechaHora.Text = UltimaFecha().ToString("f");
            UpdateFechaJornada.Update();
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
        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var row = (from Control r in e.Item.Controls
                      where r.ID=="FILA"
                      select r).FirstOrDefault();

            if (row!=null)
            {
                if (Repeater1.Items.Count % 2 == 0)
                {
                    ((HtmlTableRow)row).Style.Add("background-image", "url('images/fondo.gif')");
                    ((HtmlTableRow)row).Style.Add("background-repeat", "repeat-x");
                    ((HtmlTableRow)row).Style.Add("background-color", "#a5c2f6");

                    

                }
              
            }
            
        }

        protected void comboAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                llenarActividades(db, new Guid(comboAreas.SelectedValue));
            }
            UpdatePanelActividades.Update();
        }
    }
}
