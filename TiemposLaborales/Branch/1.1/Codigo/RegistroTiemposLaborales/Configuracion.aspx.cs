using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Authentication;
using System.Web.UI.HtmlControls;

namespace RegistroTiemposLaborales
{
    public partial class Configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarValores(Tipo.Proyectos);
                llenarValores(Tipo.Actividades);
                llenarValores(Tipo.Areas);
            }
        }
        public enum Tipo
        {
            Proyectos,
            Actividades,
            Areas
        }
        public void llenarValores(Tipo e)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                switch (e)
                {
                    case Tipo.Proyectos:

                        var Valor = from v in db.ValorReferencia
                                    orderby v.Descripcion
                                    where v.Codigo == "CLIENTE"
                                    select new { v.Clave, v.Descripcion };


                        Repeater1.DataSource = Valor;

                        Repeater1.DataBind();
                        break;
                    case Tipo.Actividades:
                        var actividades = from v in db.ValorReferencia
                                          orderby v.Descripcion
                                          where v.Codigo == "ACTIVIDAD"
                                          select new { v.Clave, v.Descripcion };


                        repActividad.DataSource = actividades;
                        repActividad.DataBind();
                        break;
                    case Tipo.Areas:
                        var areas = from v in db.ValorReferencia
                                          orderby v.Descripcion
                                          where v.Codigo == "AREA"
                                          select new { v.Clave, v.Descripcion };


                        repAreas.DataSource = areas;
                        repAreas.DataBind();
                        break;
                }
            }
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    lblError.Visible = false;

                    using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                    {

                        var valor = (from v in db.ValorReferencia
                                     where v.Clave.ToString() == e.CommandArgument.ToString()
                                     select v).First();


                        db.ValorReferencia.DeleteOnSubmit(valor);
                        db.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    lblError.Visible = true;
                    updError.Update();
                }

                llenarValores( Tipo.Proyectos);
            }
            if (e.CommandName == "Agregar")
            {
                TextBox txtDescripcion = (TextBox)e.Item.FindControl("txtAgregar");
                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {

                    InsertarCliente(db, Guid.NewGuid(), txtDescripcion.Text);

                    db.SubmitChanges();
                }
                llenarValores(Tipo.Proyectos);
                Control c =  Repeater1.FindControl("txtAgregar");
                c.Focus();
            }

        }
        protected void repActividad_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    lblErrorAct.Visible = false;

                    using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                    {

                        var valor = (from v in db.ValorReferencia
                                     where v.Clave.ToString() == e.CommandArgument.ToString()
                                     select v).First();


                        db.ValorReferencia.DeleteOnSubmit(valor);
                        db.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    lblErrorAct.Text = ex.Message;
                    lblErrorAct.Visible = true;
                    updErrorAct.Update();
                }

                llenarValores(Tipo.Actividades);
            }
            if (e.CommandName == "Agregar")
            {
                TextBox txtDescripcion = (TextBox)e.Item.FindControl("txtAgregar");
                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {

                    InsertarActividad(db, Guid.NewGuid(), txtDescripcion.Text);

                    db.SubmitChanges();
                }
                llenarValores(Tipo.Actividades);
                Control c = Repeater1.FindControl("txtAgregar");
                c.Focus();
            }

        }
        protected void repAreas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    lblErrorAreas.Visible = false;

                    using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                    {
                        Guid clave = new Guid(e.CommandArgument.ToString());
                        var areaAct = (from aa in db.AreaActividad
                                       where aa.Area == clave
                                       select aa);

                        var valor = (from v in db.ValorReferencia
                                     where v.Clave == clave
                                     select v).First();

                        db.AreaActividad.DeleteAllOnSubmit(areaAct);
                        db.ValorReferencia.DeleteOnSubmit(valor);
                        db.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    lblErrorAreas.Text = ex.Message;
                    lblErrorAreas.Visible = true;
                    updErrorAreas.Update();
                }

                llenarValores(Tipo.Areas);
            }else if (e.CommandName == "Agregar")
            {
                TextBox txtDescripcion = (TextBox)e.Item.FindControl("txtAgregar");
                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {

                    InsertarArea(db, Guid.NewGuid(), txtDescripcion.Text);

                    db.SubmitChanges();
                }
                llenarValores(Tipo.Areas);
                Control c = Repeater1.FindControl("txtAgregar");
                c.Focus();
            }
            else if (e.CommandName == "EditarDetalle")
            {
                using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                {
                    string nombreActividad = "";
                    foreach (RepeaterItem i in repAreas.Items)
                    {
                        Control c = i.FindControl("hidClave");
                        if (c != null)
                        {
                            HiddenField hidClave = (HiddenField)c;
                            if (hidClave.Value.ToUpper() == e.CommandArgument.ToString().ToUpper())
                            {
                                nombreActividad = ((TextBox)i.FindControl("TextBoxDescripcion")).Text;
                            }
                        }
                    }
                    lblTituloAarea.Text = nombreActividad;
                    hidClaveArea.Value = e.CommandArgument.ToString();
                    List<ValorReferencia> actividades = (from v in db.ValorReferencia
                                      where v.Codigo == "ACTIVIDAD"
                                                             select v).ToList();
                    List<AreaActividad> areaAct = (from a in db.AreaActividad
                                                   where a.Area == new Guid(e.CommandArgument.ToString())
                                                   select a).ToList();
                    var check = (from a in actividades
                                 join b in areaAct on a.Clave equals b.Actividad into Checks
                                 from ch in Checks.DefaultIfEmpty()
                                 orderby a.Descripcion
                                 select new { a.Clave, a.Descripcion, Check = (ch != null) });
                    chkActividades.Items.Clear();
                    btnGuardarRelaciones.Visible = check.Count() > 0;
                    foreach (var c in check)
                    {
                        ListItem l = new ListItem();
                        l.Value = c.Clave.ToString();
                        l.Selected = c.Check;
                        l.Text = c.Descripcion;
                        chkActividades.Items.Add(l);
                    }
                    updActArea.Update();
                }

            }
        }
        protected void Repeater1_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            Control con = e.Item.FindControl("FILA");
            if (con!= null)
            {
                if (((Repeater)sender).Items.Count % 2 == 0)
                {
                    HtmlTableRow row = (HtmlTableRow)con;
                    row.Style.Add("background-image", "url('images/fondo.gif')");
                    row.Style.Add("background-repeat", "repeat-x");
                    row.Style.Add("background-color", "#a5c2f6");

                    Control text = row.FindControl("TextBoxDescripcion");
                    if (text == null)
                        text = row.FindControl("txtAgregar");
                    ((TextBox)text).Style.Add("background-image", "url('images/fondo.gif')");
                    ((TextBox)text).Style.Add("background-repeat", "repeat-x");
                    ((TextBox)text).Style.Add("background-color", "#a5c2f6");

                }
            }
        }
        protected void BtGuardar_Click(object sender, EventArgs e)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                GuardarValoresReferencia(Repeater1, db, "CLIENTE");
                db.SubmitChanges();
            }
            llenarValores(Tipo.Proyectos);
        }
        protected void btnGuardarAct_Click(object sender, EventArgs e)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                GuardarValoresReferencia(repActividad, db, "ACTIVIDAD");
                db.SubmitChanges();
            }
            llenarValores(Tipo.Actividades);
        }
        protected void btnGuardarAre_Click(object sender, EventArgs e)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                GuardarValoresReferencia(repAreas, db, "AREA");
                db.SubmitChanges();
            }
            llenarValores(Tipo.Areas);
        }
        private void GuardarValoresReferencia(Repeater repetidor, TiempoLaboralDataContext db, string codigo)
        {
            List<ValorReferencia> ValoresReferencia = (from v in db.ValorReferencia
                                                       where v.Codigo == codigo
                                                       select v).ToList();
            foreach (RepeaterItem item in repetidor.Items)
            {
                var row = (from Control r in item.Controls
                           where (r.ID == "FILA")
                           select r).FirstOrDefault();

                if (row != null)
                {
                    var celdaNumero = row.FindControl("hidClave");

                    Guid num = Guid.NewGuid();
                    HiddenField hidClave = (HiddenField)celdaNumero;
                    if (hidClave.Value == "")
                        continue;
                    num = new Guid(hidClave.Value);
                    var descrip = row.FindControl("TextBoxDescripcion");

                    string descripcion = ((TextBox)descrip).Text;

                    if (descripcion.Trim() != "")
                    {
                        var valorRef = (from v in ValoresReferencia
                                        where v.Clave == num
                                        select v).FirstOrDefault();
                        if (valorRef.Descripcion != descripcion)
                        {
                            valorRef.Descripcion = descripcion;

                        }
                    }
                }
            }
        }

        private void InsertarCliente(TiempoLaboralDataContext db, Guid num, string descripcion)
        {
            InsertarValorReferencia(db, num, descripcion, "CLIENTE");
        }
        private void InsertarActividad(TiempoLaboralDataContext db, Guid num, string descripcion)
        {
            InsertarValorReferencia(db, num, descripcion, "ACTIVIDAD");
        }
        private void InsertarArea(TiempoLaboralDataContext db, Guid num, string descripcion)
        {
            InsertarValorReferencia(db, num, descripcion, "AREA");
        }
        private void InsertarValorReferencia(TiempoLaboralDataContext db, Guid num, string descripcion, string codigo)
        {
            ValorReferencia valor = new ValorReferencia();
            valor.Clave = num;
            valor.Codigo = codigo;
            valor.Descripcion = descripcion;
            db.ValorReferencia.InsertOnSubmit(valor);
        }
        
        protected void TextBoxDescripcion_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDescripcion = (TextBox)sender;

            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                InsertarCliente(db, Guid.NewGuid(), txtDescripcion.Text);
                db.SubmitChanges();
            }
            llenarValores(Tipo.Proyectos);

        }
        protected void TextBoxAct_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDescripcion = (TextBox)sender;

            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                InsertarActividad(db, Guid.NewGuid(), txtDescripcion.Text);
                db.SubmitChanges();
            }
            llenarValores(Tipo.Actividades);

        }
        protected void TextBoxAre_TextChanged(object sender, EventArgs e)
        {
            TextBox txtDescripcion = (TextBox)sender;

            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                InsertarArea(db, Guid.NewGuid(), txtDescripcion.Text);
                db.SubmitChanges();
            }
            llenarValores(Tipo.Areas);

        }

        protected void btnGuardarRelaciones_Click(object sender, EventArgs e)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                Guid claveArea = new Guid(hidClaveArea.Value);
                var areaact = from aa in db.AreaActividad
                              where aa.Area == claveArea 
                              select aa;
                db.AreaActividad.DeleteAllOnSubmit(areaact);
                foreach (ListItem i in chkActividades.Items)
                {
                    if (i.Selected)
                    {
                        AreaActividad aa = new AreaActividad();
                        aa.Area = claveArea;
                        aa.Actividad = new Guid(i.Value);
                        db.AreaActividad.InsertOnSubmit(aa);
                    }
                }
                db.SubmitChanges();
            }
            lblModificado.Style["display"] = "none";
            updActArea.Update();
        }

    }
}
