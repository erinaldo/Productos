using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;
using AjaxControlToolkit;

public partial class NavegacionEncuesta : System.Web.UI.Page, INavegacionEncuesta
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            AdministrarEncuesta controladora = new AdministrarEncuesta(this);
            controladora.ObtenerEncuestas();
            Session["EditarEncuesta"] = null;
        }
    }
    protected void dsEncuestas_Selecting(object sender, LinqDataSourceSelectEventArgs e)
    {
        e.Result = Session["ListaEncuestasFiltradas"];
    }
    protected void dlEncuestas_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "Filtrar")
            FiltrarEncuestas();
        else if (e.CommandName == "Editar")
        {
            List<Encuesta> lista = (List<Encuesta>)Session["ListaEncuestasFiltradas"];
            Session["EditarEncuesta"] = (from enc in lista where enc.ClaveEncuesta == e.CommandArgument.ToString() select enc).FirstOrDefault();
            Response.Redirect("AdministracionEncuesta.aspx");
        }

    }

    /*protected void Nuevo_Registro_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AdministracionEncuesta.aspx");
    }*/
    protected void Nuevo_Registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministracionEncuesta.aspx");
    }

    public void PresentarEncuestas(List<MODMEG.Encuesta> listaEncuestas)
    {
        Session["ListaEncuestas"] = listaEncuestas;
        //FiltrarEncuestas();
        Session["ListaEncuestasFiltradas"] = listaEncuestas;
        dlEncuestas.DataBind();
    }
    private void FiltrarEncuestas()
    {
        TextBox filClave = (TextBox)dlEncuestas.FindControl("filClave");
        TextBox filNombreEncuesta = (TextBox)dlEncuestas.FindControl("filNombreEncuesta");
        TextBox filTipo = (TextBox)dlEncuestas.FindControl("filTipo");
        ComboBox cmbEstado = (ComboBox)dlEncuestas.FindControl("cmbEstado");

        string clave = (filClave == null ? "" : filClave.Text).ToUpper();
        string nombre = (filNombreEncuesta == null ? "" : filNombreEncuesta.Text).ToUpper();
        string tipo = (filTipo == null ? "" : filTipo.Text).ToUpper();
        bool? estado = null;
        if ((cmbEstado != null) && (cmbEstado.SelectedValue != "T"))
            estado = (cmbEstado.SelectedValue == "A");

        List<Encuesta> lista = (List<Encuesta>)Session["ListaEncuestas"];

        List<Encuesta> listafiltrada = (from l in lista
                                        where l.ClaveEncuesta.ToUpper().Contains(clave) &&
                                        l.Nombre.ToUpper().Contains(nombre) &&
                                        l.ValorReferencia.Descripcion.ToUpper().Contains(tipo) &&
                                        (estado == null? true: l.Estado == estado)
                                        select l).ToList();

        if (listafiltrada.Count == 0)
            listafiltrada.Add(new Encuesta());


        Session["ListaEncuestasFiltradas"] = listafiltrada;
        dlEncuestas.DataBind();
    }
}