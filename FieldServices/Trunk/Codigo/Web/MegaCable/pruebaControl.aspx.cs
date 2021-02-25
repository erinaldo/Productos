using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebaControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            MODMEG.MegaCableEntities contexto = new MODMEG.MegaCableEntities();
            var lista = (from ob in contexto.Perfil select new { Value = ob.ClavePerfil, Label = ob.Nombre }).ToList();
            ComboBox1.DataSource = lista;
            ComboBox1.DataTextField = "Label";
            ComboBox1.DataValueField = "Value";
            ComboBox1.DataBind();
        }
    }

}