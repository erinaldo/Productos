using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;
using System.Web.Services;
using System.Web.Script.Services;

public partial class AdministracionSucursalEquipo : System.Web.UI.Page, IAdministracionSucursalEquipo
{

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<AdministrarSucursalEquipo.ResultadoAutocompletar> GetMateriales(string term, string ClaveSucursal)
    {

        AdministrarSucursalEquipo controladora = new AdministrarSucursalEquipo();
        return controladora.ObtenerMaterialesContenido(term, ClaveSucursal);
    }

    public string ClaveSucursal
    {
        get
        {
            return cmbSucursal.SelectedValue;
        }
        set
        {
            cmbSucursal.SelectedValue = value;
        }
    }



    public List<Material> ListaMateriales
    {
        set
        {
            Session["SucursalMaterial"] = value;
            ActualizarLista();
        }
        get
        {
            return (List<Material>)Session["SucursalMaterial"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            AdministrarSucursalEquipo controladora = new AdministrarSucursalEquipo(this);
            List<Sucursal> lista = controladora.ObtenerSucursales();
            cmbSucursal.DataSource = lista;
            cmbSucursal.DataValueField = "ClaveSucursal";
            cmbSucursal.DataTextField = "Nombre";
            cmbSucursal.DataBind();
            controladora.ObtenerMateriales(cmbSucursal.SelectedValue.ToString().Trim());
        }
    }

    private void ActualizarLista()
    {
        hidSucursal.Value = cmbSucursal.SelectedValue.ToString().Trim();
        dlMaterial.DataSource = ListaMateriales;
        dlMaterial.DataBind();
        UtilEtiquetas.CargarEtiquetas(dlMaterial);
        updMateriales.Update();
    }


    protected void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
    {
        AdministrarSucursalEquipo controladora = new AdministrarSucursalEquipo(this);
        controladora.ObtenerMateriales(cmbSucursal.SelectedValue.ToString().Trim());

    }


    protected void dlMaterial_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Borrar")
        {
            AdministrarSucursalEquipo controladora = new AdministrarSucursalEquipo(this);
            controladora.EliminarSucursalEquipo(cmbSucursal.SelectedValue.ToString().Trim(), e.CommandArgument.ToString());
            controladora.ObtenerMateriales(cmbSucursal.SelectedValue.ToString().Trim());
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        AdministrarSucursalEquipo controladora = new AdministrarSucursalEquipo(this);
        controladora.AgregarSucursalEquipo(cmbSucursal.SelectedValue.ToString().Trim(), hidValor.Value);
        controladora.ObtenerMateriales(cmbSucursal.SelectedValue.ToString().Trim());
        /*txtMaterial.Text = "";
        hidValor.Value = "";
        updMaterial.Update();
        /*ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "pop", "javascript:CargarAutocompletar();", true);*/
    }
}