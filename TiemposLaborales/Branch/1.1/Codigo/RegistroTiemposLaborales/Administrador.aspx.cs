using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace RegistroTiemposLaborales
{
    public partial class Administrador : System.Web.UI.Page
    {
        public List<ValorReferencia> Clientes
        {
            get
            {
                if (Session["comboClientes"] == null)
                    return null;
                return (List<ValorReferencia>)Session["comboClientes"];
            }
            set
            {
                Session["comboClientes"] = value;
            }
        }
        public List<ValorReferencia> Actividades
        {
            get
            {
                if (Session["comboActividades"] == null)
                    return null;
                return (List<ValorReferencia>)Session["comboActividades"];
            }
            set
            {
                Session["comboActividades"] = value;
            }
        }
        public List<ValorReferencia> TipoTiempos
        {
            get
            {
                if (Session["comboTipoTiempo"] == null)
                    return null;
                return (List<ValorReferencia>)Session["comboTipoTiempo"];
            }
            set
            {
                Session["comboTipoTiempo"] = value;
            }
        }
        public List<ValorReferencia> Areas
        {
            get
            {
                if (Session["comboArea"] == null)
                    return null;
                return (List<ValorReferencia>)Session["comboArea"];
            }
            set
            {
                Session["comboArea"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TxtFechaHora.Attributes.Add("readonly", "readonly");
                TxtDiaTrabajo.Text = DateTime.Today.ToString("dd/MM/yyyy");

                ComboUsuario.DataSource = UsuariosPermisos();
                ComboUsuario.DataBind();
                CargarCombos();
                pnlEdicion.Visible = !(ComboUsuario.Items.Count == 0);
                lblNoSeEdita.Visible = (ComboUsuario.Items.Count == 0);
                comboClienteFuera.DataBind();
                comboAreaFuera.DataBind();
                comboActividadFuera.DataBind();
                comboProyecto.DataBind();
                comboProyecto_SelectedIndexChanged(null, null);
                ActualizarDataSourceRepeater();

                TxtFechaHora.Text = DateTime.Today.ToString("dd/MM/yyyy hh:mm:ss tt");

            }
            this.Focus();
        }

        private void CargarCombos()
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                var clientes = from C in db.ValorReferencia
                               where C.Codigo == "CLIENTE"
                               orderby C.Descripcion
                               select C;
                Clientes = clientes.ToList();
                Clientes.Insert(0, new ValorReferencia());
                var actividades = from C in db.ValorReferencia
                                  where C.Codigo == "ACTIVIDAD"
                                  orderby C.Descripcion
                                  select C;
                Actividades = actividades.ToList();
                Actividades.Insert(0, new ValorReferencia());
                var tipotiempo = from C in db.ValorReferencia
                                 where C.Codigo == "TIPOTIEMPO"
                                 orderby C.Descripcion
                                 select C;
                TipoTiempos = tipotiempo.ToList();
                var areas = from C in db.ValorReferencia
                                 where C.Codigo == "AREA"
                                 orderby C.Descripcion
                                 select C;
                Areas = areas.ToList();
                Areas.Insert(0, new ValorReferencia());

            }
        }
       
       
        public string RecuperaEvento()
        {

            this.Title = "asd";

            return "CambioDiaTrabajo";
        }

        public string[] UsuariosPermisos()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
            var usuarios = from u in db.PermisoUsuario
                           where u.Usuario == User.Identity.Name
                           select u.Usuario2;            

            return usuarios.ToArray().OrderBy(a => a).ToArray();
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {

                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {
                    var eliminar = from t in db.RegistroTiempos
                                   where (t.Usuario == ComboUsuario.SelectedValue && t.FechaHoraInicial == DateTime.Parse(e.CommandArgument.ToString()))
                                   select t;

                    var Fila = from Control s in ((System.Web.UI.WebControls.Repeater)source).Controls
                               where s.FindControl("txtDescripcionR") != null && ((System.Web.UI.WebControls.ImageButton)s.FindControl("btnGuardar")).CommandArgument.ToString() == e.CommandArgument.ToString()
                               select ((System.Web.UI.HtmlControls.HtmlTableRow)s.FindControl("FILA"));


                    foreach (var t in eliminar)
                    {
                        db.RegistroTiempos.DeleteOnSubmit(t);
                    }
                    db.SubmitChanges();
                    Fila.FirstOrDefault().Visible = false;
                }

            }
            else if (e.CommandName == "Guardar")
            {
                ((ImageButton)e.Item.FindControl("btnEliminar")).ToolTip = "Borrar Registro";
                ((ImageButton)e.Item.FindControl("btnEliminar")).CommandName = "Eliminar";
                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {
                    DateTime fechainicial = DateTime.Parse(e.CommandArgument.ToString());
                    var guardar = (from t in db.RegistroTiempos
                                   where (t.Usuario == ComboUsuario.SelectedValue && t.FechaHoraInicial == fechainicial)
                                   select t).First();

                    string descripcion = "";
                    Control c = e.Item.FindControl("txtDescripcionR");
                    if (c != null)
                        descripcion = ((TextBox)c).Text;

                    Guid cliente = Guid.Empty;
                    c = e.Item.FindControl("comboCliente");
                    if (c != null)
                        cliente = new Guid(((DropDownList)c).SelectedValue);

                    Guid actividad = Guid.Empty;
                    c = e.Item.FindControl("comboActividad");
                    if (c != null)
                        actividad = new Guid(((DropDownList)c).SelectedValue);

                    Guid area = Guid.Empty;
                    c = e.Item.FindControl("comboArea");
                    if (c != null)
                        area = new Guid(((DropDownList)c).SelectedValue);

                    double hora = 0;
                    c = e.Item.FindControl("txtControl");
                    if (c != null)
                        hora = Convert.ToDouble(((TextBox)c).Text);


                    c = e.Item.FindControl("btnGuardar");
                    decimal horas = Convert.ToDecimal(guardar.Horas);
                    decimal costoporhora = 0;
                    if (horas > 0)
                        costoporhora = guardar.CostoTotal / horas;

                    guardar.Horas = hora;
                    guardar.CostoTotal = costoporhora * horas;
                    guardar.Descripcion = descripcion;
                    if (cliente == Guid.Empty)
                        guardar.Cliente = null;
                    else
                        guardar.Cliente = cliente;

                    if (actividad == Guid.Empty)
                        guardar.Actividad = null;
                    else
                        guardar.Actividad = actividad;

                    if (area == Guid.Empty)
                        guardar.Area = null;
                    else
                        guardar.Area = area;

                    c.Visible = false;
                    db.SubmitChanges();
                }
            }
            else if (e.CommandName == "Cancelar")
            {
                ((ImageButton)e.Item.FindControl("btnEliminar")).ToolTip = "Borrar Registro";
                ((ImageButton)e.Item.FindControl("btnEliminar")).CommandName = "Eliminar";

                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {

                    var guardar = (from t in db.RegistroTiempos
                                   where (t.Usuario == ComboUsuario.SelectedValue && t.FechaHoraInicial == DateTime.Parse(e.CommandArgument.ToString()))
                                   select t).First();

                    Control c = e.Item.FindControl("txtDescripcionR");
                    if (c != null)
                        ((TextBox)c).Text = guardar.Descripcion;

                    c = e.Item.FindControl("comboCliente");
                    if (c != null)
                        ((DropDownList)c).SelectedIndex = (((DropDownList)c).Items.IndexOf(((DropDownList)c).Items.FindByValue(guardar.Cliente.ToString())));

                    c = e.Item.FindControl("comboArea");
                    if (c != null)
                        ((DropDownList)c).SelectedIndex = (((DropDownList)c).Items.IndexOf(((DropDownList)c).Items.FindByValue(guardar.Area.ToString())));

                    c = e.Item.FindControl("comboActividad");
                    if (c != null)
                        ((DropDownList)c).SelectedIndex = (((DropDownList)c).Items.IndexOf(((DropDownList)c).Items.FindByValue(guardar.Actividad.ToString())));

                    c = e.Item.FindControl("txtControl");
                    if (c != null)
                        ((TextBox)c).Text = guardar.Horas.ToString();

                    c = e.Item.FindControl("btnGuardar");
                    if (c != null)
                        c.Visible = false;
                }
            }
        }

      


        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            var row = (from Control r in e.Item.Controls
                       where (r.ID == "FILA")
                       select r).FirstOrDefault();

            if (row != null)
            {
                if (Repeater1.Items.Count % 2 == 0)
                {
                    ((HtmlTableRow)row).Style.Add("background-image", "url('images/fondo.gif')");
                    ((HtmlTableRow)row).Style.Add("background-repeat", "repeat-x");
                    ((HtmlTableRow)row).Style.Add("background-color", "#a5c2f6");


                    var celda = (from Control r in row.Controls
                                 where (r.ID == "Descripcion")
                                 select r).FirstOrDefault();

                    var text = (from Control r in celda.Controls
                                where (r.ID == "txtDescripcionR")
                                select r).FirstOrDefault();

                    ((TextBox)text).Style.Add("background-image", "url('images/fondo.gif')");
                    ((TextBox)text).Style.Add("background-repeat", "repeat-x");
                    ((TextBox)text).Style.Add("background-color", "#a5c2f6");


                    var celdaCliente = (from Control r in row.Controls
                                        where (r.ID == "Cliente")
                                 select r).FirstOrDefault();

                    var textCliente = (from Control r in celdaCliente.Controls
                                       where (r.ID == "comboCliente")
                                select r).FirstOrDefault();

                    ((DropDownList)textCliente).Style.Add("background-image", "url('images/fondo.gif')");
                    ((DropDownList)textCliente).Style.Add("background-repeat", "repeat-x");
                    ((DropDownList)textCliente).Style.Add("background-color", "#a5c2f6");

                 
                }
            }
        }

        protected void BtGuardar_Click(object sender, EventArgs e)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("es-MX", true);
            DateTime dtFechaInicio = DateTime.ParseExact(TxtFechaHora.Text, "dd/MM/yyyy hh:mm:ss tt", culture);
            DateTime dtJornadaTemp = DateTime.ParseExact(TxtDiaTrabajo.Text, "dd/MM/yyyy", culture);




            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                bool salir = false;
                do
                {
                    var existe = (from x in db.RegistroTiempos
                                  where dtFechaInicio == x.FechaHoraInicial && x.Usuario == ComboUsuario.SelectedValue
                                  select x.FechaHoraInicial).Count();

                    if (existe > 0)
                    {
                        dtFechaInicio = dtFechaInicio.AddMilliseconds(1);
                    }
                    else
                    {
                        salir = true;
                    }
                }
                while (!salir);

                var jornada = from i in db.JornadaLaboral
                              where dtJornadaTemp.DayOfYear == i.FechaInicioJornada.DayOfYear && dtJornadaTemp.Year == i.FechaInicioJornada.Year
                              select i.FechaInicioJornada;


                Guid cliente = new Guid(comboClienteFuera.SelectedValue);
                Guid tipotiempo = new Guid(comboProyecto.SelectedValue);
                Guid actividad = new Guid(comboActividadFuera.SelectedValue);
                Guid area = new Guid(comboAreaFuera.SelectedValue);

                RegistroTiempos nuevoTiempo = new RegistroTiempos();
                nuevoTiempo.Usuario = ComboUsuario.SelectedValue;
                nuevoTiempo.FechaHoraInicial = dtFechaInicio;
                nuevoTiempo.FechaInicioJornada = jornada.FirstOrDefault();
                nuevoTiempo.Horas = double.Parse(txtHoras.Text);

                CostoUsuarioHora costousuario = (from c in db.CostoUsuarioHora
                                                 where c.Usuario == nuevoTiempo.Usuario 
                                                 select c).FirstOrDefault();
                if (costousuario != null)
                    nuevoTiempo.CostoTotal = costousuario.Costo * Convert.ToDecimal(nuevoTiempo.Horas);

                if (tipotiempo != Guid.Empty)
                    nuevoTiempo.Proyecto = tipotiempo;
                if (cliente != Guid.Empty)
                    nuevoTiempo.Cliente = cliente;
                if (actividad != Guid.Empty)
                    nuevoTiempo.Actividad = actividad;
                if (area != Guid.Empty)
                    nuevoTiempo.Area = area;
                nuevoTiempo.Descripcion = TxtDescripcion.Text;
                db.RegistroTiempos.InsertOnSubmit(nuevoTiempo);
                db.SubmitChanges();
            }
            ActualizarDataSourceRepeater();
        }

        protected void TxtDiaTrabajo_TextChanged(object sender, EventArgs e)
        {
            ActualizarDataSourceRepeater();
        }

        public void ActualizarDataSourceRepeater()
        {
            TiempoLaboralDataContext db = new TiempoLaboralDataContext();
          char[] separador = { '/' };
          DateTime Jornada;
          if (TxtDiaTrabajo.Text.Split(separador).Length != 3)
              Jornada = DateTime.Today;
          else
          {
              try
              {
                  Jornada = new DateTime(int.Parse(TxtDiaTrabajo.Text.Split(separador)[2]), int.Parse(TxtDiaTrabajo.Text.Split(separador)[1]), int.Parse(TxtDiaTrabajo.Text.Split(separador)[0]), 0, 0, 0);
              }
              catch
              {
                  Jornada = DateTime.Today;
              }
          }


          var Tiempos = (from T in db.RegistroTiempos
                         where T.Usuario == ComboUsuario.SelectedValue && T.FechaInicioJornada.DayOfYear == Jornada.DayOfYear && T.FechaInicioJornada.Year == Jornada.Year
                         orderby T.FechaHoraInicial descending
                         select new
                         {
                             T.Descripcion,
                             Horas = String.Format("{0:0.00}", T.Horas),
                             T.FechaHoraInicial,
                             Cliente = T.ValorReferencia.Descripcion,
                             Proyecto = T.ValorReferencia1.Descripcion,
                             PValor = T.Proyecto.ToString().ToUpper() == System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"].ToUpper(),
                             CValor = T.Cliente,
                             AValor = T.Actividad,
                             ArValor = T.Area
                         });
                           //select new { T.Descripcion,Horas=  T.Horas.ToString().IndexOf(".")  == -1 ? T.Horas.ToString() + ".0" : T.Horas.ToString() ,  T.FechaHoraInicial, Cliente = C.Descripcion, Proyecto = P.Descripcion, PValor = T.Proyecto,CValor=C.Clave }).Take(10);

 

            Repeater1.DataSource = Tiempos;
            Repeater1.DataBind();
          
        }

        protected void ComboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarDataSourceRepeater();
        }

        protected void ComboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((System.Web.UI.WebControls.DropDownList)sender).FindControl("btnGuardar").Visible == false)
            {
                ((System.Web.UI.WebControls.DropDownList)sender).FindControl("btnGuardar").Visible = true;
                ((ImageButton)((System.Web.UI.WebControls.DropDownList)sender).FindControl("btnEliminar")).ToolTip = "Cancelar Cambios ";
                ((ImageButton)((System.Web.UI.WebControls.DropDownList)sender).FindControl("btnEliminar")).CommandName = "Cancelar";
            }
        }

        protected void TxtDescripcionRepeater_TextChanged(object sender, EventArgs e)
        {
            if (((System.Web.UI.WebControls.TextBox)sender).FindControl("btnGuardar").Visible==false)
            {
                ((System.Web.UI.WebControls.TextBox)sender).FindControl("btnGuardar").Visible = true;
                ((ImageButton)((System.Web.UI.WebControls.TextBox)sender).FindControl("btnEliminar")).ToolTip = "Cancelar Cambios";
                ((ImageButton)((System.Web.UI.WebControls.TextBox)sender).FindControl("btnEliminar")).CommandName = "Cancelar";
                if (Request.Browser.Type.ToString().ToLower().StartsWith("firefox"))
                {
                    ((System.Web.UI.WebControls.TextBox)sender).Focus();
                }
              
            }
        }

        protected void TxtHoraRepeater_TextChanged(object sender, EventArgs e)
        {


            if (((System.Web.UI.WebControls.TextBox)sender).FindControl("btnGuardar").Visible==false)
            {
                ((System.Web.UI.WebControls.TextBox)sender).FindControl("btnGuardar").Visible = true;
                ((ImageButton)((System.Web.UI.WebControls.TextBox)sender).FindControl("btnEliminar")).ToolTip = "Cancelar Cambios";
                ((ImageButton)((System.Web.UI.WebControls.TextBox)sender).FindControl("btnEliminar")).CommandName = "Cancelar";
               
            }
        }




        protected void comboProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboProyecto.SelectedValue.ToUpper() != System.Configuration.ConfigurationManager.AppSettings["TipoTiempoProyecto"].ToUpper())
            {
                comboClienteFuera.SelectedValue = Guid.Empty.ToString();
                comboActividadFuera.SelectedValue = Guid.Empty.ToString();
                txtHoras.Text = "0";
                txtHoras.Enabled = false;
                comboClienteFuera.Enabled = false;
                comboActividadFuera.Enabled = false;
                comboAreaFuera.Enabled = false;
            }
            else
            {
                txtHoras.Enabled = true;
                comboClienteFuera.Enabled = true;
                comboActividadFuera.Enabled = true;
                comboAreaFuera.Enabled = true;
            }
        }
    }
}
