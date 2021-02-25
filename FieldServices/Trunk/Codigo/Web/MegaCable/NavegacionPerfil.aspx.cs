using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;
using AjaxControlToolkit;

public partial class NavegacionPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AdministrarPerfil controladora = new AdministrarPerfil();
            Session["ListaPerfiles"] = controladora.ObtenerPerfiles();
            FiltrarPerfiles("","", null);
        }
    }
    private void FiltrarPerfiles()
    {
        TextBox txtClavePerfil = (TextBox)dlPerfiles.FindControl("filPerfil");
        TextBox txtDesc = (TextBox)dlPerfiles.FindControl("filDescripcion");
        ComboBox cmbCheck = (ComboBox)dlPerfiles.FindControl("cmbEstado");
        object activo = null;
        if (cmbCheck.SelectedValue != "T")
            activo = cmbCheck.SelectedValue == "A";
        FiltrarPerfiles(txtClavePerfil.Text.Trim().ToUpper(), txtDesc.Text.Trim().ToUpper(), activo);
        txtClavePerfil.Focus();
    }
    private void FiltrarPerfiles(string ClavePerfil, string Descripcion, object Estado)
    {
       List<Perfil> lista = (List<Perfil>)Session["ListaPerfiles"];
       List<Perfil> listaFiltrada = (from per in lista
                                     where
                                         per.ClavePerfil.ToUpper().Contains(ClavePerfil) &&
                                         per.Nombre.ToUpper().Contains(Descripcion) &&
                                         (Estado == null ? true : per.Estado == Convert.ToBoolean(Estado))
                                     select per).ToList();
       if (listaFiltrada.Count == 0)
           listaFiltrada.Add(new Perfil());
       Session["ListaPerfilesFiltrado"] = listaFiltrada;

    }
    protected void dsPerfiles_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {

        e.Result = Session["ListaPerfilesFiltrado"];
    }
    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e)
    {
        Session["EditarPerfil"] = null;
        Response.Redirect("AdministracionPerfil.aspx");
    }*/
    protected void dlPerfiles_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Filtrar")
        {
            FiltrarPerfiles();
            dlPerfiles.DataBind();
        }
        else if (e.CommandName == "QuitarFiltro")
        {
            TextBox txtClavePerfil = (TextBox)dlPerfiles.FindControl("filPerfil");
            TextBox txtDesc = (TextBox)dlPerfiles.FindControl("filDescripcion");
            ComboBox cmbCheck = (ComboBox)dlPerfiles.FindControl("cmbEstado");
            txtClavePerfil.Text = "";
            txtDesc.Text = "";
            cmbCheck.SelectedValue = "T";
            FiltrarPerfiles();
            dlPerfiles.DataBind();
        }
        else if (e.CommandName == "Editar")
            if (e.CommandArgument.ToString() != "")
            {
                Perfil perfil = (from per in ((List<Perfil>)Session["ListaPerfilesFiltrado"]) where per.ClavePerfil == e.CommandArgument.ToString() select per).FirstOrDefault();
                Session["EditarPerfil"] = perfil;
                if (perfil != null)
                    Response.Redirect("AdministracionPerfil.aspx");
            }
    }
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        Session["EditarPerfil"] = null;
        Response.Redirect("AdministracionPerfil.aspx");
    }
}