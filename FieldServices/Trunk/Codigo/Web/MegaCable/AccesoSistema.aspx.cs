using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccesoSistema : System.Web.UI.Page, PREMEG.Acceso.IAccesoSistema
{

    public string Usuario
    {
        get
        {
            return txtUsuario.Text;
        }
        set
        {
            txtUsuario.Text = value;
        }
    }
    public string Contrasenia
    {
        get
        {
            return txtContrasenia.Text;
        }
        set
        {
            txtContrasenia.Text = value;
        }
    }

    public void MensajeError(string mensaje)
    {
        fldError.Text = mensaje;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            UtilEtiquetas.CargarEtiquetas(this);
        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Session["ListaMenu"] = null;
        PREMEG.Acceso.AccesarAlSistema presentacion = new PREMEG.Acceso.AccesarAlSistema(this);
        MODMEG.Usuario usu = presentacion.ValidarAccesoUsuario();
        if (usu != null)
        {
            Session["ClaveUsuario"] = usu.ClaveUsuario;
            Session["NombreUsuario"] = usu.Nombre;
            Session["ClavePerfil"] = usu.Perfil.ClavePerfil;
            
            System.Web.Security.FormsAuthentication.SetAuthCookie(usu.Nombre, false);
            Response.Redirect(System.Web.Security.FormsAuthentication.DefaultUrl);
            //System.Web.Security.FormsAuthentication.RedirectFromLoginPage(usu.ClaveUsuario, false);
        }
    }
}