using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PREMEG.Acceso;
using MODMEG;

public partial class AdministracionPerfil : System.Web.UI.Page, IAdministracionPerfil
{
    public string ClavePerfil
    {
        get
        {
            return txtPerfil.Text;
        }
        set
        {
            txtPerfil.Text = value;
        }
    }

    public string Descripcion
    {
        get
        {
            return txtDescripcion.Text;
        }
        set
        {
            txtDescripcion.Text = value;
        }
    }

    public bool Estado
    {
        get
        {
            return chkActivo.Checked;
        }
        set
        {
            chkActivo.Checked = value;
        }
    }

    public List<Actividad> ListaAsignadas
    {
        get
        {
            return (List<Actividad>)Session["ActividadesAsignadas"];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            chkActivo.Checked = true;
            if (Session["EditarPerfil"] != null)
                CargarPerfilSesion();
            if (Session["ActividadesAsignadas"] == null)
                Session["ActividadesAsignadas"] = new List<Actividad>();
            AdministrarPerfil controladora = new AdministrarPerfil();
            Session["ActividadesActivas"] = controladora.ObtenerActividadesActivas();
            CalcularDiferenciaActividades();
            chlAsignadas.DataSource = Session["ActividadesAsignadas"];
            chlAsignadas.DataBind();
            chlActividades.DataSource = Session["DiferenciaActividades"];
            chlActividades.DataBind();
            
        }
    }

    private void RecargarListas()
    {
        CalcularDiferenciaActividades();

        chlAsignadas.DataSource = Session["ActividadesAsignadas"];
        chlAsignadas.DataBind();
        chlActividades.DataSource = Session["DiferenciaActividades"];
        chlActividades.DataBind();

        updActividades.Update();
        updAsignadas.Update();
    }
    private void CalcularDiferenciaActividades()
    {
        List<Actividad> activas = (List<Actividad>)Session["ActividadesActivas"];
        List<Actividad> asignadas = (List<Actividad>)Session["ActividadesAsignadas"];
        List<Actividad> diferencia = new List<Actividad>();
        foreach (Actividad a in activas)
        {
            if (!asignadas.Exists(act => act.ClaveActividad == a.ClaveActividad))
                diferencia.Add(a);
        }

        //var diferencia  = activas.Except(asignadas);

        Session["DiferenciaActividades"] = diferencia;

    }
    private void CargarPerfilSesion()
    {
        Perfil per = (Perfil)Session["EditarPerfil"];
        lblTitulo.Text = UtilMensaje.ObtenerMensaje("#ModificarPerfil");
        AdministrarPerfil controladora = new AdministrarPerfil();
        Session["ActividadesAsignadas"] = controladora.ObtenerActividadesAsignadas(per.ClavePerfil);
        txtPerfil.ReadOnly = true;
        txtPerfil.Text = per.ClavePerfil;
        txtDescripcion.Text = per.Nombre;
        chkActivo.Checked = per.Estado;
    }
    protected void btnAgregar_Click(object sender, ImageClickEventArgs e)
    {
        List<Actividad> asignadas = (List<Actividad>)Session["ActividadesAsignadas"];
        List<Actividad> activas = (List<Actividad>)Session["ActividadesActivas"];
        foreach (ListItem i in chlActividades.Items)
        {
            if (i.Selected)
            {

                Actividad a = activas.FirstOrDefault(act => act.ClaveActividad == i.Value);
                if(a != null)
                asignadas.Add(a);
            }
        }
        RecargarListas(); 
    }
    protected void btnQuitar_Click(object sender, ImageClickEventArgs e)
    {
        List<Actividad> asignadas = (List<Actividad>)Session["ActividadesAsignadas"];
        foreach (ListItem i in chlAsignadas.Items)
        {
            if (i.Selected)
            {
                Actividad act = asignadas.FirstOrDefault(a => a.ClaveActividad == i.Value);
                asignadas.Remove(act);
            }
        }
        RecargarListas(); 
    }
    protected void imgAceptar_Click(object sender, ImageClickEventArgs e)
    {
        if (Page.IsValid)
        {
            AdministrarPerfil administrarPerfil = new AdministrarPerfil(this);
            if (Session["EditarPerfil"] != null)
            {
                administrarPerfil.ActualizarPerfil((Perfil)Session["EditarPerfil"]);
            }
            else
                administrarPerfil.RegistrarPerfil(ClavePerfil, Descripcion, Estado);
            LimpiarVariablesUsadas();
            Response.Redirect("NavegacionPerfil.aspx");
        }
    }

    private void LimpiarVariablesUsadas()
    {
        Session["ActividadesAsignadas"] = null;
        Session["EditarPerfil"] = null;
        Session["ActividadesActivas"] = null;
        Session["DiferenciaActividades"] = null;
    }



    protected void imgCancelar_Click(object sender, ImageClickEventArgs e)
    {
        LimpiarVariablesUsadas();
        Response.Redirect("NavegacionPerfil.aspx");
    }
    protected void customValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        AdministrarPerfil administrarPerfil = new AdministrarPerfil(this);
        args.IsValid = administrarPerfil.ValidarDatosProporcionados((Perfil)Session["EditarPerfil"], Estado);
        if (!args.IsValid)
        {
            customValidator.ErrorMessage = UtilMensaje.ObtenerMensaje("#ME0025");
            updComandos.Update();
        }
    }
}