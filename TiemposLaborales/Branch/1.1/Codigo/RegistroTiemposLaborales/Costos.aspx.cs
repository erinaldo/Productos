using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistroTiemposLaborales
{
    public partial class Costos : System.Web.UI.Page
    {
        public List<CostoUsuarioHora> CostosUsuarios
        {
            get
            {
                if (Session["CostosUsuarios"] == null)
                    return null;
                return (List<CostoUsuarioHora>)Session["CostosUsuarios"];
            }
            set
            {
                Session["CostosUsuarios"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                CargarCostos();
            }
        }

        private void CargarCostos()
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                var costosusuario = from c in db.CostoUsuarioHora
                                     select c;
                CostosUsuarios = costosusuario.ToList();
            }
            repRecursos.DataSource = CostosUsuarios;
            repRecursos.DataBind();
        }
        

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool actualizado = false;
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                List<CostoUsuarioHora> costosusuario = (from c in db.CostoUsuarioHora
                                    select c).ToList();
                foreach (RepeaterItem i in repRecursos.Items)
                {

                    string usuario = ((Label)i.FindControl("lblUsuario")).Text.Trim().ToLower();
                    decimal costo = Convert.ToDecimal(((TextBox)i.FindControl("txtNuevo")).Text.Trim());
                    short horas = Convert.ToInt16(((TextBox)i.FindControl("txtNuevoHorasS")).Text.Trim());
                    CostoUsuarioHora usu = (from u in costosusuario
                                            where u.Usuario == usuario
                                            select u).FirstOrDefault();
                    if (usu != null)
                    {
                        if ((usu.Costo != costo)||(usu.HorasSemanales != horas))
                        {
                            actualizado = true;
                            if (usu.Costo != costo)
                                usu.Costo = costo;
                            if (usu.HorasSemanales != horas)
                                usu.HorasSemanales = horas;
                        }
                    }
                }
                if (actualizado)
                    db.SubmitChanges();
            }
            if (actualizado)
            {
                CargarCostos();
                updRecusos.Update();
            }
        }

        protected void repRecursos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                if (e.CommandName == "Agregar")
                {
                    string usuario = ((TextBox)e.Item.FindControl("txtUsuario")).Text.Trim().ToLower();
                    decimal costo = Convert.ToDecimal(((TextBox)e.Item.FindControl("txtCosto")).Text.Trim());
                    short horas = Convert.ToInt16(((TextBox)e.Item.FindControl("txtHorasSemanales")).Text.Trim());
                    using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
                    {
                        CostoUsuarioHora CostoUsu = new CostoUsuarioHora();
                        CostoUsu.Usuario = usuario;
                        CostoUsu.Costo = costo;
                        CostoUsu.HorasSemanales = horas;
                        db.CostoUsuarioHora.InsertOnSubmit(CostoUsu);
                        db.SubmitChanges();
                    }
                    CargarCostos();
                    updRecusos.Update();
                }
            }
        }

        protected void valUsuarioAgr_ServerValidate(object source, ServerValidateEventArgs args)
        {
            using (TiempoLaboralDataContext db = new TiempoLaboralDataContext())
            {
                
                string usuario = ((TextBox)repRecursos.Controls[0].FindControl("txtUsuario")).Text.Trim().ToLower();
                bool existe = (from c in db.CostoUsuarioHora
                               where c.Usuario == usuario
                               select c).Any();
                args.IsValid = !existe;
            }

        }

    }
}
