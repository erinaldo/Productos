using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

public partial class SiteMaster : System.Web.UI.MasterPage, PREMEG.Acceso.ISite
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            UtilEtiquetas.CargarEtiquetas(this);
            if (Session["ListaMenu"] == null)
            {

                PREMEG.Acceso.SeleccionarActividades presentacion = new PREMEG.Acceso.SeleccionarActividades(this);
                presentacion.ObtenerActividades();
            }
            else
            {
                PresentaActividades((PREMEG.Acceso.SeleccionarActividades.ListaMenu[])Session["ListaMenu"]);
            }
        }
    }

    public string ClaveUsuario
    {
        get
        {
            return Session["ClaveUsuario"].ToString();
        }
    }

    public string ClavePerfil
    {
        get
        {
            if (Session["ClavePerfil"] == null)
                return "Admin";//TODO:Quitar esto
            return Session["ClavePerfil"].ToString();
        }
    }


    public void PresentaActividades(PREMEG.Acceso.SeleccionarActividades.ListaMenu[] lista)
    {
        Accordion menuAcordion = new Accordion();
        menuAcordion.ID = "MenuGeneral";
        menuAcordion.HeaderCssClass ="menuheader";
        menuAcordion.CssClass="menu";
        menuAcordion.ContentCssClass = "menuelemento";
        Session["ListaMenu"] = lista;
        Dictionary<string, string> modulos = new Dictionary<string, string>();
        foreach (PREMEG.Acceso.SeleccionarActividades.ListaMenu l in lista)
            if (!modulos.ContainsKey(l.ClaveModulo))
                modulos.Add(l.ClaveModulo, l.NombreModulo);

        menuAcordion.Panes.Clear();
        foreach (KeyValuePair<string, string> m in modulos)
        {
            AccordionPane seccion = new AccordionPane();
            seccion.ID = "ACR" + m.Key;
            seccion.HeaderContainer.Controls.Add(new LiteralControl(m.Value));
            seccion.HeaderCssClass = "hideSkiplink";
            Panel submenu = new Panel();
            submenu.CssClass = "menucontenedor";
            var acti = from act in lista where act.ClaveModulo == m.Key select act;
            foreach (PREMEG.Acceso.SeleccionarActividades.ListaMenu ele in acti)
            {
                LiteralControl liga = new LiteralControl();
                liga.Text = "<div class = 'menuelemento'><a href='" + ele.ClaveActividad + ".aspx' class='menuelemento'><img alt = '' src = 'img/" + ele.ClaveActividad + ".gif' style='border-collapse:collapse;border-style:none;border-width:0px;'/><br/>" + ele.NombreActividad + "</a></div>";
                liga.ID = "MUN" + ele.ClaveActividad;
                
                submenu.Controls.Add(liga);
            }
            seccion.ContentContainer.Controls.Add(submenu);
            menuAcordion.Panes.Add(seccion);
        }
        pnlMenu.Controls.Add(menuAcordion);
    }
}
